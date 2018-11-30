using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.ForecastControls
{
    ///<summary>
    ///</summary>
    public partial class ForecastFilterAircraft : Form
    {
        ///<summary>
        ///</summary>
        public ForecastFilterAircraft()
        {
            InitializeComponent();
        }
        
        #region  public List<Aircraft> filteAircraft
        /// <summary>
        /// Возвращает список ВС для сортировки по ним
        /// </summary>
        public List<Aircraft> FilteAircraft=new List<Aircraft>();
        
        #endregion

        private bool _applay;
        
        ///<summary>
        ///</summary>
        ///<param name="listView"></param>
        public void FillListViewAllAircraft(ListView listView)
        {
            foreach (var item in GlobalObjects.AircraftsCore.GetAllAircrafts())
            {

                listView.Items.Add(item.RegistrationNumber);
                listView.Items[listView.Items.Count - 1].Tag = item;

            }
        }
      
        private void ForecastFilterAircraftLoad(object sender, EventArgs e)
        {
            
                 FillListViewAllAircraft(listView2);
                
        }

        private void Button4Click(object sender, EventArgs e)
        {

           List<ListViewItem> temp=new List<ListViewItem>();
           foreach (ListViewItem item in listView2.SelectedItems)
            {
              temp.Add(item);
              listView2.Items.Remove(item);
            }
            listView1.Items.AddRange(temp.ToArray());
        }

        private void Button1Click(object sender, EventArgs e)
        {
            List<ListViewItem> temp = new List<ListViewItem>();
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                temp.Add(item);
                listView1.Items.Remove(item);
            }
            listView2.Items.AddRange(temp.ToArray());
        
        }

        private void Button2Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            listView1.Items.Clear();
            FillListViewAllAircraft(listView1);
        }

        private void Button3Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            listView1.Items.Clear();
            FillListViewAllAircraft(listView2);
        }

        private void Button5Click(object sender, EventArgs e)
        {
            if(listView2.Items.Count>0)
            {
                foreach (ListViewItem item in listView2.Items)
                {
                    FilteAircraft.Add((Aircraft)item.Tag);
                }   
            }
            else
            {
                FilteAircraft = null;
            }
            _applay = true;
            Close();
        }

        private void ForecastFilterAircraftFormClosed(object sender, FormClosedEventArgs e)
        {
            if (_applay==false)
            {
                FilteAircraft = null;
        }
        }
    }
}
