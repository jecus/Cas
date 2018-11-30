using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CAS.Core.Core.Management;
using CAS.Core.Management;
using CAS.UI.UIControls.WorkPackages;

namespace CAS.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DomrachevSergeyVIPForm : Form
    {
         

        /// <summary>
        /// 
        /// </summary>
        public DomrachevSergeyVIPForm()
        {
            InitializeComponent();
            
            //BiWeeklyItem item = new BiWeeklyItem(Resources.BiWeeklyReportsIcon, "23-34-23");
            //item.Location = new Point(300,300);
            //Controls.Add(item);


            
           
            string message = "";
            ConnectionManager.Connect("dev\\dev2005@CASDemo", "TechnicianTest", "TechnicianTest", AuthenticationType.SQLServer,
                                      out message);
            //OperatorCollection opc = OperatorCollection.Instance;
            //Aircraft aircraft = opc.GetByID(30).AircraftCollection.GetByID(23);
            //BaseDetailCollection bc = new BaseDetailCollection(aircraft);
            //BaseDetail bd = bc.GetByID(6);


        }


        Panel mainPanel = new Panel();

        private void button1_Click_1(object sender, EventArgs e)
        {
            string message = "";
            for (int i = 160; i < 255; i++)
            {
                Char ch = (char)i;
                message += ch + "  " + i + Environment.NewLine;
            }
            MessageBox.Show(message);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



    }
}