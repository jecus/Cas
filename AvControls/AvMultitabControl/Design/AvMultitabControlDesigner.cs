#region

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

#endregion

namespace AvControls.AvMultitabControl.Design
{
    internal class AvMultitabControlDesigner : ParentControlDesigner
    {
        private IComponentChangeService _changeService;

        public override ICollection AssociatedComponents
        {
            get { return Control.TabPages.QueueList; }
        }

        public new virtual AvMultitabControl Control
        {
            get { return (base.Control as AvMultitabControl); }
        }

        protected override void Dispose(bool disposing)
        {
            _changeService.ComponentRemoving -= OnRemoving;
            base.Dispose(disposing);
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            _changeService = (IComponentChangeService) GetService(typeof (IComponentChangeService));
            _changeService.ComponentRemoving += OnRemoving;
            Verbs.Add(new DesignerVerb("Add page", OnAddTabPage));
            Verbs.Add(new DesignerVerb("Remove page", OnRemoveTabPage));
        }

        private void OnAddTabPage(object sender, EventArgs e)
        {
            IDesignerHost service = (IDesignerHost) GetService(typeof (IDesignerHost));
            MultitabPage page = service.CreateComponent(Control.TypeOfPages) as MultitabPage;
            if (page != null)
            {
                page.Text = "MultitabPage" + (Control.TabPages.Count + 1);
                Control.TabPages.Add(page);
            }
        }

        private void OnRemoveTabPage(object sender, EventArgs e)
        {
            if (Control.TabPages.Count != 0)
            {
                IDesignerHost service = (IDesignerHost) GetService(typeof (IDesignerHost));
                MultitabPage selectedTab = Control.SelectedTab;
                Control.CloseTab(selectedTab);
                service.DestroyComponent(selectedTab);
            }
        }

        private void OnRemoving(object sender, ComponentEventArgs e)
        {
            IDesignerHost service = (IDesignerHost) GetService(typeof (IDesignerHost));
            if (e.Component is MultitabPage)
            {
                MultitabPage component = e.Component as MultitabPage;
                if (Control.TabPages.Contains(component))
                {
                    Control.CloseTab(component);
                    return;
                }
            }
            if (e.Component == Control)
            {
                for (int i = Control.TabPages.Count - 1; i >= 0; i--)
                {
                    MultitabPage page = Control.TabPages[i];
                    Control.TabPages.Remove(page);
                    service.DestroyComponent(page);
                }
            }
        }

        protected override void PostFilterEvents(IDictionary events)
        {
            base.PostFilterEvents(events);
            events.Remove("BackColorChanged");
            events.Remove("BackgroundImageChanged");
            events.Remove("BackgroundImageLayoutChanged");
            events.Remove("ForeColorChanged");
            events.Remove("FontChanged");
            events.Remove("Paint");
            events.Remove("TextChanged");
        }

        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("BackgroundImage");
            properties.Remove("BackgroundImageLayout");
            properties.Remove("ForeColor");
            properties.Remove("Font");
            properties.Remove("Text");
        }

        private void ReactToMouseClick(int messageType)
        {
            if (Control.TabPages.Count != 0)
            {
                Point point = Control.PointToClient(Cursor.Position);
                int pageByPoint = Control.GetPageByPoint(point);
                if (pageByPoint != -1)
                {
                    MultitabPage tabPage = Control.TabPages[pageByPoint];
                    if (messageType == 0x201)
                    {
                        Control.SelectTab(tabPage);
                    }
                    else if (messageType == 0x207)
                    {
                        IDesignerHost service = (IDesignerHost) GetService(typeof (IDesignerHost));
                        Control.CloseTab(tabPage);
                        service.DestroyComponent(tabPage);
                    }
                }
                else if (Control.DropDownButton.Bounds.Contains(point))
                {
                    Control.ActivePagesMenu.Items.Clear();
                    for (int i = 0; i < Control.TabPages.Count; i++)
                    {
                        Control.ActivePagesMenu.Items.Add(Control.TabPages[i].Text, null, Control.TabClicked).Tag =
                            Control.TabPages[i];
                    }
                    Control.ActivePagesMenu.Show(Control, Control.DropDownButton.Left,
                                                 Control.DropDownButton.Top + Control.DropDownButton.Height);
                }
                else if (Control.CloseButton.Bounds.Contains(point))
                {
                    Control.CloseTab(Control.SelectedTab);
                }
                else if (((pageByPoint == -1) && (messageType == 0x207)) && (Control.TabPages.Count > 0))
                {
                    IDesignerHost host2 = (IDesignerHost) GetService(typeof (IDesignerHost));
                    MultitabPage selectedTab = Control.SelectedTab;
                    Control.CloseTab(selectedTab);
                    host2.DestroyComponent(selectedTab);
                }
            }
        }

        protected override void WndProc(ref Message msg)
        {
            if ((msg.Msg == 0x201) || (msg.Msg == 0x207))
            {
                ReactToMouseClick(msg.Msg);
            }
            base.WndProc(ref msg);
        }
    }
}