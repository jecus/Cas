﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA.Check;
using SmartCore.CAA.RoutineAudits;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CheckList
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class CheckListView : BaseGridViewControl<CheckLists>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;

        #region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()

        public CheckListView()
        {
            SortDirection = SortDirection.Asc;
			InitializeComponent();
		}

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        public CheckListView(AnimatedThreadWorker animatedThreadWorker)
		{
            _animatedThreadWorker = animatedThreadWorker;
            InitializeComponent();
			ColumnIndexes = new List<string>()
			{
				"Section №", "Part №","SubPart №","Item №"
			};
			//SortDirection = SortDirection.Asc;
			//OldColumnIndex = 6;
		}

        public bool IsAuditCheck { get; set; }

        #endregion

		#endregion

		#region Methods

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Section №", (int)(radGridView1.Width * 0.20f));
			AddColumn("Section Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("Part №", (int)(radGridView1.Width * 0.24f));
			AddColumn("Part Name", (int)(radGridView1.Width * 0.24f));
            AddColumn("SubPart №", (int)(radGridView1.Width * 0.24f));
            AddColumn("SubPart Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("Item №", (int)(radGridView1.Width * 0.3f));
			AddColumn("Item Name", (int)(radGridView1.Width * 0.5f));
			AddColumn("Requirement", (int)(radGridView1.Width * 0.3f));
			AddColumn("Auditor Action", (int)(radGridView1.Width * 0.3f));
			AddColumn("Source", (int)(radGridView1.Width * 0.3f));
			AddColumn("Level", (int)(radGridView1.Width * 0.2f));
			AddColumn("Edition", (int)(radGridView1.Width * 0.3f));
			AddColumn("Revision", (int)(radGridView1.Width * 0.3f));
			AddColumn("Remain", (int)(radGridView1.Width * 0.1f));
			AddColumn("Phase", (int)(radGridView1.Width * 0.1f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(CheckLists item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>()
			{
				CreateRow(item.Settings.SectionNumber, item.Settings.SectionNumber),
				CreateRow(item.Settings.SectionName, item.Settings.SectionName),
				CreateRow(item.Settings.PartNumber, item.Settings.PartNumber),
				CreateRow(item.Settings.PartName, item.Settings.PartName),
				CreateRow(item.Settings.SubPartNumber, item.Settings.SubPartNumber),
				CreateRow(item.Settings.SubPartName, item.Settings.SubPartName),
				CreateRow(item.Settings.ItemNumber, item.Settings.ItemNumber),
				CreateRow(item.Settings.ItemtName, item.Settings.ItemtName),
				CreateRow(item.Settings.Requirement, item.Settings.Requirement),
				CreateRow("", ""),
                CreateRow(item.Source, item.Source),
                CreateRow(item.Level.ToString(), item.Level),
                CreateRow(item.Settings.EditionNumber, item.Settings.EditionNumber),
                CreateRow(item.Settings.RevisionNumber, item.Settings.RevisionNumber),
                CreateRow(item.Remains.ToString(), item.Remains),
                CreateRow(item.Settings.Phase.ToString(), item.Settings.Phase),
                CreateRow(author, author)
			};

			return subItems;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				if (IsAuditCheck)
				{
					var form = new CheckListAuditForm(SelectedItem);
					if (form.ShowDialog() == DialogResult.OK)
                        _animatedThreadWorker.RunWorkerAsync();
				}
				else
				{
                    var form = new CheckListForm(SelectedItem);
                    if (form.ShowDialog() == DialogResult.OK)
                        _animatedThreadWorker.RunWorkerAsync();
				}


				
                e.Cancel = true;
			}
		}
		#endregion

        #region protected override void SetItemColor(GridViewRowInfo listViewItem, Document item)

        protected override void SetItemColor(GridViewRowInfo listViewItem, CheckLists item)
        {
            var itemBackColor = UsefulMethods.GetColor(item);
            var itemForeColor = Color.Gray;

            foreach (GridViewCellInfo cell in listViewItem.Cells)
            {
                cell.Style.DrawFill = true;
                cell.Style.CustomizeFill = true;
                cell.Style.BackColor = UsefulMethods.GetColor(item);

                var listViewForeColor = cell.Style.ForeColor;

                if (listViewForeColor != Color.MediumVioletRed)
                    cell.Style.ForeColor = itemForeColor;
                cell.Style.BackColor = itemBackColor;
            }
        }


        #endregion


		#endregion
	}
}
