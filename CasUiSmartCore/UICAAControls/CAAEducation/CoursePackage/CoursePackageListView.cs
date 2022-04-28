using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA.CAAWP;
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls.CAAEducation.CoursePackage
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class CoursePackageListView : BaseGridViewControl<CAAWorkPackage>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;
        private readonly Operator _operator;

        public CoursePackageListView()
        {
            InitializeComponent();
		}

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        /// <param
        ///     name="operator">
        /// </param>
        public CoursePackageListView(AnimatedThreadWorker animatedThreadWorker, Operator @operator) : this()
		{
            _animatedThreadWorker = animatedThreadWorker;
            _operator = @operator;
            SortDirection = SortDirection.Asc;
			OldColumnIndex = 1;
		}

        public int OperatorId { get; set; }
        

		#region Methods

		protected override void GroupingItems()
		{
			Grouping("Status");
		}


		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Status", (int)(radGridView1.Width * 0.24f));
			AddColumn("Number", (int)(radGridView1.Width * 0.24f));
			AddColumn("Title", (int)(radGridView1.Width * 0.24f));
			AddColumn("Perform Date", (int)(radGridView1.Width * 0.24f));
			AddColumn("Duration", (int)(radGridView1.Width * 0.24f));
			AddColumn("Remark", (int)(radGridView1.Width * 0.24f));
			AddColumn("Open Date", (int)(radGridView1.Width * 0.24f));
			AddColumn("Start Date", (int)(radGridView1.Width * 0.24f));
			AddColumn("Closing Date", (int)(radGridView1.Width * 0.24f));
			AddColumn("Location", (int)(radGridView1.Width * 0.24f));
			AddColumn("Author", (int)(radGridView1.Width * 0.24f));
			AddColumn("Start By", (int)(radGridView1.Width * 0.24f));
			AddColumn("Closed By", (int)(radGridView1.Width * 0.24f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

        public override void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (this.SelectedItems == null ||
                this.SelectedItems.Count == 0) return;

            string typeName = nameof(SmartCore.CAA.FindingLevel.FindingLevels);

            DialogResult confirmResult =
                MessageBox.Show(this.SelectedItems.Count == 1
                        ? "Do you really want to delete " + typeName + " " + this.SelectedItems[0] + "?"
                        : "Do you really want to delete selected " + typeName + "s?", "Confirm delete operation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                this.radGridView1.BeginUpdate();
                GlobalObjects.NewKeeper.Delete(this.SelectedItems.OfType<BaseEntityObject>().ToList(), true);
                var ids = this.SelectedItems.OfType<BaseEntityObject>().ToList().Select(i => i.ItemId);
                GlobalObjects.CaaEnvironment.Execute($"update  [dbo].[CourseRecords] set IsDeleted = 1 where WorkPackageId in ({string.Join(",", ids)})");
                GlobalObjects.CaaEnvironment.Execute($"update [dbo].[EducationRecords] set SettingsJSON = JSON_MODIFY(SettingsJSON, '$.BlockedWpId', null)" +
                                                     $" where ItemId in (select ObjectId from [dbo].[CourseRecords] where ItemId in ({string.Join(",", ids)}))");
                
                this.radGridView1.EndUpdate();
                _animatedThreadWorker.RunWorkerAsync();
            }
		}

		#region protected override List<CustomCell> GetListViewSubItems(FindingLevels item)

		protected override List<CustomCell> GetListViewSubItems(CAAWorkPackage item)
        {
	        var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item);
	        var author = GlobalObjects.CaaEnvironment?.GetCorrector(item.Settings.Author);
	        var published = GlobalObjects.CaaEnvironment?.GetCorrector(item.Settings.PublishedBy);
	        var closed = GlobalObjects.CaaEnvironment?.GetCorrector(item.Settings.ClosedBy);
	        var openDate = SmartCore.Auxiliary.Convert.GetDateFormat(item.Settings.OpeningDate);
	        var publisherDate = item.Status > WPStatus.Open ? SmartCore.Auxiliary.Convert.GetDateFormat(item.Settings.PublishingDate) : String.Empty ;
	        var closingDate = item.Status > WPStatus.Published ? SmartCore.Auxiliary.Convert.GetDateFormat(item.Settings.ClosingDate) : String.Empty ;
	        
	        var subItems = new List<CustomCell>()
			{
				CreateRow(item.StatusName, item.Status),
				CreateRow(item.Settings.Number, item.Settings.Number),
				CreateRow(item.Title, item.Title),
				CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.Settings.PerformDate), item.Settings.PerformDate),
				CreateRow(item.Settings.Duration,item.Settings.Duration),
				CreateRow(item.Settings.Remarks,item.Settings.Remarks),
				CreateRow(openDate,item.Settings.OpeningDate),
				CreateRow(publisherDate,item.Settings.PublishedBy),
				CreateRow(closingDate,item.Settings.ClosingDate),
				CreateRow(item.Settings.Location, item.Settings.Location),
				CreateRow(author,author),
				CreateRow(published,published),
				CreateRow(closed,closed),
				CreateRow(corrector, corrector)
			};

			return subItems;
		}

		#endregion
		
		
		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			e.DisplayerText = $"WP:{SelectedItem.Title}";
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.RequestedEntity = new CourseRecordListScreen(_operator, SelectedItem);
		}


		#endregion
	}
}
