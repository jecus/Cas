using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LTR.Core;
using LTR.UI.Management;
using LTR.UI.Properties;
using LTR.UI.UIControls.AircraftsControls;
using LTR.UI.UIControls.Auxiliary;
using LTR.UI.UIControls.ReferenceControls;

namespace LTR.UI.UIControls.LogBookControls
{
    public partial class AircraftsLogBookScreen : UserControl
    {
        #region Constructor
        /// <summary>
        /// Создает объект для отображения журнала одного самолета за период
        /// </summary>
        /// <param name="aircraft"></param>
        public AircraftsLogBookScreen(Aircraft aircraft)
        {
            currentAircraft = aircraft;
            Initialize();
        }
        #endregion

        #region Methods
        private void Initialize()
        {
            components = new Container();
            AutoScaleMode = AutoScaleMode.Font;

            footerControl = new FooterControl();
            header = new HeaderControl();
            aircraftHeader = new AircraftHeaderControl(currentAircraft, true);
            aircraftsLogBookContainer = new ExtendableRichContainer();
            aircraftLogBookControl = new AircraftsLogBookControl(currentAircraft);
            panelLogBookScreen = new Panel();
            // 
            // header
            // 
            header.BackColor = Color.Transparent;
            header.BackgroundImage = Resources.HeaderBar;
            header.Controls.Add(aircraftHeader);
            header.Dock = DockStyle.Top;
            // 
            // aircraftHeader
            // 
            aircraftHeader.BackColor = Color.Transparent;
            aircraftHeader.BackgroundImage = Resources.HeaderBar;
            aircraftHeader.Location = new Point(0, 0);
            aircraftHeader.Size = new Size(319, 58);
            aircraftHeader.AircraftClickable = true;
            //
            //  panelDirectiveScreen
            //
            panelLogBookScreen.AutoScroll = true;
            panelLogBookScreen.Dock = DockStyle.Fill;
            panelLogBookScreen.Controls.Add(aircraftsLogBookContainer);
            //
            // aircraftsLogBookContainer
            //
            aircraftsLogBookContainer.LabelCaption.Cursor = Cursors.Hand;
            aircraftsLogBookContainer.Dock = DockStyle.Top;
            aircraftsLogBookContainer.labelCaption.Margin = new Padding(3, marginTop, 3, marginBottom);
            aircraftsLogBookContainer.LabelCaption.Text = currentAircraft.RegistrationNumber + ". Log book";
            aircraftsLogBookContainer.MainControl = aircraftLogBookControl;
            aircraftsLogBookContainer.pictureBoxIcon.Margin = new Padding(3, marginTop, 3, marginBottom);
            aircraftsLogBookContainer.UpperLeftIcon = icons.GrayArrow;
            // 
            // footerControl
            // 
            footerControl.BackColor = Color.Transparent;
            footerControl.Dock = DockStyle.Bottom;
            footerControl.Name = "footerControl";
            //
            //  this 
            //
            Controls.Add(panelLogBookScreen);
            Controls.Add(header);
            Controls.Add(footerControl);
        }
        #endregion

        #region Fields
        private  Aircraft currentAircraft;
        private  HeaderControl header;
        private  AircraftHeaderControl aircraftHeader;
        private  FooterControl footerControl;
        private  Panel panelLogBookScreen;
        private  Icons icons = new Icons();
        private  ExtendableRichContainer aircraftsLogBookContainer;
        private  AircraftsLogBookControl aircraftLogBookControl;

        private readonly int marginTop = 50;
        private readonly int marginBottom = 25;
        #endregion

    }
}
