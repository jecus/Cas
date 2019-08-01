namespace CAS.UI.UIControls.ForecastControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class AirFleetForecastListView : ForecastListView
    {
        #region public ForecastListView()
        ///<summary>
        ///</summary>
        public AirFleetForecastListView()
        {
            InitializeComponent();
        }
		#endregion

		#region Methods

		#region protected override SetGroupsToItems(int columnIndex)
		//protected override void SetGroupsToItems(int columnIndex)
  //      {
  //          itemsListView.Groups.Clear();

  //          foreach (ListViewItem item in ListViewItemList)
  //          {
  //              if (!(item.Tag is NextPerformance)) continue;

  //              var parent = ((NextPerformance)item.Tag).Parent;

		//		var temp = "";
		//		Lifelength current, forecast;

  //              if (parent is Directive)
  //              {
		//			var directive = (Directive)parent;

  //                  current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(directive.ParentBaseComponent);
  //                  forecast = directive.ForecastLifelength;
                    
  //                  temp = ListViewGroupHelper.GetDirectiveGroupString(directive, current, forecast);
  //              }
  //              else if (parent is BaseComponent)
  //              {
  //                  var baseDetail = (BaseComponent)parent;

  //                  current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail.ParentBaseComponent);
  //                  forecast = baseDetail.ForecastLifelength;

		//			temp = ListViewGroupHelper.GetBaseComponentGroupString(baseDetail, current, forecast);
		//		}

  //              else if (parent is Component)
  //              {
  //                  var detail = (Component)parent;
  //                  if (detail.ParentBaseComponent != null)
  //                  {
		//				//TODO:(Evgenii Babak) выяснить почему расчитывается ParentBaseDetail , а не сам Detail
		//				//TODO:(Evgenii Babak) заменить на использование ComponentCore 
		//				current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(detail.ParentBaseComponent);
		//				forecast = detail.ParentBaseComponent.ForecastLifelength;
		//				temp = ListViewGroupHelper.GetComponentGroupString(detail, current, forecast);
		//			}
  //                  else temp = "Components";
  //              }

  //              else if (parent is ComponentDirective)
  //              {
		//			var dd = (ComponentDirective)parent;

	 //               if (dd.ParentComponent != null)
	 //               {
		//                if (dd.ParentComponent.IsBaseComponent)
		//                {
		//					current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength((BaseComponent)dd.ParentComponent);
		//					forecast = dd.ParentComponent.ForecastLifelength;
		//					temp = ListViewGroupHelper.GetComponentDirectiveGroupString(dd, current, forecast);
		//                }
		//                else
		//                {
		//					current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(dd.ParentComponent);
		//					forecast = dd.ParentComponent.ForecastLifelength;
		//					temp = ListViewGroupHelper.GetComponentDirectiveGroupString(dd, current, forecast);
		//				}
	 //               }
	 //               else temp = "Detail Directives";
  //              }

  //              else if (parent is MaintenanceCheck)
  //              {
  //                  var mc = (MaintenanceCheck)parent;

  //                  current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(mc.ParentAircraft);
  //                  forecast = mc.ForecastLifelength;

		//			temp = ListViewGroupHelper.GetMaintenanceCheckGroupString(mc, current, forecast);
		//		}
  //              else if (parent is MaintenanceDirective)
  //              {
  //                  var md = (MaintenanceDirective)parent;

  //                  current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(md.ParentBaseComponent);
  //                  forecast = md.ForecastLifelength;

		//			temp = ListViewGroupHelper.GetMaintenanceDirectiveGroupString(md, current, forecast);
		//		}

		//		itemsListView.Groups.Add(temp, temp);
		//		item.Group = itemsListView.Groups[temp];
		//	}
  //      }
        #endregion

        #region protected override void SortItems(int columnIndex)

      //  protected override void SortItems(int columnIndex)
      //  {
      //      if (OldColumnIndex != columnIndex)
      //          SortMultiplier = -1;
      //      if (SortMultiplier == 1)
      //          SortMultiplier = -1;
      //      else
      //          SortMultiplier = 1;
      //      itemsListView.Items.Clear();
      //      OldColumnIndex = columnIndex;

      //      List<ListViewItem> resultList = new List<ListViewItem>();

      //      if (columnIndex != 6)
      //      {
      //          SetGroupsToItems(columnIndex);

      //          ListViewItemList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));
      //          //добавление остальных подзадач
      //          foreach (ListViewItem item in ListViewItemList)
      //          {
      //              resultList.Add(item);
      //              NextPerformance np = (NextPerformance)item.Tag;
      //              if (np.Parent is MaintenanceCheck && ((MaintenanceCheck)np.Parent).Grouping)
      //              {
      //                  MaintenanceCheck mc = (MaintenanceCheck)np.Parent;
      //                  List<MaintenanceNextPerformance> performances = mc.GetPergormanceGroupWhereCheckIsSenior();
      //                  if (performances == null || performances.Count == 1) continue;
      //                  for (int i = 1; i < performances.Count; i++)
      //                  {
      //                      ListViewItem temp = new ListViewItem(GetListViewSubItems(performances[i]), null)
      //                      {
      //                          Tag = performances[i],
      //                          Group = item.Group
      //                      };
      //                      resultList.Add(temp);
      //                  }
      //              }
      //              else
      //              {
      //                  //первая подзадача описывает саму родитескую задачу, повторно ее добавлять ненадо
      //                  if (np.Parent.NextPerformances == null || np.Parent.NextPerformances.Count <= 1) continue;
      //                  for (int i = 1; i < np.Parent.NextPerformances.Count; i++)
      //                  {
      //                      ListViewItem temp = new ListViewItem(GetListViewSubItems(np.Parent.NextPerformances[i]), null)
      //                      {
      //                          Tag = np.Parent.NextPerformances[i],
      //                          Group = item.Group
      //                      };
      //                      resultList.Add(temp);
      //                  }
      //              }
      //          }
      //      }
      //      else
      //      {
      //          foreach (ListViewItem item in ListViewItemList)
      //          {
      //              resultList.Add(item);
      //              NextPerformance np = (NextPerformance)item.Tag;
      //              if (np.Parent is MaintenanceCheck && ((MaintenanceCheck)np.Parent).Grouping)
      //              {
      //                  MaintenanceCheck mc = (MaintenanceCheck)np.Parent;
      //                  List<MaintenanceNextPerformance> performances = mc.GetPergormanceGroupWhereCheckIsSenior();
      //                  if (performances == null || performances.Count == 1) continue;
      //                  for (int i = 1; i < performances.Count; i++)
      //                  {
      //                      ListViewItem temp = new ListViewItem(GetListViewSubItems(performances[i]), null)
      //                      {
      //                          Tag = performances[i],
      //                          Group = item.Group
      //                      };
      //                      resultList.Add(temp);
      //                  }
      //              }
      //              else
      //              {
      //                  //первая подзадача описывает саму родитескую задачу, повторно ее добавлять ненадо
      //                  if (np.Parent.NextPerformances == null || np.Parent.NextPerformances.Count <= 1) continue;
      //                  for (int i = 1; i < np.Parent.NextPerformances.Count; i++)
      //                  {
      //                      ListViewItem temp = new ListViewItem(GetListViewSubItems(np.Parent.NextPerformances[i]), null)
      //                      {
      //                          Tag = np.Parent.NextPerformances[i],
      //                      };
      //                      resultList.Add(temp);
      //                  }
      //              }
      //          }

      //          resultList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));
      //          itemsListView.Groups.Clear();

      //          //Группировка элементов по датам выполнения
      //          var groupedItems =
      //              resultList.Where(lvi => lvi.Tag != null && lvi.Tag is NextPerformance)
      //                        .GroupBy(lvi => Convert.ToDateTime(((NextPerformance)lvi.Tag).PerformanceDate).Date);
      //          foreach (var groupedItem in groupedItems)
      //          {
      //              //Собрание всех выполнений на данную дату в одну коллекцию
      //              var groupByAircraft =
      //                  groupedItem.Where(lvi => lvi.Tag != null && lvi.Tag is NextPerformance)
      //                              .GroupBy(lvi => GlobalObjects.AircraftsCore.GetParentAircraft((NextPerformance)lvi.Tag));
      //              foreach (var byAircraft in groupByAircraft)
      //              {
      //                  var performances = byAircraft.Select(lvi => lvi.Tag as NextPerformance).ToList();

						//var temp = ListViewGroupHelper.GetGroupStringByPerformanceDate(performances, groupedItem.Key.Date, byAircraft.Key.RegistrationNumber);

						//itemsListView.Groups.Add(temp, temp);
      //                  foreach (var item in byAircraft)
      //                      item.Group = itemsListView.Groups[temp];    
      //              }
      //          }
      //      }
      //      itemsListView.Items.AddRange(resultList.ToArray());
      //  }

        #endregion

        #endregion
    }
}
