using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASReports.Builders;
using CASReports.ReportTemplates;
using CASTerms;
using CrystalDecisions.Shared;
using EntityCore.DTO.General;
using MetroFramework.Forms;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using Component = SmartCore.Entities.General.Accessory.Component;

namespace CAS.UI.UIControls.WorkPakage
{
    ///<summary>
    /// Форма, позволяющая делать выбор между компонентами и их расходниками для включения
    /// <br/> в запросный/закупочный акт
    ///</summary>
    public partial class SelectWPPrintTasksForm : MetroForm
    {
        #region Fields

        private readonly AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private PdfDocument _outputDocument;
	    private WorkPackageRoutineTasksGrouping _comboBoxGroupingSelectedValue;

		private const string ComboBoxItemOneToOne = "One for One";
	    private const string _comboBoxItemOneForAll = "One for All";

	    private readonly WorkPackage _workPackage;
	    private readonly bool _isWorkOrder;

	    #endregion

        #region Properties

        #endregion

        #region Constructors

        ///<summary>
        ///</summary>
        private SelectWPPrintTasksForm()
        {
            InitializeComponent();
        }

        ///<summary>
        ///</summary>
        public SelectWPPrintTasksForm(WorkPackage workPackage, bool isWorkOrder = false)
            : this()
        {
            if (workPackage == null)
                throw new ArgumentNullException();
            _workPackage = workPackage;
            _isWorkOrder = isWorkOrder;

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;

            _animatedThreadWorker.RunWorkerAsync();
        }

        #endregion

        #region Methods

        #region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            _animatedThreadWorker.ReportProgress(0, "load templates");

            _animatedThreadWorker.ReportProgress(100, "binding complete");
        }
        #endregion

        #region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            comboBoxRoutingTaskGrouping.SelectedIndexChanged -= ComboBoxRoutingTaskGrouping_SelectedIndexChanged;
            dataGridViewItems.Rows.Clear();

            if (_workPackage == null) return;

            #region Чеки программы обслуживания и директивы программы обслуживания

            try
            {
                var checkDirectives = new List<MaintenanceDirective>();

                foreach (var maintenanceCheck in _workPackage.MaintenanceChecks)
                {
                    DataGridViewRow row;
                    DataGridViewCell discCell;
                    DataGridViewCell taskCardCell;
                    DataGridViewCell compntCell;
                    DataGridViewCell kitCell;

                    if (_workPackage.Aircraft.MSG >= MSG.MSG3)
                    {
                        MaintenanceCheckRecord mcr =
                            maintenanceCheck.PerformanceRecords.FirstOrDefault(pr => pr.DirectivePackageId == _workPackage.ItemId);
                        if (mcr != null)
                        {
                            row = new DataGridViewRow { Tag = maintenanceCheck };
                            discCell = new DataGridViewTextBoxCell
                            {
                                Value = string.IsNullOrEmpty(mcr.ComplianceCheckName)
                                         ? maintenanceCheck.Name
                                         : mcr.ComplianceCheckName
                            };
                            taskCardCell = new DataGridViewTextBoxCell { Value = "" };
                            compntCell = new DataGridViewCheckBoxCell { Value = maintenanceCheck.PrintInWorkPackage };
                            kitCell = new DataGridViewTextBoxCell();
                        }
                        else
                        {
                            if (maintenanceCheck.Grouping)
                            {
                                MaintenanceNextPerformance mnp = maintenanceCheck.GetNextPergormanceGroupWhereCheckIsSenior();
                                if (mnp != null)
                                {
                                    row = new DataGridViewRow { Tag = maintenanceCheck };
                                    discCell = new DataGridViewTextBoxCell { Value = mnp.PerformanceGroup.GetGroupName() };
                                    taskCardCell = new DataGridViewTextBoxCell { Value = "" };
                                    compntCell = new DataGridViewCheckBoxCell { Value = maintenanceCheck.PrintInWorkPackage };
                                    kitCell = new DataGridViewTextBoxCell();
                                }
                                else continue;
                            }
                            else
                            {
                                row = new DataGridViewRow { Tag = maintenanceCheck };
                                discCell = new DataGridViewTextBoxCell { Value = maintenanceCheck.Name };
                                taskCardCell = new DataGridViewTextBoxCell { Value = "" };
                                compntCell = new DataGridViewCheckBoxCell { Value = maintenanceCheck.PrintInWorkPackage };
                                kitCell = new DataGridViewTextBoxCell();
                            }
                        }
                    }
                    else
                    {
                        row = new DataGridViewRow { Tag = maintenanceCheck };
                        discCell = new DataGridViewTextBoxCell { Value = maintenanceCheck.Name };
                        taskCardCell = new DataGridViewTextBoxCell { Value = "" };
                        compntCell = new DataGridViewCheckBoxCell { Value = maintenanceCheck.PrintInWorkPackage };
                        kitCell = new DataGridViewTextBoxCell();
                    }

                    row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell, kitCell });
                    discCell.ReadOnly = true;
                    taskCardCell.ReadOnly = true;
                    kitCell.ReadOnly = true;

                    dataGridViewItems.Rows.Add(row);

                    var checkMpds =
                        (from record in _workPackage.MaintenanceCheckBindTaskRecords
                         where record.TaskType == SmartCoreType.MaintenanceDirective && record.CheckId == maintenanceCheck.ItemId
                         select record.Task as MaintenanceDirective)
                         .OrderBy(cm => cm.TaskNumberCheck)
                         .ToList();

                    checkMpds.AddRange(maintenanceCheck.BindMpds
                                           .Where(bmpd => _workPackage.WorkPakageRecords
                                                          .FirstOrDefault(r => r.WorkPackageItemType == SmartCoreType.MaintenanceDirective.ItemId
                                                                            && r.DirectiveId == bmpd.ItemId) != null));
                    checkDirectives.AddRange(checkMpds);

