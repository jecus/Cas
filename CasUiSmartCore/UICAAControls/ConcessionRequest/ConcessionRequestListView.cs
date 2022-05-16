﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA;
using Telerik.Data.Expressions;
using Operator = SmartCore.Entities.General.Operator;

namespace CAS.UI.UICAAControls.ConcessionRequest
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class ConcessionRequestListView : BaseGridViewControl<SmartCore.CAA.ConcessionRequest>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;

        #region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()

        public ConcessionRequestListView(AnimatedThreadWorker animatedThreadWorker)
        {
            SortDirection = SortDirection.Asc;
            _animatedThreadWorker = animatedThreadWorker;
			InitializeComponent();
		}

        
        public int OperatorId { get; set; }

        #endregion

		#endregion

		#region Methods

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Operator", (int)(radGridView1.Width * 0.3f));
			AddColumn("Status", (int)(radGridView1.Width * 0.3f));
			AddColumn("Number", (int)(radGridView1.Width * 0.3f));
			AddColumn("From", (int)(radGridView1.Width * 0.3f));
			AddColumn("To", (int)(radGridView1.Width * 0.3f));
			AddColumn("Aircraft", (int)(radGridView1.Width * 0.3f));
			AddColumn("Station", (int)(radGridView1.Width * 0.3f));
			AddColumn("Provider", (int)(radGridView1.Width * 0.3f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

        protected override void GroupingItems()
        {
	        Grouping("Operator");
        }

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(SmartCore.CAA.ConcessionRequest item)
		{
			var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item);

			AllOperators op = null;
			if (item.Settings.Type == ConcessionRequestType.CAA)
				op = GlobalObjects.CaaEnvironment?.AllOperators.FirstOrDefault(i => i.ItemId == item.Settings.OperatorId);
			else op = AllOperators.Unknown;
			
            var subItems = new List<CustomCell>();
            
			subItems.AddRange(new List<CustomCell>()
            {
	            CreateRow(op.ToString(), op),
	            CreateRow(item.Settings.Type.ToString(), item.Settings.Type),
	            CreateRow(item.Settings.Number, item.Settings.Number),
	            CreateRow(item.From.ToString(), item.From),
	            CreateRow(item.To.ToString(), item.To),
	            CreateRow(item.Aircraft.ToString(), item.Aircraft),
	            CreateRow(item.Settings.Station, item.Settings.Station),
	            CreateRow(item.Settings.Provider.ToString(), item.Settings.Provider),
	            CreateRow(corrector, corrector)
            });

            return subItems;
		}

		#endregion

        public override void ButtonDeleteClick(object sender, EventArgs e)
        {
            // if (this.SelectedItems == null ||
            //     this.SelectedItems.Count == 0) return;
            //
            // string typeName = nameof(CheckLists);
            //
            // DialogResult confirmResult =
            //     MessageBox.Show(this.SelectedItems.Count == 1
            //             ? "Do you really want to delete " + typeName + " " + this.SelectedItems[0] + "?"
            //             : "Do you really want to delete selected " + typeName + "s?", "Confirm delete operation",
            //         MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //
            // if (confirmResult == DialogResult.Yes)
            // {
            //     this.radGridView1.BeginUpdate();
            //     GlobalObjects.NewKeeper.Delete(this.SelectedItems.OfType<BaseEntityObject>().ToList(), true);
            //
            //     foreach (var audit in this.SelectedItems)
            //     {
            //         GlobalObjects.CaaEnvironment.NewLoader.Execute(
            //             $"update dbo.AuditCheckRecords set IsDeleted = 1 where AuditRecordId in (select ItemId from dbo.AuditChecks where AuditId = {audit.ItemId})");
            //
            //         GlobalObjects.CaaEnvironment.NewLoader.Execute(
            //             $"update dbo.AuditRecords set IsDeleted = 1 where AuditId = {audit.ItemId}");
            //
            //         GlobalObjects.CaaEnvironment.NewLoader.Execute(
            //             $"update [dbo].[AuditChecks] set IsDeleted = 1 where AuditId = {audit.ItemId}");
            //         
            //         GlobalObjects.CaaEnvironment.NewLoader.Execute(
	           //          $"update [dbo].[AuditPelRecords] set IsDeleted = 1 where AuditId = {audit.ItemId}");
            //     }
            //
            //
            //     this.radGridView1.EndUpdate();
            //     _animatedThreadWorker.RunWorkerAsync();
            // }
        }

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (GlobalObjects.CaaEnvironment.IdentityUser.OperatorId > 0)
			{
				if (SelectedItem.Settings.Type == ConcessionRequestType.CAA)
				{
					if (SelectedItem.Settings.OperatorRecords.Any())
					{
						var form = new EditCAAConcessionRequestForm(SelectedItem);
						if (form.ShowDialog() == DialogResult.OK)
							_animatedThreadWorker.RunWorkerAsync();
					}
					else
					{
						var form = new EditConcessionRequestForm(SelectedItem);
						if (form.ShowDialog() == DialogResult.OK)
							_animatedThreadWorker.RunWorkerAsync();
					}
				}
			}
			else
			{
				if (SelectedItem.Settings.Type == ConcessionRequestType.CAA)
				{
					var form = new EditCAAConcessionRequestForm(SelectedItem);
					if (form.ShowDialog() == DialogResult.OK)
						_animatedThreadWorker.RunWorkerAsync();
				}
				
				
				
			}
			e.Cancel = true;
		}
		#endregion

		#endregion
	}
}