                    foreach (MaintenanceDirective checkMpd in checkMpds)
                    {
						//Если у checkMpd не были загружены ItemRelation,
						//то производится поиск связанных элементов по DD в рабочем пакете 
						//TODO:(Evgenii Babak) избавиться от кода
						if (checkMpd.ItemRelations.Count == 0)
                            checkMpd.ItemRelations
                                .AddRange(_workPackage.ComponentDirectives.Where(bdd => bdd.ItemRelations.IsAllRelationWith(checkMpd)).SelectMany(bdd => bdd.ItemRelations));
                        DataGridViewRow checkMpdRow = new DataGridViewRow { Tag = checkMpd };
                        DataGridViewCell checkMpdDiscCell;
                        DataGridViewCell checkMpdTaskCardCell;
                        DataGridViewCell checkMpdCompntCell;
                        DataGridViewCell checkMpdKitCell;

                        string checkMpdTaskCardCellValue;
                        Color checkMpdTaskCardCellBackColor = Color.White;

                        if (string.IsNullOrEmpty(checkMpd.TaskCardNumber) && checkMpd.TaskCardNumberFile == null)
                        {
                            checkMpdTaskCardCellValue = "Not set Task Card file.";
                            checkMpdTaskCardCellBackColor = Color.Red;
                        }
                        else if (!string.IsNullOrEmpty(checkMpd.TaskCardNumber) && checkMpd.TaskCardNumberFile == null)
                        {
                            checkMpdTaskCardCellValue =
	                            $"Not set Task Card file. (Task Card No {checkMpd.TaskCardNumber}.)";
                            checkMpdTaskCardCellBackColor = Color.Red;
                        }
                        else if (string.IsNullOrEmpty(checkMpd.TaskCardNumber) && checkMpd.TaskCardNumberFile != null)
                        {
                            checkMpdTaskCardCellValue =
	                            $"Not set Task Card name. (File name {checkMpd.TaskCardNumberFile.FileName}.)";
                            checkMpdTaskCardCellBackColor = Color.Red;
                        }
                        else checkMpdTaskCardCellValue = checkMpd.TaskCardNumber;

                        if (checkMpd.ItemRelations.Count > 0)
                        {
							//TODO:(Evgenii Babak) пересмотреть код в контесте использования связей с AD директивами
                            checkMpdDiscCell = new DataGridViewTextBoxCell { Value = $"{maintenanceCheck.Name}--{checkMpd.TaskNumberCheck} for {checkMpd.ItemRelations.Count} components"};
                            checkMpdTaskCardCell = new DataGridViewTextBoxCell
                            {
                                Value = checkMpdTaskCardCellValue,
                                Style = { BackColor = checkMpdTaskCardCellBackColor },
                            };
                            checkMpdCompntCell = new DataGridViewCheckBoxCell { Value = checkMpd.PrintInWorkPackage };
                            checkMpdKitCell = new DataGridViewComboBoxCell();
                            ((DataGridViewComboBoxCell)checkMpdKitCell).Items.AddRange(ComboBoxItemOneToOne, _comboBoxItemOneForAll);
                            checkMpdKitCell.Value = _comboBoxItemOneForAll;

                            checkMpdRow.Cells.AddRange(new[] { checkMpdDiscCell, checkMpdTaskCardCell, checkMpdCompntCell, checkMpdKitCell });

                            checkMpdDiscCell.ReadOnly = true;
                            checkMpdTaskCardCell.ReadOnly = true;
                        }
                        else
                        {
                            checkMpdDiscCell = new DataGridViewTextBoxCell { Value = maintenanceCheck.Name + "--" + checkMpd.TaskNumberCheck };
                            checkMpdTaskCardCell = new DataGridViewTextBoxCell
                            {
                                Value = checkMpdTaskCardCellValue,
                                Style = { BackColor = checkMpdTaskCardCellBackColor },
                            };
                            checkMpdCompntCell = new DataGridViewCheckBoxCell { Value = checkMpd.PrintInWorkPackage };
                            checkMpdKitCell = new DataGridViewTextBoxCell();

                            checkMpdRow.Cells.AddRange(new[] { checkMpdDiscCell, checkMpdTaskCardCell, checkMpdCompntCell, checkMpdKitCell });

                            checkMpdDiscCell.ReadOnly = true;
                            checkMpdTaskCardCell.ReadOnly = true;
                            checkMpdKitCell.ReadOnly = true;
                        }

                        dataGridViewItems.Rows.Add(checkMpdRow);
                    }
                }

                List<MaintenanceDirective> nonCheckMpds =
                    _workPackage.MaintenanceDirectives.Where(md => checkDirectives.FirstOrDefault(dd => dd.ItemId == md.ItemId) == null)
                                                      .OrderBy(md => md.TaskNumberCheck)
                                                      .ToList();

                foreach (MaintenanceDirective item in nonCheckMpds)
                {
                    string taskCardCellValue;
                    Color taskCardCellBackColor = Color.White;

                    if (string.IsNullOrEmpty(item.TaskCardNumber) && item.TaskCardNumberFile == null)
                    {
                        taskCardCellValue = "Not set Task Card file.";
                        taskCardCellBackColor = Color.Red;
                    }
                    else if (!string.IsNullOrEmpty(item.TaskCardNumber) && item.TaskCardNumberFile == null)
                    {
                        taskCardCellValue = $"Not set Task Card file. (Task Card No {item.TaskCardNumber}.)";
                        taskCardCellBackColor = Color.Red;
                    }
                    else if (string.IsNullOrEmpty(item.TaskCardNumber) && item.TaskCardNumberFile != null)
                    {
                        taskCardCellValue = $"Not set Task Card name. (File name {item.TaskCardNumberFile.FileName}.)";
                        taskCardCellBackColor = Color.Red;
                    }
                    else taskCardCellValue = item.TaskCardNumber;

                    DataGridViewRow row = new DataGridViewRow { Tag = item };
                    DataGridViewCell discCell = new DataGridViewTextBoxCell { Value = item.TaskNumberCheck };
                    DataGridViewCell taskCardCell = new DataGridViewTextBoxCell
                    {
                        Value = taskCardCellValue,
                        Style = { BackColor = taskCardCellBackColor },
                    };
                    DataGridViewCell compntCell = new DataGridViewCheckBoxCell { Value = item.PrintInWorkPackage };
                    DataGridViewCell kitCell = new DataGridViewTextBoxCell();

                    row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell, kitCell });
                    discCell.ReadOnly = true;
                    taskCardCell.ReadOnly = true;
                    kitCell.ReadOnly = true;

                    dataGridViewItems.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                string info =
	                $"Error while load WP Maintenance Checks. WPid: {_workPackage.ItemId}; WPTitle: {_workPackage.Title}";
                Program.Provider.Logger.Log(info, ex);
            }


            #endregion

            #region Директивы летной годности

            try
            {
                foreach (Directive item in _workPackage.AdStatus)
                {
                    string taskCardCellValue;
                    Color taskCardCellBackColor = Color.White;

                    if (string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile == null)
                    {
                        taskCardCellValue = "Not set Engineering Order file.";
                        taskCardCellBackColor = Color.Red;
                    }
                    else if (!string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile == null)
                    {
                        taskCardCellValue =
	                        $"Not set Engineering Order File. (Engineering Order No {item.EngineeringOrders}.)";
                        taskCardCellBackColor = Color.Red;
                    }
                    else if (string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile != null)
                    {
                        taskCardCellValue =
	                        $"Not set Engineering Order name. (File name {item.EngineeringOrderFile.FileName}.)";
                        taskCardCellBackColor = Color.Red;
                    }
                    else taskCardCellValue = item.EngineeringOrders;

                    DataGridViewRow row = new DataGridViewRow { Tag = item };

                    DataGridViewCell discCell = new DataGridViewTextBoxCell();
                    DataGridViewCell taskCardCell = new DataGridViewTextBoxCell
                    {
                        Value = taskCardCellValue,
                        Style = { BackColor = taskCardCellBackColor },
                    };
                    DataGridViewCell compntCell = new DataGridViewCheckBoxCell { Value = item.PrintInWorkPackage };
                    DataGridViewCell kitCell = new DataGridViewTextBoxCell();
                    discCell.Value = "(AD)" + item.Title + " " + item.WorkType + " §:" + item.Paragraph;

                    row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell, kitCell });

                    discCell.ReadOnly = true;
                    taskCardCell.ReadOnly = true;
                    kitCell.ReadOnly = true;

                    dataGridViewItems.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                string info =
	                $"Error while load WP AD Directives. WPid: {_workPackage.ItemId}; WPTitle: {_workPackage.Title}";
                Program.Provider.Logger.Log(info, ex);
            }

			#endregion

	        #region SB

	        try
	        {
		        foreach (Directive item in _workPackage.SbStatus)
		        {
			        string taskCardCellValue;
			        Color taskCardCellBackColor = Color.White;

			        if (string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile == null)
			        {
				        taskCardCellValue = "Not set Engineering Order file.";
				        taskCardCellBackColor = Color.Red;
			        }
			        else if (!string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile == null)
			        {
				        taskCardCellValue =
					        $"Not set Engineering Order File. (Engineering Order No {item.EngineeringOrders}.)";
				        taskCardCellBackColor = Color.Red;
			        }
			        else if (string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile != null)
			        {
				        taskCardCellValue =
					        $"Not set Engineering Order name. (File name {item.EngineeringOrderFile.FileName}.)";
				        taskCardCellBackColor = Color.Red;
			        }
			        else taskCardCellValue = item.EngineeringOrders;

			        DataGridViewRow row = new DataGridViewRow { Tag = item };

			        DataGridViewCell discCell = new DataGridViewTextBoxCell();
			        DataGridViewCell taskCardCell = new DataGridViewTextBoxCell
			        {
				        Value = taskCardCellValue,
				        Style = { BackColor = taskCardCellBackColor },
			        };
			        DataGridViewCell compntCell = new DataGridViewCheckBoxCell { Value = item.PrintInWorkPackage };
			        DataGridViewCell kitCell = new DataGridViewTextBoxCell();
			        discCell.Value = "(SB)" + item.Title + " " + item.WorkType + " §:" + item.Paragraph;

			        row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell, kitCell });

			        discCell.ReadOnly = true;
			        taskCardCell.ReadOnly = true;
			        kitCell.ReadOnly = true;

			        dataGridViewItems.Rows.Add(row);
		        }
	        }
	        catch (Exception ex)
	        {
		        string info = $"Error while load WP Sb Directives. WPid: {_workPackage.ItemId}; WPTitle: {_workPackage.Title}";
		        Program.Provider.Logger.Log(info, ex);
	        }

	        #endregion

	        #region EO

	        try
	        {
		        foreach (Directive item in _workPackage.EoStatus)
		        {
			        string taskCardCellValue;
			        Color taskCardCellBackColor = Color.White;

			        if (string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile == null)
			        {
				        taskCardCellValue = "Not set Engineering Order file.";
				        taskCardCellBackColor = Color.Red;
			        }
			        else if (!string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile == null)
			        {
				        taskCardCellValue =
					        $"Not set Engineering Order File. (Engineering Order No {item.EngineeringOrders}.)";
				        taskCardCellBackColor = Color.Red;
			        }
			        else if (string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile != null)
			        {
				        taskCardCellValue =
					        $"Not set Engineering Order name. (File name {item.EngineeringOrderFile.FileName}.)";
				        taskCardCellBackColor = Color.Red;
			        }
			        else taskCardCellValue = item.EngineeringOrders;

			        DataGridViewRow row = new DataGridViewRow { Tag = item };

			        DataGridViewCell discCell = new DataGridViewTextBoxCell();
			        DataGridViewCell taskCardCell = new DataGridViewTextBoxCell
			        {
				        Value = taskCardCellValue,
				        Style = { BackColor = taskCardCellBackColor },
			        };
			        DataGridViewCell compntCell = new DataGridViewCheckBoxCell { Value = item.PrintInWorkPackage };
			        DataGridViewCell kitCell = new DataGridViewTextBoxCell();
			        discCell.Value = "(EO)" + item.Title + " " + item.WorkType + " §:" + item.Paragraph;

			        row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell, kitCell });

			        discCell.ReadOnly = true;
			        taskCardCell.ReadOnly = true;
			        kitCell.ReadOnly = true;

			        dataGridViewItems.Rows.Add(row);
		        }
	        }
	        catch (Exception ex)
	        {
		        string info = $"Error while load WP Eo Directives. WPid: {_workPackage.ItemId}; WPTitle: {_workPackage.Title}";
		        Program.Provider.Logger.Log(info, ex);
	        }

	        #endregion

			#region Повреждения

			try
            {
                foreach (Directive item in _workPackage.Damages)
                {
                    string taskCardCellValue;
                    Color taskCardCellBackColor = Color.White;

                    if (string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile == null)
                    {
                        taskCardCellValue = "Not set Engineering Order file.";
                        taskCardCellBackColor = Color.Red;
                    }
                    else if (!string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile == null)
                    {
                        taskCardCellValue =
	                        $"Not set Engineering Order File. (Engineering Order No {item.EngineeringOrders}.)";
                        taskCardCellBackColor = Color.Red;
                    }
                    else if (string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile != null)
                    {
                        taskCardCellValue =
	                        $"Not set Engineering Order name. (File name {item.EngineeringOrderFile.FileName}.)";
                        taskCardCellBackColor = Color.Red;
                    }
                    else taskCardCellValue = item.EngineeringOrders;

                    DataGridViewRow row = new DataGridViewRow { Tag = item };

                    DataGridViewCell discCell = new DataGridViewTextBoxCell();
                    DataGridViewCell taskCardCell = new DataGridViewTextBoxCell
                    {
                        Value = taskCardCellValue,
                        Style = { BackColor = taskCardCellBackColor },
                    };
                    DataGridViewCell compntCell = new DataGridViewCheckBoxCell { Value = item.PrintInWorkPackage };
                    DataGridViewCell kitCell = new DataGridViewTextBoxCell();
                    discCell.Value = "(DRI)" + item.Title + " " + item.WorkType + " §:" + item.Paragraph;

                    row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell, kitCell });

                    discCell.ReadOnly = true;
                    taskCardCell.ReadOnly = true;
                    kitCell.ReadOnly = true;

                    dataGridViewItems.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                string info =
	                $"Error while load WP Damages. WPid: {_workPackage.ItemId}; WPTitle: {_workPackage.Title}";
                Program.Provider.Logger.Log(info, ex);
            }

            #endregion

            #region OutOfPhaseItems

            try
            {
                foreach (Directive item in _workPackage.OutOfPhaseItems)
                {
                    string taskCardCellValue;
                    Color taskCardCellBackColor = Color.White;


                    if (string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile == null)
                    {
                        taskCardCellValue = "Not set Engineering Order file.";
                        taskCardCellBackColor = Color.Red;
                    }
                    else if (!string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile == null)
                    {
                        taskCardCellValue =
	                        $"Not set Engineering Order File. (Engineering Order No {item.EngineeringOrders}.)";
                        taskCardCellBackColor = Color.Red;
                    }
                    else if (string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile != null)
                    {
                        taskCardCellValue =
	                        $"Not set Engineering Order name. (File name {item.EngineeringOrderFile.FileName}.)";
                        taskCardCellBackColor = Color.Red;
                    }
                    else taskCardCellValue = item.EngineeringOrders;

                    DataGridViewRow row = new DataGridViewRow { Tag = item };

                    DataGridViewCell discCell = new DataGridViewTextBoxCell();
                    DataGridViewCell taskCardCell = new DataGridViewTextBoxCell
                    {
                        Value = taskCardCellValue,
                        Style = { BackColor = taskCardCellBackColor },
                    };
                    DataGridViewCell compntCell = new DataGridViewCheckBoxCell { Value = item.PrintInWorkPackage };
                    DataGridViewCell kitCell = new DataGridViewTextBoxCell();
                    discCell.Value = "(OP)" + item.Title + " " + item.WorkType + " §:" + item.Paragraph;

                    row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell, kitCell });

                    discCell.ReadOnly = true;
                    taskCardCell.ReadOnly = true;
                    kitCell.ReadOnly = true;

                    dataGridViewItems.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                string info =
	                $"Error while load WP Out of Phases. WPid: {_workPackage.ItemId}; WPTitle: {_workPackage.Title}";
                Program.Provider.Logger.Log(info, ex);
            }

            #endregion

            #region Отложенные дефекты

            try
            {
                foreach (Directive item in _workPackage.DefferedItems)
                {
                    string taskCardCellValue;
                    Color taskCardCellBackColor = Color.White;

                    if (string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile == null)
                    {
                        taskCardCellValue = "Not set Engineering Order file.";
                        taskCardCellBackColor = Color.Red;
                    }
                    else if (!string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile == null)
                    {
                        taskCardCellValue =
	                        $"Not set Engineering Order File. (Engineering Order No {item.EngineeringOrders}.)";
                        taskCardCellBackColor = Color.Red;
                    }
                    else if (string.IsNullOrEmpty(item.EngineeringOrders) && item.EngineeringOrderFile != null)
                    {
                        taskCardCellValue =
	                        $"Not set Engineering Order name. (File name {item.EngineeringOrderFile.FileName}.)";
                        taskCardCellBackColor = Color.Red;
                    }
                    else taskCardCellValue = item.EngineeringOrders;

                    DataGridViewRow row = new DataGridViewRow { Tag = item };

                    DataGridViewCell discCell = new DataGridViewTextBoxCell();
                    DataGridViewCell taskCardCell = new DataGridViewTextBoxCell
                    {
                        Value = taskCardCellValue,
                        Style = { BackColor = taskCardCellBackColor },
                    };
                    DataGridViewCell compntCell = new DataGridViewCheckBoxCell { Value = item.PrintInWorkPackage };
                    DataGridViewCell kitCell = new DataGridViewTextBoxCell();
                    discCell.Value = "(DI)" + item.Title + " " + item.WorkType + " §:" + item.Paragraph;

                    row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell, kitCell });

                    discCell.ReadOnly = true;
                    taskCardCell.ReadOnly = true;
                    kitCell.ReadOnly = true;

                    dataGridViewItems.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                string info =
	                $"Error while load WP Deferreds. WPid: {_workPackage.ItemId}; WPTitle: {_workPackage.Title}";
                Program.Provider.Logger.Log(info, ex);
            }

            #endregion

            #region Компоненты и задачи по компонентам

            try
            {
                var componentDirectives = _workPackage.ComponentDirectives.ToList();
                foreach (Component item in _workPackage.Components)
                {
                    var dds = componentDirectives.Where(dd => dd.ParentComponent != null &&
														   dd.ParentComponent.ItemId == item.ItemId).ToList();

                    foreach (var componentDirective in dds)
                    {
                        componentDirectives.Remove(componentDirective);
                    }

					var row = new DataGridViewRow { Tag = item };

					var discCell = new DataGridViewTextBoxCell();
					var taskCardCell = new DataGridViewTextBoxCell();
					var compntCell = new DataGridViewCheckBoxCell { Value = item.PrintInWorkPackage };
					var kitCell = new DataGridViewTextBoxCell();
                    discCell.Value = "Comp:" + item.Description + " P/N:" + item.PartNumber + " S/N:" + item.SerialNumber;

                    row.Cells.AddRange(discCell, taskCardCell, compntCell, kitCell);

                    discCell.ReadOnly = true;
                    taskCardCell.ReadOnly = true;
                    kitCell.ReadOnly = true;

                    dataGridViewItems.Rows.Add(row);

                }
				foreach (var item in _workPackage.BaseComponents)
				{
					var dds = componentDirectives.Where(dd => dd.ParentComponent != null &&
													       dd.ParentComponent.ItemId == item.ItemId).ToList();

					foreach (var detailDirective in dds)
						componentDirectives.Remove(detailDirective);

					var row = new DataGridViewRow { Tag = item };

					var discCell = new DataGridViewTextBoxCell();
					var taskCardCell = new DataGridViewTextBoxCell();
					var compntCell = new DataGridViewCheckBoxCell { Value = item.PrintInWorkPackage };
					var kitCell = new DataGridViewTextBoxCell();
					discCell.Value = "CCO:" + item.Description + " " + item.PartNumber + " " + item.SerialNumber;

					row.Cells.AddRange(discCell, taskCardCell, compntCell, kitCell);

					discCell.ReadOnly = true;
					taskCardCell.ReadOnly = true;
					kitCell.ReadOnly = true;

					dataGridViewItems.Rows.Add(row);

                }
                foreach (ComponentDirective item in componentDirectives)
                {
                    var d = item.ParentComponent;
					var row = new DataGridViewRow { Tag = item };

					string taskCardCellValue;
					var taskCardCellBackColor = Color.White;
					var mpd = item.MaintenanceDirective;
					if (string.IsNullOrEmpty(mpd?.TaskCardNumber) && mpd?.TaskCardNumberFile == null)
					{
						taskCardCellValue = "Not set Task Card file.";
						taskCardCellBackColor = Color.Red;
					}
					else if (!string.IsNullOrEmpty(mpd?.TaskCardNumber) && mpd?.TaskCardNumberFile == null)
					{
						taskCardCellValue = $"Not set Task Card file. (Task Card No {mpd.TaskCardNumber}.)";
						taskCardCellBackColor = Color.Red;
					}
					else if (string.IsNullOrEmpty(mpd?.TaskCardNumber) && mpd?.TaskCardNumberFile != null)
					{
						taskCardCellValue = $"Not set Task Card name. (File name {mpd.TaskCardNumberFile.FileName}.)";
						taskCardCellBackColor = Color.Red;
					}
					else taskCardCellValue = mpd.TaskCardNumber;


					var discCell = new DataGridViewTextBoxCell();
					DataGridViewCell taskCardCell = new DataGridViewTextBoxCell
					{
						Value = taskCardCellValue,
						Style = { BackColor = taskCardCellBackColor },
					};
					var compntCell = new DataGridViewCheckBoxCell { Value = item.PrintInWorkPackage };
					var kitCell = new DataGridViewTextBoxCell();
                    discCell.Value = $"Comp: {mpd?.TaskNumberCheck} " + item.DirectiveType + " for " + d.Description + " P/N:" + d.PartNumber + " S/N:" + d.SerialNumber;

                    row.Cells.AddRange(discCell, taskCardCell, compntCell, kitCell);

                    discCell.ReadOnly = true;
                    taskCardCell.ReadOnly = true;
                    kitCell.ReadOnly = true;

                    dataGridViewItems.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                string info =
	                $"Error while load WP Detail Directives. WPid: {_workPackage.ItemId}; WPTitle: {_workPackage.Title}";
                Program.Provider.Logger.Log(info, ex);
            }

            #endregion

            #region Нерутинные задачи

            try
            {
                foreach (NonRoutineJob item in _workPackage.NonRoutines)
                {
                    DataGridViewRow row = new DataGridViewRow { Tag = item };

                    DataGridViewCell discCell = new DataGridViewTextBoxCell { Value = "(Non-Routine)" + item.Title };
                    DataGridViewCell taskCardCell = new DataGridViewTextBoxCell();
                    DataGridViewCell compntCell = new DataGridViewCheckBoxCell { Value = item.PrintInWorkPackage };
                    DataGridViewCell kitCell = new DataGridViewTextBoxCell();

                    row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell, kitCell });

                    discCell.ReadOnly = true;
                    taskCardCell.ReadOnly = true;
                    kitCell.ReadOnly = true;

                    dataGridViewItems.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                string info =
	                $"Error while load WP Non-Routines. WPid: {_workPackage.ItemId}; WPTitle: {_workPackage.Title}";
                Program.Provider.Logger.Log(info, ex);
            }
            #endregion

            var list = new List<KeyValuePair<string, WorkPackageRoutineTasksGrouping>>();
            foreach (WorkPackageRoutineTasksGrouping engineUtilization in Enum.GetValues(typeof(WorkPackageRoutineTasksGrouping)))
            {
                string name = Enum.GetName(typeof(WorkPackageRoutineTasksGrouping), engineUtilization);
                string desc = name;
                FieldInfo fi = typeof(WorkPackageRoutineTasksGrouping).GetField(name);
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    string s = attributes[0].Description;
                    if (!string.IsNullOrEmpty(s))
                    {
                        desc = s;
                    }
                }
                list.Add(new KeyValuePair<string, WorkPackageRoutineTasksGrouping>(desc, engineUtilization));
            }
            comboBoxRoutingTaskGrouping.DisplayMember = "Key";
            comboBoxRoutingTaskGrouping.ValueMember = "Value";
            comboBoxRoutingTaskGrouping.DataSource = list;
            comboBoxRoutingTaskGrouping.SelectedIndexChanged += ComboBoxRoutingTaskGrouping_SelectedIndexChanged;
        }
        #endregion

        #region private void AnimatedThreadWorkerDoCreate(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoCreate(object sender, DoWorkEventArgs e)
        {
            _animatedThreadWorker.ReportProgress(0, "Save print settings");

            Save();
            
            ConcatenatePDFDocuments();

            _animatedThreadWorker.ReportProgress(100, "Create Complete");
        }
        #endregion

        #region private void BackgroundWorkerRunWorkerCreateCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void BackgroundWorkerRunWorkerCreateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_outputDocument != null && _outputDocument.PageCount >= 1)
            {
	            var timeofDay = DateTime.Now.TimeOfDay;
				string fileNameString =
					$"{Path.GetTempPath() + "tempWpPreviewFile"}{timeofDay.Hours}{timeofDay.Minutes}{timeofDay.Seconds}.pdf";
                _outputDocument.Save(fileNameString);
				_outputDocument.Close();
				_outputDocument = null;
                Process tempProcess = new Process();
                tempProcess.StartInfo.FileName = fileNameString;
                tempProcess.Start();

				//TODO : Нужно изменить подход с работой временных файлов здесь. Он должен быть централизованным
				//try
				//{
				//	tempProcess.WaitForExit();
				//}
				//catch (Exception ex)
				//{
				//	Program.Provider.Logger.Log(ex);
				//}

				//var canClose = false;
				//for (int i = 0; i < 3; i++)
				//{
				//	try
				//	{
				//		File.Delete(fileNameString);
				//		canClose = true;
				//	}
				//	catch
				//	{
				//		Thread.Sleep(100 + i * 100);
				//	}
				//}
				//if (canClose)
				//{
				//	_outputDocument.Close();
				//	_outputDocument = null;
				//}
            }
            else
            {
                MessageBox.Show("exist not pages jobcard");
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region private void ConcatenatePDFDocuments()
        /// <summary>
        /// This sample adds a consecutive number in the middle of each page.
        /// It shows how you can add graphics to an imported page.
        /// </summary>
        private void ConcatenatePDFDocuments()
        {
            var selectedChecks = new List<MaintenanceCheck>(_workPackage.MaintenanceChecks);
            var selectedMpds = new List<MaintenanceDirective>(_workPackage.MaintenanceDirectives);
            if (selectedChecks.Count > 0)
            {
                selectedMpds.AddRange(selectedChecks
                                          .SelectMany(check => _workPackage.MaintenanceCheckBindTaskRecords
                                                                   .Where(record => record.CheckId == check.ItemId &&
                                                                                    record.TaskType == SmartCoreType.MaintenanceDirective))
                                          .Select(record => record.Task as MaintenanceDirective));
            }
			selectedMpds.AddRange(from record in _workPackage.MaintenanceCheckBindTaskRecords
								  where record.TaskType == SmartCoreType.MaintenanceDirective
								  select record.Task as MaintenanceDirective);
			selectedMpds = selectedMpds.Distinct().OrderBy(cm => cm.TaskNumberCheck).ToList();
            var selectedADs = new List<Directive>(_workPackage.AdStatus);
            var selectedSBs = new List<Directive>(_workPackage.SbStatus);
            var selectedEOs = new List<Directive>(_workPackage.EoStatus);
            var selectedDamages = new List<Directive>(_workPackage.Damages);
            var selectedOofs = new List<Directive>(_workPackage.OutOfPhaseItems);
            var selectedDeffereds = new List<Directive>(_workPackage.DefferedItems);
            var selectedComponentDirectives = new List<ComponentDirective>(_workPackage.ComponentDirectives);
            var selectedComponents = new List<Component>(_workPackage.Components);
            var selectedBaseComponents = new List<BaseComponent>(_workPackage.BaseComponents);
            var selectedNrjs = new List<NonRoutineJob>(_workPackage.NonRoutines);

            _animatedThreadWorker.ReportProgress(10, "Selecting Items");

            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (row.Cells.Count < 3 || !(row.Cells[2] is DataGridViewCheckBoxCell))continue;
                var printCell = (DataGridViewCheckBoxCell)row.Cells[2];
                if ((bool) printCell.Value)
                {
                    if (row.Tag is MaintenanceDirective)
                    {
                        if (row.Cells.Count < 4 || !(row.Cells[3] is DataGridViewComboBoxCell))
                            continue;
                        //Если директива программы обслуживания имеет связные с ней задачи по 
                        //компонентам и Выбрана для распечатки,
                        //то нужно определить, сколько копий директивы надо включить в распечатку
                        //1. По одной на каждую связную задачу по компоненту
                        //2. Одну на все связные задачи по компонентам
                        MaintenanceDirective directive = selectedMpds.FirstOrDefault(sm => sm.ItemId == (row.Tag as MaintenanceDirective).ItemId);
                        if (directive != null)
                        {
                            var countCell = (DataGridViewComboBoxCell)row.Cells[3];
                            if (countCell.EditedFormattedValue.ToString() == ComboBoxItemOneToOne)
                                directive.CountForPrint = directive.ItemRelations.Count;
                            else if (countCell.EditedFormattedValue.ToString() == _comboBoxItemOneForAll)
                                directive.CountForPrint = 1;
                        }
                    }
                    continue;
                }

                
                if (row.Tag is MaintenanceCheck)
                {
                    //Если чек  программы обслуживания не выбран для распечатки,
                    //то его нужно исключить из результирующей коллекции для распечатки 
                    var check = row.Tag as MaintenanceCheck;
                    selectedChecks.Remove(check);

                    if (check.Grouping)
                    {
                        MaintenanceNextPerformance mnp = check.GetNextPergormanceGroupWhereCheckIsSenior();
                        if (mnp != null && mnp.PerformanceGroup != null && mnp.PerformanceGroup.Checks.Count > 0
                            && _workPackage.Aircraft != null && _workPackage.Aircraft.MSG == MSG.MSG3)
                        {
                            foreach (MaintenanceCheck mc in mnp.PerformanceGroup.Checks)
                            {
                                RemoveMaintenanceCheckTask(mc, selectedMpds);
                            }
                        }
                        else
                        {
                            RemoveMaintenanceCheckTask(check, selectedMpds);
                        }
                    }
                    else
                    {
                        RemoveMaintenanceCheckTask(check, selectedMpds);
                    }
                }

                else if (row.Tag is MaintenanceDirective)
                {
                    //Если директива программы обслуживания не выбрана для распечатки,
                    //то ее нужно исключить из результирующей коллекции для распечатки 
                    MaintenanceDirective directive =
                        selectedMpds.FirstOrDefault(sm => sm.ItemId == (row.Tag as MaintenanceDirective).ItemId);
                    if (directive != null)
                        selectedMpds.Remove(directive);
                }

                //Выборка Директив летной годности
                else if (row.Tag is Directive)
                {
                    var directive = row.Tag as Directive;

                    if (directive.DirectiveType == DirectiveType.AirworthenessDirectives)
                        selectedADs.Remove(directive);
                    if (directive.DirectiveType == DirectiveType.DamagesRequiring)
                        selectedDamages.Remove(directive);
                    if (directive.DirectiveType == DirectiveType.DeferredItems)
                        selectedDeffereds.Remove(directive);
                    if (directive.DirectiveType == DirectiveType.OutOfPhase)
                        selectedOofs.Remove(directive);
					if (directive.DirectiveType == DirectiveType.SB)
						selectedSBs.Remove(directive);
					if (directive.DirectiveType == DirectiveType.EngineeringOrders)
						selectedEOs.Remove(directive);
				}
                //Выборка Задач по компонентам
                else if (row.Tag is ComponentDirective)
                    selectedComponentDirectives.Remove(row.Tag as ComponentDirective);
                //Выборка компонентов
                else if (row.Tag is Component)
                    selectedComponents.Remove(row.Tag as Component);
				else if (row.Tag is BaseComponent)
	                selectedBaseComponents.Remove(row.Tag as BaseComponent);
                //Выборка нерутинных работ
                else if (row.Tag is NonRoutineJob)
                    selectedNrjs.Remove(row.Tag as NonRoutineJob);
            }

            var tempFiles = new List<AttachedFile>();

            //выходной документ
            if(_outputDocument == null)
                _outputDocument = new PdfDocument();

            _animatedThreadWorker.ReportProgress(35, "Formation of items");

            #region Формирование данных главной страницы и листа перечьня работ - "название/тип"

            bool haveDaily = false;
            bool haveWeekly = false;
            var mainPageItems = new List<KeyValuePair<string, string>>();
            var titlePageItems = new List<KeyValuePair<string, int>>();
            var crsPageItems = new List<KeyValuePair<string, int>>();
            var summarySheetItems = new List<string[]>();

            var nonDuplicatedFiles = new List<AttachedFile>();
            var dailyCheckFiles = new List<AttachedFile>();
            var weeklyCheckFiles = new List<AttachedFile>();
            var dailyCheckDirectives = new List<MaintenanceDirective>();
            var weeklyCheckDirectives = new List<MaintenanceDirective>();
            int countOfDaylyWeeklyPages = 0;
            int taskCardsCount = 0;

            foreach (MaintenanceCheck item in selectedChecks)
            {
                var checkMpds = new List<MaintenanceDirective>();
                checkMpds.AddRange(_workPackage.MaintenanceCheckBindTaskRecords
                                        .Where( record => record.TaskType == SmartCoreType.MaintenanceDirective && record.CheckId == item.ItemId)
                                        .Select(record => selectedMpds.FirstOrDefault(m => m.ItemId == record.TaskId))
                                        .Where(cm => cm != null)
                                        .OrderBy(cm => cm.TaskNumberCheck));
                checkMpds.AddRange(selectedMpds.Where(mpd => mpd.MaintenanceCheck != null && mpd.MaintenanceCheck.ItemId == item.ItemId));
                //}
                
                int checkMpdCount = 0;
                
                foreach (MaintenanceDirective mpd in checkMpds)
                {
                    AttachedFile mpdAttachedFile = mpd.TaskCardNumberFile;
                    if (mpdAttachedFile == null)
                        continue;
                    if (!checkBoxPrintDupliates.Checked)
                    {
                        if(nonDuplicatedFiles.FirstOrDefault(af => af.ItemId == mpdAttachedFile.ItemId
                                                                || af.FileName == mpdAttachedFile.FileName) != null)
                        {
                            continue;
                        }
                        nonDuplicatedFiles.Add(mpdAttachedFile);
                    }

                    PdfDocument inputDocument = GetPDFDocument(mpdAttachedFile);

                    if (inputDocument == null)
                        continue;
                    // Iterate pages
                    checkMpdCount += inputDocument.PageCount;
                }

                string checkNameLower = item.Name.ToLower();
                if (checkNameLower == "dy" || checkNameLower == "daily")
                {
                    dailyCheckFiles.AddRange(checkMpds.Where(c => c.TaskCardNumberFile != null).Select(c => c.TaskCardNumberFile));
                    dailyCheckDirectives.AddRange(checkMpds);
                    countOfDaylyWeeklyPages += checkMpdCount;

                    if (haveWeekly)
                    {
                        mainPageItems.Insert(mainPageItems.Count - 1, new KeyValuePair<string, string>(item.Name, checkMpdCount.ToString()));
                        crsPageItems.Insert(crsPageItems.Count - 1, new KeyValuePair<string, int>("pages of Daily Check.", checkMpdCount));
                    }
                    else
                    {
                        mainPageItems.Add(new KeyValuePair<string, string>(item.Name, checkMpdCount.ToString()));
                        crsPageItems.Add(new KeyValuePair<string, int>("pages of Daily Check.", checkMpdCount));
                    }
                    haveDaily = true;
                }
                else if (checkNameLower == "wy" || checkNameLower == "weekly")
                {
                    weeklyCheckFiles.AddRange(checkMpds.Where(c => c.TaskCardNumberFile != null).Select(c => c.TaskCardNumberFile));
                    weeklyCheckDirectives.AddRange(checkMpds);
                    countOfDaylyWeeklyPages += checkMpdCount;
                    //WeeklyCheck всегда должен быть в конце
                    mainPageItems.Add(new KeyValuePair<string, string>(item.Name, checkMpdCount.ToString()));
                    crsPageItems.Add(new KeyValuePair<string, int>("pages of Weekly Check.", checkMpdCount));
                    haveWeekly = true;
                }
                else
                {
                    taskCardsCount += checkMpdCount;
                    //tempFiles.AddRange(checkMpds.Where(c => c.TaskCardNumberFile != null).Select(c => c.TaskCardNumberFile));
                }
            }
            if(taskCardsCount > 0)
            {
                mainPageItems.Insert(0, new KeyValuePair<string, string>("Task cards", taskCardsCount.ToString()));
                titlePageItems.Insert(0, new KeyValuePair<string, int>("Task cards", taskCardsCount));
                crsPageItems.Insert(0, new KeyValuePair<string, int>("pages of task cards", taskCardsCount));
            }

            int shiftFromEnd = 0;
            if (haveDaily && haveWeekly)
            {
                shiftFromEnd = 2;
                titlePageItems.Add(new KeyValuePair<string, int>("DY, WY check", countOfDaylyWeeklyPages));
            }
            else if (haveDaily)
            {
                shiftFromEnd = 1;
                titlePageItems.Add(new KeyValuePair<string, int>("DY check", countOfDaylyWeeklyPages));
            }
            else if (haveWeekly)
            {
                shiftFromEnd = 1;
                titlePageItems.Add(new KeyValuePair<string, int>("WY check", countOfDaylyWeeklyPages));
            }

            #region Maintenance Directives

            List<MaintenanceDirective> bindedMpds = _workPackage.MaintenanceChecks.SelectMany(mc => mc.BindMpds).ToList();
            List<MaintenanceDirective> nonCheckMpds = new List<MaintenanceDirective>();
            List<MaintenanceDirective> nonDailyWeeklyDirectives =
                selectedMpds.Where(md => dailyCheckDirectives.FirstOrDefault(dd => dd.ItemId == md.ItemId) == null &&
                                         weeklyCheckDirectives.FirstOrDefault(wd => wd.ItemId == md.ItemId) == null)
                          .OrderBy(md => md.TaskNumberCheck)
                          .ToList();

			List<MaintenanceDirective> nonDailyWeeklyDirectiveAfterGrouping;
			// TODO: Фикс если вынести этот код в отдельный метод то он не вернет ни каких результатов(не понятно почему)
			switch (_comboBoxGroupingSelectedValue)
			{
				case WorkPackageRoutineTasksGrouping.None:
					nonDailyWeeklyDirectiveAfterGrouping = nonDailyWeeklyDirectives;
					break;
				case WorkPackageRoutineTasksGrouping.Zone:
					nonDailyWeeklyDirectiveAfterGrouping = nonDailyWeeklyDirectives.OrderBy(mpd => string.IsNullOrEmpty(mpd.Zone) ? "zzzzz" : mpd.Zone.Split(' ')[0]).ToList();
					break;
				case WorkPackageRoutineTasksGrouping.Access:
					nonDailyWeeklyDirectiveAfterGrouping = nonDailyWeeklyDirectives.OrderBy(mpd => string.IsNullOrEmpty(mpd.Access) ? "zzzzz" : mpd.Access.Split(' ')[0]).ToList();
					break;
				case WorkPackageRoutineTasksGrouping.Program:
					nonDailyWeeklyDirectiveAfterGrouping = nonDailyWeeklyDirectives.OrderBy(mpd => mpd.Program.FullName).ToList();
					break;
				case WorkPackageRoutineTasksGrouping.WorkType:
					nonDailyWeeklyDirectiveAfterGrouping = nonDailyWeeklyDirectives.OrderBy(mpd => mpd.WorkType.FullName).ToList();
					break;
				case WorkPackageRoutineTasksGrouping.ATA:
					nonDailyWeeklyDirectiveAfterGrouping = nonDailyWeeklyDirectives.OrderBy(mpd => mpd.ATAChapter.ShortName).ToList();
					break;
				case WorkPackageRoutineTasksGrouping.Check:
					nonDailyWeeklyDirectiveAfterGrouping = nonDailyWeeklyDirectives
						.OrderBy(mpd => mpd.MaintenanceCheck?.Interval.Hours ?? Int32.MaxValue)
						.ThenBy(mpd => mpd.MaintenanceCheck?.CheckType.Priority ?? Int32.MaxValue).ToList();
						 break;
				default:
					throw new NotSupportedException("This type of grouping not supported yet");
			}


			foreach (MaintenanceDirective item in nonDailyWeeklyDirectiveAfterGrouping)
            {
                if (_workPackage.MaintenanceCheckBindTaskRecords.FirstOrDefault(r => r.TaskId == item.ItemId &&
                                                                                     r.TaskType == item.SmartCoreObjectType) == null &&
                    bindedMpds.FirstOrDefault(bm => bm.ItemId == item.ItemId) == null)
                {
                    nonCheckMpds.Add(item);
                }

                //string taskCardString;
                //if (item.TaskCardNumber != "")
                //{
                //    string s = item.TaskCardNumber.Split(' ', '-').FirstOrDefault();
                //    if (s != null && s.ToLower() == "see")
                //    {
                //        //Если рабочая карта данного элемента MPD ссылается на рабочую карту другого элемента
                //        //то в AccountabilitySheet выводится название данного элемента
                //        taskCardString = item.TaskNumberCheck;
                //    }
                //    else taskCardString = item.TaskCardNumber;
                //}
                //else taskCardString = "*";

                string taskCardString = item.TaskCardNumber != "" ? item.TaskCardNumber : "*";

                summarySheetItems.Add(new[]
                                            {item.TaskNumberCheck ,
                                             item.Description.Replace("\r\n",  " "),
                                             item.ATAChapter.ToString(),
                                             item.WorkType.ToString(),
	                                            taskCardString,
                                             "MPD Items", "Routine Tasks"});
                if (item.TaskCardNumberFile == null)
                    continue;
                tempFiles.Add(item.TaskCardNumberFile);
            }

            int pagesCount = 0;
            foreach (MaintenanceDirective mpd in nonCheckMpds)
            {
                AttachedFile item = mpd.TaskCardNumberFile;

                if (item == null)
                    continue;
                if (!checkBoxPrintDupliates.Checked)
                {
                    if (nonDuplicatedFiles.FirstOrDefault(af => af.ItemId == item.ItemId || 
                                                                af.FileName == item.FileName) != null)
                    {
                        continue;
                    }
                    nonDuplicatedFiles.Add(item);
                }

                PdfDocument inputDocument = GetPDFDocument(item);
				
                if (inputDocument == null)
                    continue;
                // Iterate pages
                pagesCount += inputDocument.PageCount;
            }
            if (pagesCount > 0)
            {
                if (shiftFromEnd > 0)
                {
                    mainPageItems.Insert(mainPageItems.Count - shiftFromEnd, new KeyValuePair<string, string>("AMP", pagesCount.ToString()));
                    titlePageItems.Insert(titlePageItems.Count - 1, new KeyValuePair<string, int>("AMP", pagesCount));
                    crsPageItems.Insert(crsPageItems.Count - shiftFromEnd, new KeyValuePair<string, int>("pages of AMP", pagesCount));
                }
                else
                {
                    mainPageItems.Add(new KeyValuePair<string, string>("AMP", pagesCount.ToString()));
                    titlePageItems.Add(new KeyValuePair<string, int>("AMP", pagesCount));
                    crsPageItems.Add(new KeyValuePair<string, int>("pages of AMP", pagesCount));
                }
            }

            #endregion

            pagesCount = 0;
            foreach (Directive item in selectedADs)
            {
                string directiveString = item.Title + (string.IsNullOrEmpty(item.Paragraph) ? "" : (" § " + item.Paragraph));
                string taskCardString = item.EngineeringOrders != "" ? item.EngineeringOrders : "*";
                summarySheetItems.Add(new[]
                                              {directiveString, 
                                               item.Description,
                                               item.ATAChapter.ToString(),
                                               item.WorkType.ToString(),
                                               taskCardString,
                                               DirectiveType.AirworthenessDirectives.ShortName, "Additional Work"});
                AttachedFile file = item.EngineeringOrderFile;
                if (file == null)
                    continue;
                if (!checkBoxPrintDupliates.Checked)
                {
                    if (nonDuplicatedFiles.FirstOrDefault(af => af.ItemId == file.ItemId || 
                                                                af.FileName == file.FileName) != null)
                    {
                        continue;
                    }
                    nonDuplicatedFiles.Add(file);
                }
                tempFiles.Add(file);

                PdfDocument inputDocument = GetPDFDocument(file);

                if (inputDocument == null)
                    continue;
                // Iterate pages
                pagesCount += inputDocument.PageCount;
            }
            if (selectedADs.Count > 0)
            {
                if (shiftFromEnd > 0)
                {
                    mainPageItems.Insert(mainPageItems.Count - shiftFromEnd, new KeyValuePair<string, string>("Engineering Orders", pagesCount.ToString()));
                    titlePageItems.Insert(titlePageItems.Count - 1, new KeyValuePair<string, int>("Engineering Orders", pagesCount));
                    crsPageItems.Insert(crsPageItems.Count - shiftFromEnd, new KeyValuePair<string, int>("pages of Engineering Orders.", pagesCount));
                }
                else
                {
                    mainPageItems.Add(new KeyValuePair<string, string>("Engineering Orders", pagesCount.ToString()));
                    titlePageItems.Add(new KeyValuePair<string, int>("Engineering Orders", pagesCount));
                    crsPageItems.Add(new KeyValuePair<string, int>("pages of Engineering Orders.", pagesCount));
                }
            }


			foreach (Directive item in selectedEOs)
			{
				string directiveString = "EO" + (string.IsNullOrEmpty(item.Paragraph) ? "" : (" § " + item.Paragraph));
				string taskCardString = item.EngineeringOrders != "" ? item.EngineeringOrders : "*";
				summarySheetItems.Add(new[]
											  {directiveString,
											   item.Description,
											   item.ATAChapter.ToString(),
											   item.WorkType.ToString(),
											   taskCardString,
											   DirectiveType.EngineeringOrders.ShortName, "Additional Work"});
				AttachedFile file = item.EngineeringOrderFile;
				if (file == null)
					continue;
				if (!checkBoxPrintDupliates.Checked)
				{
					if (nonDuplicatedFiles.FirstOrDefault(af => af.ItemId == file.ItemId ||
																af.FileName == file.FileName) != null)
					{
						continue;
					}
					nonDuplicatedFiles.Add(file);
				}
				tempFiles.Add(file);

				PdfDocument inputDocument = GetPDFDocument(file);

				if (inputDocument == null)
					continue;
				// Iterate pages
				pagesCount += inputDocument.PageCount;
			}
			if (selectedEOs.Count > 0)
			{
				if (shiftFromEnd > 0)
				{
					mainPageItems.Insert(mainPageItems.Count - shiftFromEnd, new KeyValuePair<string, string>("Engineering Orders", pagesCount.ToString()));
					titlePageItems.Insert(titlePageItems.Count - 1, new KeyValuePair<string, int>("Engineering Orders", pagesCount));
					crsPageItems.Insert(crsPageItems.Count - shiftFromEnd, new KeyValuePair<string, int>("pages of Engineering Orders.", pagesCount));
				}
				else
				{
					mainPageItems.Add(new KeyValuePair<string, string>("Engineering Orders", pagesCount.ToString()));
					titlePageItems.Add(new KeyValuePair<string, int>("Engineering Orders", pagesCount));
					crsPageItems.Add(new KeyValuePair<string, int>("pages of Engineering Orders.", pagesCount));
				}
			}

			foreach (Directive item in selectedSBs)
			{
				string directiveString = "SB" + (string.IsNullOrEmpty(item.Paragraph) ? "" : (" § " + item.Paragraph));
				string taskCardString = item.EngineeringOrders != "" ? item.EngineeringOrders : "*";
				summarySheetItems.Add(new[]
											  {directiveString,
											   item.Description,
											   item.ATAChapter.ToString(),
											   item.WorkType.ToString(),
											   taskCardString,
											   DirectiveType.SB.ShortName, "Additional Work"});
				AttachedFile file = item.EngineeringOrderFile;
				if (file == null)
					continue;
				if (!checkBoxPrintDupliates.Checked)
				{
					if (nonDuplicatedFiles.FirstOrDefault(af => af.ItemId == file.ItemId ||
																af.FileName == file.FileName) != null)
					{
						continue;
					}
					nonDuplicatedFiles.Add(file);
				}
				tempFiles.Add(file);

				PdfDocument inputDocument = GetPDFDocument(file);

				if (inputDocument == null)
					continue;
				// Iterate pages
				pagesCount += inputDocument.PageCount;
			}
			if (selectedSBs.Count > 0)
			{
				if (shiftFromEnd > 0)
				{
					mainPageItems.Insert(mainPageItems.Count - shiftFromEnd, new KeyValuePair<string, string>("Engineering Orders", pagesCount.ToString()));
					titlePageItems.Insert(titlePageItems.Count - 1, new KeyValuePair<string, int>("Engineering Orders", pagesCount));
					crsPageItems.Insert(crsPageItems.Count - shiftFromEnd, new KeyValuePair<string, int>("pages of Engineering Orders.", pagesCount));
				}
				else
				{
					mainPageItems.Add(new KeyValuePair<string, string>("Engineering Orders", pagesCount.ToString()));
					titlePageItems.Add(new KeyValuePair<string, int>("Engineering Orders", pagesCount));
					crsPageItems.Add(new KeyValuePair<string, int>("pages of Engineering Orders.", pagesCount));
				}
			}


			foreach (Directive item in selectedDamages)
            {
                DamageItem damage = (DamageItem)item;
                KeyValuePair<string, string> newkp = new KeyValuePair<string, string>(damage.Title
                            + " " + item.WorkType + " §:" + item.Paragraph, DirectiveType.DamagesRequiring.ShortName);
                string directiveString = damage.Title + (string.IsNullOrEmpty(item.Paragraph) ? "" : (" § " + item.Paragraph));
                string taskCardString = item.EngineeringOrders != "" ? item.EngineeringOrders : "*";
                summarySheetItems.Add(new[]
                                              {directiveString,
                                             damage.Title + " " + damage.Description,
                                             damage.ATAChapter.ToString(),
                                             item.WorkType.ToString(),
                                             taskCardString,
                                             DirectiveType.DamagesRequiring.ShortName, "Additional Work"});
                if (shiftFromEnd > 0)
                {
                    mainPageItems.Insert(mainPageItems.Count - shiftFromEnd, newkp);
                    //titlePageItems.Insert(titlePageItems.Count - shiftFromEnd, newkp);
                }
                else
                {
                    mainPageItems.Add(newkp);
                    //titlePageItems.Add(newkp);
                }
            }
            foreach (Directive item in selectedOofs)
            {
                KeyValuePair<string, string> newkp = new KeyValuePair<string, string>(item.Title
                            + " " + item.WorkType + " §:" + item.Paragraph, DirectiveType.OutOfPhase.ShortName);
                string directiveString = item.Title + (string.IsNullOrEmpty(item.Paragraph) ? "" : (" § " + item.Paragraph));
                string taskCardString = item.EngineeringOrders != "" ? item.EngineeringOrders : "*";
                summarySheetItems.Add(new[]
                                              {directiveString,
                                               item.Title +" "+item.Description,
                                               item.ATAChapter.ToString(),
                                               item.WorkType.ToString(),
                                               taskCardString,
                                               DirectiveType.OutOfPhase.ShortName, "Additional Work"});
                if (shiftFromEnd > 0)
                {
                    mainPageItems.Insert(mainPageItems.Count - shiftFromEnd, newkp);
                    //titlePageItems.Insert(titlePageItems.Count - shiftFromEnd, newkp);
                }
                else
                {
                    mainPageItems.Add(newkp);
                    //titlePageItems.Add(newkp);
                }
            }
            foreach (Directive item in selectedDeffereds)
            {
                DeferredItem defered = (DeferredItem)item;
                KeyValuePair<string, string> newkp = new KeyValuePair<string, string>(item.Title
                            + " " + item.WorkType + " §:" + item.Paragraph, DirectiveType.DeferredItems.FullName);
                string directiveString = defered.Title + (string.IsNullOrEmpty(item.Paragraph) ? "" : (" § " + item.Paragraph));
                string taskCardString = item.EngineeringOrders != "" ? item.EngineeringOrders : "*";
                summarySheetItems.Add(new[]
                                              {directiveString,
                                               defered.Title + " " +defered.Description,
                                               defered.ATAChapter.ToString(),
                                               item.WorkType.ToString(),
                                               taskCardString,
                                               DirectiveType.OutOfPhase.ShortName, "Additional Work"});
                if (shiftFromEnd > 0)
                {
                    mainPageItems.Insert(mainPageItems.Count - shiftFromEnd, newkp);
                    //titlePageItems.Insert(titlePageItems.Count - shiftFromEnd, newkp);
                }
                else
                {
                    mainPageItems.Add(newkp);
                    //titlePageItems.Add(newkp);
                }
            }
            var componentDirectives = new List<ComponentDirective>(selectedComponentDirectives.ToArray());
            string workType;
            int componentChangeOrderNum = 0;
            foreach (var item in selectedComponents)
            {
                componentChangeOrderNum++;
                List<ComponentDirective> dds =
                   componentDirectives.Where(dd => dd.ParentComponent != null &&
                                                dd.ParentComponent.ItemId == item.ItemId).ToList();

                workType = DirectiveWorkType.Remove.ToString();
                foreach (var componentDirective in dds)
                {
                    workType += ("\n" + componentDirective.DirectiveType);
                    componentDirectives.Remove(componentDirective);
                }
                summarySheetItems.Add(new[]
                                            {"CCO No:" + componentChangeOrderNum,
                                             item.Description + " P/N:" + item.PartNumber + " S/N:" + item.SerialNumber,
                                             item.ATAChapter.ToString(),
                                             workType,
                                             "",
                                             "Component", "Component Tasks"});

            }
			foreach (var item in selectedBaseComponents)
			{
				componentChangeOrderNum++;
				List<ComponentDirective> dds =
				   componentDirectives.Where(dd => dd.ParentComponent != null &&
												dd.ParentComponent.ItemId == item.ItemId).ToList();

				workType = DirectiveWorkType.Remove.ToString();
				foreach (ComponentDirective detailDirective in dds)
				{
					workType += ("\n" + detailDirective.DirectiveType);
					componentDirectives.Remove(detailDirective);
				}
				summarySheetItems.Add(new[]
											{"CCO No:" + componentChangeOrderNum,
											 item.Description + " P/N:" + item.PartNumber + " S/N:" + item.SerialNumber,
											 item.ATAChapter.ToString(),
											 workType,
											 "",
											 "Base Component", "Component Tasks"});

			}
			foreach (var item in componentDirectives)
			{
				componentChangeOrderNum++;

				if(item.MaintenanceDirective?.TaskCardNumberFile != null)
					tempFiles.Add(item.MaintenanceDirective?.TaskCardNumberFile);
				var d = item.ParentComponent;
				summarySheetItems.Add(new[]
											//{"CCO No:" + componentChangeOrderNum,
											{item.MaintenanceDirective?.TaskNumberCheck,
											item.DirectiveType + " for " + d.Description + " P/N:" + d.PartNumber + " S/N:" + d.SerialNumber,
											 d.ATAChapter.ToString(),
											 item.DirectiveType.ToString(),
											 item.MaintenanceDirective?.TaskCardNumber,
											 "Component Task", "Component Tasks"}); 
			}
			foreach (var item in selectedComponents)
            {
                var newkp = new KeyValuePair<string, string>(item.Description + " " + item.PartNumber + " " + item.SerialNumber, "Component");
                mainPageItems.Add(newkp);
                //titlePageItems.Add(newkp);
            }
			foreach (var item in selectedBaseComponents)
			{
				var newkp = new KeyValuePair<string, string>(item.Description + " " + item.PartNumber + " " + item.SerialNumber, "Base Component");
				mainPageItems.Add(newkp);
			}

			#endregion

			int jobOrdersPageCount = 0;

            foreach (NonRoutineJob item in selectedNrjs)
            {

                WorkPackageRecord r =
                    _workPackage.WorkPakageRecords
                        .FirstOrDefault(rec => rec.WorkPackageItemType == SmartCoreType.NonRoutineJob.ItemId && 
                                               rec.DirectiveId == item.ItemId);
                string joNo;
                if (r != null && !string.IsNullOrEmpty(r.JobCardNumber))
                    joNo = r.JobCardNumber;
                else joNo = item.Title;
                summarySheetItems.Add(new[]
                {
                    joNo,
                    item.Description,
                    item.ATAChapter.ShortName,
                    "",
                    "",
                    "Non-Routine Jobs", "NRJ"
				});

	            AttachedFile file = item.AttachedFile;
                if (file == null)
                    continue;
                if (!checkBoxPrintDupliates.Checked)
                {
                    if (nonDuplicatedFiles.FirstOrDefault(af => af.ItemId == file.ItemId || 
                                                                af.FileName == file.FileName) != null)
                    {
                        continue;
                    }
                    nonDuplicatedFiles.Add(file);
                }
                tempFiles.Add(file);

                PdfDocument inputDocument = GetPDFDocument(file);

                if (inputDocument == null)
                    continue;
                // Iterate pages
                jobOrdersPageCount += inputDocument.PageCount;
            }

            foreach (MaintenanceDirective item in dailyCheckDirectives)
            {
                string taskCardString = item.TaskCardNumber != "" ? item.TaskCardNumber : "*";

                summarySheetItems.Add(new[]
                                            {item.TaskNumberCheck,
                                             item.Description,
                                             item.ATAChapter.ToString(),
                                             item.WorkType.ToString(),
	                                         taskCardString,
                                             "MPD Items", "Routine Tasks"});
            }

            foreach (MaintenanceDirective item in weeklyCheckDirectives)
            {
                string taskCardString = item.TaskCardNumber != "" ? item.TaskCardNumber : "*";

                summarySheetItems.Add(new[]
                                            {item.TaskNumberCheck,
                                             item.Description,
                                             item.ATAChapter.ToString(),
                                             item.WorkType.ToString(),
	                                            taskCardString,
                                             "MPD Items", "Routine Tasks"});
            }

            tempFiles.AddRange(dailyCheckFiles);
            tempFiles.AddRange(weeklyCheckFiles);

            PdfDocument inputDocumentTitle;

            _animatedThreadWorker.ReportProgress(40, "Loading Task Cards");

            #region загрузка карт

            if (!checkBoxPrintDupliates.Checked)
            {
                tempFiles = tempFiles.Distinct().ToList();
            }

            foreach (AttachedFile item in tempFiles)
            {
                PdfDocument inputDocument = GetPDFDocument(item);

                if (inputDocument == null)
                    continue;
                // Iterate pages
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    PdfPage page = inputDocument.Pages[idx];
                    _outputDocument.AddPage(page);
                }
                
            }
            #endregion

            if(checkBoxPrintIncoming.Checked)
            {
                _animatedThreadWorker.ReportProgress(50, "Creating Incoming Inspection");

                #region Создание Incoming Inspection
                try
                {
                    WPIncomingInspectionBuilder tempIncoming = new WPIncomingInspectionBuilder(_workPackage);
                    inputDocumentTitle = PdfReader.Open(((WPIncomingInspectionReport)tempIncoming.GenerateReport()).ExportToStream(ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);
                    for (int i = inputDocumentTitle.Pages.Count - 1; i >= 0; i--)
                    {
                        _outputDocument.InsertPage(0, inputDocumentTitle.Pages[i]);
                    }
                    summarySheetItems.Insert(0, new[] {"Incoming Inspection",
                                                       "Incoming inspection/ Check entry" + (!string.IsNullOrEmpty(textBoxNumber.Text) ? " per " + textBoxNumber.Text : ""),
                                                       "",
                                                       "",
                                                       "",
                                                       "Incoming"});
                    jobOrdersPageCount += inputDocumentTitle.PageCount;
                    inputDocumentTitle.Dispose();
                }
                catch (PdfReaderException ex)
                {
                    MessageBox.Show("Error while opening PDF Document." +
                                    "\nDetails:" +
                                    "\n" + ex.Message,
                                    (string)new GlobalTermsProvider()["SystemName"],
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while opening PDF Document.", ex);
                }
                #endregion
            }

            if(jobOrdersPageCount > 0)
            {
                //if (shiftFromEnd > 0)
                //{
                    mainPageItems.Insert(0, new KeyValuePair<string, string>("Job Orders", jobOrdersPageCount.ToString()));
                    titlePageItems.Insert(0, new KeyValuePair<string, int>("Job Orders", jobOrdersPageCount));
                    crsPageItems.Insert(0, new KeyValuePair<string, int>("pages of Job Orders.", jobOrdersPageCount));
                //}
                //else
                //{
                //    mainPageItems.Add(new KeyValuePair<string, string>("Job Orders", jobOrdersPageCount.ToString()));
                //    titlePageItems.Add(new KeyValuePair<string, int>("Job Orders", jobOrdersPageCount));
                //    crsPageItems.Add(new KeyValuePair<string, int>("pages of Job Orders.", jobOrdersPageCount));
                //}    
            }

            _animatedThreadWorker.ReportProgress(60, "Creating Non-routine cards");

            #region Формирование и создание Non-Routine Card

            try
            {
				var order = new NonRoutineCardBuilder(_workPackage, new Component(), "", componentChangeOrderNum, true);
				inputDocumentTitle = PdfReader.Open(((NonRoutineCardReportScat)order.GenerateReport()).ExportToStream(ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);
				for (int i = 0; i < inputDocumentTitle.PageCount; i++)
					_outputDocument.AddPage(inputDocumentTitle.Pages[i]);
	            //for (int i = 0; i < inputDocumentTitle.PageCount; i++)
		           // _outputDocument.AddPage(inputDocumentTitle.Pages[i]);

				if (shiftFromEnd > 0)
				{
					mainPageItems.Insert(mainPageItems.Count - shiftFromEnd, new KeyValuePair<string, string>("Non Routine Card", (inputDocumentTitle.PageCount + 1).ToString()));
					titlePageItems.Insert(titlePageItems.Count - 1, new KeyValuePair<string, int>("Non Routine Card", inputDocumentTitle.PageCount +1 ));
					crsPageItems.Insert(crsPageItems.Count - shiftFromEnd, new KeyValuePair<string, int>("pages of Non Routine Cards (Unscheduled works).", inputDocumentTitle.PageCount + 1));
					//mainPageItems.Insert(mainPageItems.Count - shiftFromEnd, new KeyValuePair<string, string>("Component Removal Report", (selectedDetails.Count + 1).ToString()));
					//crsPageItems.Insert(crsPageItems.Count - shiftFromEnd, new KeyValuePair<string, int>("pages of Component Change Report ", selectedDetails.Count + 1));
				}
				else
				{
					mainPageItems.Add(new KeyValuePair<string, string>("Non Routine Card", (inputDocumentTitle.PageCount + 1).ToString(CultureInfo.InvariantCulture)));
					titlePageItems.Add(new KeyValuePair<string, int>("Non Routine Card", inputDocumentTitle.PageCount + 1));
					crsPageItems.Add(new KeyValuePair<string, int>("pages of Non Routine Cards (Unscheduled works).", inputDocumentTitle.PageCount + 1));
					//mainPageItems.Add(new KeyValuePair<string, string>("Component Removal Report", (selectedDetails.Count + 1).ToString()));
					//crsPageItems.Add(new KeyValuePair<string, int>("pages of Component Change Report ", selectedDetails.Count + 1));
				}

			}
            catch (PdfReaderException ex)
            {
                MessageBox.Show("Error while opening PDF Document." +
								"\nComponents:" +
                                "\n" + ex.Message,
                                (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while opening PDF Document.", ex);
            }

            #endregion

            _animatedThreadWorker.ReportProgress(65, "Creating Component Change Orders");

            #region Формирование и создание Component Change Order - ов

            componentDirectives.Clear();
            componentDirectives.AddRange(selectedComponentDirectives.ToArray());
#if KAC
            try
            {
                //В данной конфигурации к компонентам и их задачам, включенным а рабочий пакет
                //необходимо добавить 3 пустые записи для непредвиденной замены агрегатов
                //это достигается посредством включения в распечатку 3-х "пустых" компонентов
                List<Detail> detailsForReport = new List<Detail>();
                detailsForReport.AddRange(detailDirectives.Where(dd => dd.ParentDetail != null).Select(dd => dd.ParentDetail));

                do detailsForReport.Add(new Detail());
                while (detailsForReport.Count % 3 != 0);

                ComponentChangeOrderBuilderKAC order =
                    new ComponentChangeOrderBuilderKAC(_workPackage,
                                                       detailsForReport,
                                                       "", componentChangeOrderNum);
                inputDocumentTitle = PdfReader.Open(((ComponentChangeOrderReportKAC)order.GenerateReport()).ExportToStream(ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);
                for (int i = 0; i < inputDocumentTitle.PageCount; i++)
                    _outputDocument.AddPage(inputDocumentTitle.Pages[i]);


                if (shiftFromEnd > 0)
                {
                    mainPageItems.Insert(mainPageItems.Count - shiftFromEnd, new KeyValuePair<string, string>("Component Removal Report", inputDocumentTitle.PageCount.ToString()));
                    titlePageItems.Insert(titlePageItems.Count - 1, new KeyValuePair<string, int>("Component Removal/Replacement Report", inputDocumentTitle.PageCount));
                    crsPageItems.Insert(crsPageItems.Count - shiftFromEnd, new KeyValuePair<string, int>("pages of Component Change Report ", inputDocumentTitle.PageCount));
                }
                else
                {
                    mainPageItems.Add(new KeyValuePair<string, string>("Component Removal Report", inputDocumentTitle.PageCount.ToString()));
                    titlePageItems.Add(new KeyValuePair<string, int>("Component Removal/Replacement Report", inputDocumentTitle.PageCount));
                    crsPageItems.Add(new KeyValuePair<string, int>("pages of Component Change Report ", selectedDetails.Count + 1));
                }
            }
            catch (PdfReaderException ex)
            {
                MessageBox.Show("Error while opening PDF Document." +
                                "\nDetails:" +
                                "\n" + ex.Message,
                                (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while opening PDF Document.", ex);
            }
#else
                        componentChangeOrderNum = 0;
   //         foreach (Component item in selectedComponents)
   //         {
   //             componentChangeOrderNum++;
   //             //группмрование директив деталей в рабочем пакете(если они имеются),
   //             //по идентификатору родительскои детали
   //             List<ComponentDirective> dds =
   //                componentDirectives.Where(dd => dd.ParentComponent != null &&
   //                                             dd.ParentComponent.ItemId == item.ItemId).ToList();

   //             workType = DirectiveWorkType.Remove.ToString();
   //             foreach (var componentDirective in dds)
   //             {
   //                 workType += ("\n" + componentDirective.DirectiveType);
   //                 componentDirectives.Remove(componentDirective);
   //             }

   //             try
   //             {
   //                 ComponentChangeOrderBuilder order = new ComponentChangeOrderBuilder(_workPackage, item, workType, componentChangeOrderNum, true);
   //                 inputDocumentTitle = PdfReader.Open(((ComponentChangeOrderReportScat)order.GenerateReport()).ExportToStream(ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);
   //                 _outputDocument.AddPage(inputDocumentTitle.Pages[0]);
   //             }
   //             catch (PdfReaderException ex)
   //             {
   //                 MessageBox.Show("Error while opening PDF Document." +
			//						"\nComponents:" +
   //                                 "\n" + ex.Message,
   //                                 (string)new GlobalTermsProvider()["SystemName"],
   //                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
   //                                 MessageBoxDefaultButton.Button1);
   //             }
   //             catch (Exception ex)
   //             {
   //                 Program.Provider.Logger.Log("Error while opening PDF Document.", ex);
   //             }
   //         }
			//foreach (Component item in selectedBaseComponents)
			//{
			//	componentChangeOrderNum++;
			//	//группмрование директив деталей в рабочем пакете(если они имеются),
			//	//по идентификатору родительскои детали
			//	var dds =
			//	   componentDirectives.Where(dd => dd.ParentComponent != null &&
			//									dd.ParentComponent.ItemId == item.ItemId).ToList();

			//	workType = DirectiveWorkType.Remove.ToString();
			//	foreach (var componentDirective in dds)
			//	{
			//		workType += "\n" + componentDirective.DirectiveType;
			//		componentDirectives.Remove(componentDirective);
			//	}

			//	try
			//	{
			//		var order = new ComponentChangeOrderBuilder(_workPackage, item, workType, componentChangeOrderNum, true);
			//		inputDocumentTitle = PdfReader.Open(((ComponentChangeOrderReportScat)order.GenerateReport()).ExportToStream(ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);
			//		_outputDocument.AddPage(inputDocumentTitle.Pages[0]);
			//	}
			//	catch (PdfReaderException ex)
			//	{
			//		MessageBox.Show("Error while opening PDF Document." +
			//						"\nComponents:" +
			//						"\n" + ex.Message,
			//						(string)new GlobalTermsProvider()["SystemName"],
			//						MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
			//						MessageBoxDefaultButton.Button1);
			//	}
			//	catch (Exception ex)
			//	{
			//		Program.Provider.Logger.Log("Error while opening PDF Document.", ex);
			//	}
			//}
			//foreach (ComponentDirective item in componentDirectives)
   //         {
   //             componentChangeOrderNum++;

   //             try
   //             {
   //                 var order = 
   //                     new ComponentChangeOrderBuilder(_workPackage,
   //                                   item.ParentComponent,
   //                                   item.DirectiveType.ToString(), componentChangeOrderNum, true);
   //                 inputDocumentTitle = PdfReader.Open(((ComponentChangeOrderReportScat)order.GenerateReport()).ExportToStream(ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);
   //                 _outputDocument.AddPage(inputDocumentTitle.Pages[0]);
   //             }
   //             catch (PdfReaderException ex)
   //             {
   //                 MessageBox.Show("Error while opening PDF Document." +
			//						"\nComponents:" +
   //                                 "\n" + ex.Message,
   //                                 (string)new GlobalTermsProvider()["SystemName"],
   //                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
   //                                 MessageBoxDefaultButton.Button1);
   //             }
   //             catch (Exception ex)
   //             {
   //                 Program.Provider.Logger.Log("Error while opening PDF Document.", ex);
   //             }
   //         }


			try
			{
				var order =
					new ComponentChangeOrderBuilder(_workPackage,
						null,
						"", componentChangeOrderNum, true);
				inputDocumentTitle = PdfReader.Open(((ComponentChangeOrderReportScat)order.GenerateReport()).ExportToStream(ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);
				_outputDocument.AddPage(inputDocumentTitle.Pages[0]);
			}
			catch (PdfReaderException ex)
			{
				MessageBox.Show("Error while opening PDF Document." +
				                "\nComponents:" +
				                "\n" + ex.Message,
					(string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button1);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while opening PDF Document.", ex);
			}

#endif
			#endregion

			_animatedThreadWorker.ReportProgress(70, "Creating Summary Sheet");


            #region Создание листа перечня работ

            if (!_isWorkOrder)
            {
	            try
	            {
#if AQUILINE || DemoDebug || SCAT
		            var tempSummarySheet = new WorkPackageSummarySheetBuilderAquiLine(_workPackage, summarySheetItems, true);
		            inputDocumentTitle = PdfReader.Open(((WorkPackageSummarySheetReportScat)tempSummarySheet.GenerateReport()).ExportToStream(ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);
#else
                var tempSummarySheet = new WorkPackageSummarySheetBuilder(_workPackage, summarySheetItems);
                 inputDocumentTitle = PdfReader.Open(((WorkPackageSummarySheetReport)tempSummarySheet.GenerateReport()).ExportToStream(ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);
#endif

		            for (int i = inputDocumentTitle.Pages.Count - 1; i >= 0; i--)
		            {
			            _outputDocument.InsertPage(0, inputDocumentTitle.Pages[i]);
		            }
		            mainPageItems.Insert(0, new KeyValuePair<string, string>("Summary Sheet", inputDocumentTitle.Pages.Count.ToString()));
		            titlePageItems.Insert(0, new KeyValuePair<string, int>("Summary Sheet", inputDocumentTitle.Pages.Count));
		            crsPageItems.Insert(0, new KeyValuePair<string, int>("page of Summary Sheet (Scheduled works)", inputDocumentTitle.Pages.Count));

	            }
	            catch (PdfReaderException ex)
	            {
		            MessageBox.Show("Error while opening PDF Document." +
		                            "\nComponents:" +
		                            "\n" + ex.Message,
			            (string)new GlobalTermsProvider()["SystemName"],
			            MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
			            MessageBoxDefaultButton.Button1);
	            }
	            catch (Exception ex)
	            {
		            Program.Provider.Logger.Log("Error while opening PDF Document.", ex);
	            }
            }
            #endregion

            _animatedThreadWorker.ReportProgress(75, "Creating Certificate of Release to Service");

			#region формирование и создание листа ReleaceToService

			if (!_isWorkOrder)
			{
				try
				{
#if AQUILINE || DemoDebug || SCAT
					var tempTitle = new WorkPackageReleaseToServiceBuilderAquiline(_workPackage, crsPageItems, true);
					inputDocumentTitle =
						PdfReader.Open(
							((WorkPackageReleaseToServiceReportScat) tempTitle.GenerateReport()).ExportToStream(
								ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);
#else
				var tempTitle = new WorkPackageReleaseToServiceBuilder(_workPackage, crsPageItems);
                inputDocumentTitle =
 PdfReader.Open(((WorkPackageReleaseToServiceReport)tempTitle.GenerateReport()).ExportToStream(ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);
#endif

					for (int i = inputDocumentTitle.Pages.Count - 1; i >= 0; i--)
					{
						_outputDocument.InsertPage(0, inputDocumentTitle.Pages[i]);
					}

					mainPageItems.Insert(0,
						new KeyValuePair<string, string>("Certificate of Release to Service",
							inputDocumentTitle.Pages.Count.ToString()));
					titlePageItems.Insert(0,
						new KeyValuePair<string, int>("Certificate of Release to Service",
							inputDocumentTitle.Pages.Count));
				}
				catch (PdfReaderException ex)
				{
					MessageBox.Show("Error while opening PDF Document." +
					                "\nComponents:" +
					                "\n" + ex.Message,
						(string) new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
						MessageBoxDefaultButton.Button1);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while opening PDF Document.", ex);
				}
			}

			#endregion

            _animatedThreadWorker.ReportProgress(85, "Creating Main Page");

#region создание Главной страницы

if (!_isWorkOrder)
{
	try
	{
		var tempMp = new WorkPackageMainPageBuilder(_workPackage, mainPageItems, true);
		inputDocumentTitle = PdfReader.Open(((WPMainPagePerortScat)tempMp.GenerateReport()).ExportToStream(ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);

		for (int i = inputDocumentTitle.Pages.Count - 1; i >= 0; i--)
		{
			_outputDocument.InsertPage(0, inputDocumentTitle.Pages[i]);
		}
	}
	catch (PdfReaderException ex)
	{
		MessageBox.Show("Error while opening PDF Document." +
		                "\nComponents:" +
		                "\n" + ex.Message,
			(string)new GlobalTermsProvider()["SystemName"],
			MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
			MessageBoxDefaultButton.Button1);
	}
	catch (Exception ex)
	{
		Program.Provider.Logger.Log("Error while opening PDF Document.", ex);
	}
}

#endregion

            _animatedThreadWorker.ReportProgress(95, "Creating Title Page");
#region создание Титульной страницы

           
            try
            {
#if AQUILINE || DemoDebug || SCAT
	            if (_isWorkOrder)
	            {
		            var _builderScat = new WOBuilderScat(_workPackage, _outputDocument.Pages.Count, summarySheetItems);
		            inputDocumentTitle = PdfReader.Open(((WOScat)_builderScat.GenerateReport()).ExportToStream(ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);

		            for (int i = inputDocumentTitle.Pages.Count - 1; i >= 0; i--)
		            {
			            _outputDocument.InsertPage(0, inputDocumentTitle.Pages[i]);
		            }
				}
				//var tempSummarySheet = new WorkPackageTitleBuilderAquiline(_workPackage, titlePageItems, true);
				//inputDocumentTitle = PdfReader.Open(((WPTitlePageReportScat)tempSummarySheet.GenerateReport()).ExportToStream(ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);
#else
				//var tempMp =  new WorkPackageTitlePageBuilder(_workPackage, titlePageItems, GlobalObjects.CasEnvironment.GetBaseDetails(_workPackage.Aircraft));
    //            inputDocumentTitle = PdfReader.Open(((WPTitlePageReport)tempMp.GenerateReport()).ExportToStream(ExportFormatType.PortableDocFormat), PdfDocumentOpenMode.Import);

				//for (int i = inputDocumentTitle.Pages.Count - 1; i >= 0; i--)
    //            {
    //                _outputDocument.InsertPage(0, inputDocumentTitle.Pages[i]);
    //            }
#endif
			}
			catch (PdfReaderException ex)
            {
                MessageBox.Show("Error while opening PDF Document." +
								"\nComponents:" +
                                "\n" + ex.Message,
                                (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while opening PDF Document.", ex);
            }


#endregion

        }
#endregion

#region private void RemoveMaintenanceCheckTask
        /// <summary>
        /// Удаление чеков из коллекции MaintenanceCheck
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="selectedMpds"></param>
        private void RemoveMaintenanceCheckTask(MaintenanceCheck mc, List<MaintenanceDirective> selectedMpds)
        {
            List<MaintenanceDirective> checkMpds =
                (from record in _workPackage.MaintenanceCheckBindTaskRecords
                    where record.TaskType == SmartCoreType.MaintenanceDirective && record.CheckId == mc.ItemId
                    select record.Task as MaintenanceDirective)
                    .OrderBy(cm => cm.TaskNumberCheck)
                    .ToList();

            checkMpds.AddRange(mc.BindMpds);
            foreach (MaintenanceDirective checkMpd in checkMpds)
                selectedMpds.Remove(checkMpd);
        }

#endregion

#region GetPDFDocument
        /// <summary>
        /// Метод для получения документа pdf
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private PdfDocument GetPDFDocument(AttachedFile file)
        {
            PdfDocument inputDocument = null;
            try
            {
                if (file.FileData == null)
					file = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<AttachedFileDTO, AttachedFile>(file.ItemId, true);
				if (file.FileData != null)
                {
                    // Open the document to import pages from it.
                    Stream tempStream = new MemoryStream(file.FileData);
                    inputDocument = PdfReader.Open(tempStream, PdfDocumentOpenMode.Import);
                    tempStream.Close();
                }
            }
            catch (PdfReaderException ex)
            {
                MessageBox.Show($"Error while opening PDF Document : {file.FileName}" +
								"\nComponents:" +
                                "\n" + ex.Message,
                    (string) new GlobalTermsProvider()["SystemName"],
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while opening PDF Document.", ex);
            }
            return inputDocument;
        }

#endregion

#region private void Save()
        /// <summary>
        /// Сохраняет настроики печати элементов
        /// </summary>
        private void Save()
        {
            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (!(row.Tag is MaintenanceDirective)) continue;
                if (row.Cells.Count < 3 || !(row.Cells[2] is DataGridViewCheckBoxCell))
                    continue;
                var mpd = row.Tag as MaintenanceDirective;
                var printCell = (DataGridViewCheckBoxCell)row.Cells[2];

                var value = (bool) printCell.Value;

                if(mpd.PrintInWorkPackage != value)
                {
                    mpd.PrintInWorkPackage = value;

                    try
                    {
                        GlobalObjects.CasEnvironment.NewKeeper.Save(mpd, false);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while save print settings", ex);
                    }
                }
            }        
        }
#endregion

#region private void ButtonOkClick(object sender, EventArgs e)
        private void ButtonOkClick(object sender, EventArgs e)
        {
            _animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoCreate;
            _animatedThreadWorker.RunWorkerCompleted -= BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerCreateCompleted;

	        try
	        {
		        _animatedThreadWorker.RunWorkerAsync();
	        }
	        catch (NotSupportedException ex)
	        {
		        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
	        }
	        catch (Exception ex)
	        {
		        Program.Provider.Logger.Log("Error while creating document",ex);
	        }

            //Save();

            //DialogResult = DialogResult.OK;
            //Close();
        }
#endregion

#region private void TemplateAircraftAddToDataBaseForm_Deactivate(object sender, EventArgs e)

        private void TemplateAircraftAddToDataBaseForm_Deactivate(object sender, EventArgs e)
        {
            StaticWaitFormProvider.WaitForm.Visible = false;
        }
#endregion

#region private void TemplateAircraftAddToDataBaseForm_Activated(object sender, EventArgs e)
        private void TemplateAircraftAddToDataBaseForm_Activated(object sender, EventArgs e)
        {
            if (StaticWaitFormProvider.IsActive)
                StaticWaitFormProvider.WaitForm.Visible = true;
        }
#endregion

#region private void CheckBoxPrintIncomingClick(object sender, EventArgs e)
        private void CheckBoxPrintIncomingClick(object sender, EventArgs e)
        {
            labelJONumber.Enabled = textBoxNumber.Enabled = checkBoxPrintIncoming.Checked;
        }
#endregion

#region private void ComboBoxRoutingTaskGrouping_SelectedIndexChanged(object sender, EventArgs e)

		private void ComboBoxRoutingTaskGrouping_SelectedIndexChanged(object sender, EventArgs e)
	    {
		    _comboBoxGroupingSelectedValue = (WorkPackageRoutineTasksGrouping) comboBoxRoutingTaskGrouping.SelectedValue;
	    }

#endregion


#endregion
    }
}
