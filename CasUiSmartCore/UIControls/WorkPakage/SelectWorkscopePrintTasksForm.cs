using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using MetroFramework.Forms;
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
    public partial class SelectWorkscopePrintTasksForm : MetroForm
    {
        #region Fields

        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

        private string _comboBoxItemOneToOne = "One for One";
        private string _comboBoxItemOneForAll = "One for All";

        private List<BaseEntityObject> _selectedItems = new List<BaseEntityObject>();

        private WorkPackage _workPackage;
        
        #endregion

        #region Properties

        public List<BaseEntityObject> SelectedItems
        {
            get { return _selectedItems; }
        }

        #endregion

        #region Constructors

        ///<summary>
        ///</summary>
        private SelectWorkscopePrintTasksForm()
        {
            InitializeComponent();
        }

        ///<summary>
        ///</summary>
        public SelectWorkscopePrintTasksForm(WorkPackage workPackage)
            : this()
        {
            if (workPackage == null)
                throw new ArgumentNullException();
            _workPackage = workPackage;

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
            dataGridViewItems.Rows.Clear();

            if (_workPackage == null) return;

            #region Чеки программы обслуживания и директивы программы обслуживания

            List<MaintenanceDirective> checkDirectives = new List<MaintenanceDirective>();

            foreach (MaintenanceCheck maintenanceCheck in _workPackage.MaintenanceChecks)
            {
                DataGridViewRow row;
                DataGridViewCell discCell;
                DataGridViewCell taskCardCell;
                DataGridViewCell compntCell;

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
                            }
                            else continue;
                        }
                        else
                        {
                            row = new DataGridViewRow { Tag = maintenanceCheck };
                            discCell = new DataGridViewTextBoxCell { Value = maintenanceCheck.Name };
                            taskCardCell = new DataGridViewTextBoxCell { Value = "" };
                            compntCell = new DataGridViewCheckBoxCell { Value = maintenanceCheck.PrintInWorkPackage };
                        }
                    }
                }
                else
                {
                    row = new DataGridViewRow { Tag = maintenanceCheck };
                    discCell = new DataGridViewTextBoxCell { Value = maintenanceCheck.Name };
                    taskCardCell = new DataGridViewTextBoxCell { Value = "" };
                    compntCell = new DataGridViewCheckBoxCell { Value = maintenanceCheck.PrintInWorkPackage };
                }

                row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell });
                discCell.ReadOnly = true;
                taskCardCell.ReadOnly = true;

                dataGridViewItems.Rows.Add(row);

                List<MaintenanceDirective> checkMpds =
                    (from record in _workPackage.MaintenanceCheckBindTaskRecords
                     where record.TaskType == SmartCoreType.MaintenanceDirective && record.CheckId == maintenanceCheck.ItemId
                     select record.Task as MaintenanceDirective)
                     .OrderBy(cm => cm.TaskNumberCheck)
                     .ToList();

                checkMpds.AddRange(maintenanceCheck.BindMpds
                                       .Where(bmpd => _workPackage.WorkPakageRecords
                                                      .FirstOrDefault(r => r.WorkPackageItemType == SmartCoreType.MaintenanceDirective.ItemId 
                                                                        && r.DirectiveId == bmpd.ItemId) !=null));
                checkDirectives.AddRange(checkMpds);

                foreach (MaintenanceDirective checkMpd in checkMpds)
                {
					//TODO:(Evgenii Babak) избавиться от кода
					if (checkMpd.ItemRelations.Count == 0)
						checkMpd.ItemRelations
							.AddRange(_workPackage.ComponentDirectives.Where(bdd => bdd.ItemRelations.IsAllRelationWith(checkMpd)).SelectMany(bdd => bdd.ItemRelations));
					DataGridViewRow checkMpdRow = new DataGridViewRow { Tag = checkMpd };
                    DataGridViewCell checkMpdDiscCell;
                    DataGridViewCell checkMpdTaskCardCell;
                    DataGridViewCell checkMpdCompntCell;

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
                        checkMpdDiscCell = new DataGridViewTextBoxCell { Value =
	                        $"{maintenanceCheck.Name}--{checkMpd.TaskNumberCheck} for {checkMpd.ItemRelations.Count} components"
                        };
                        checkMpdTaskCardCell = new DataGridViewTextBoxCell
                                                   {
                                                       Value = checkMpdTaskCardCellValue,
                                                       Style = { BackColor = checkMpdTaskCardCellBackColor },
                                                   };
                        checkMpdCompntCell = new DataGridViewCheckBoxCell { Value = checkMpd.PrintInWorkPackage };

                        checkMpdRow.Cells.AddRange(new[] { checkMpdDiscCell, checkMpdTaskCardCell, checkMpdCompntCell });

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

                        checkMpdRow.Cells.AddRange(new[] { checkMpdDiscCell, checkMpdTaskCardCell, checkMpdCompntCell });

                        checkMpdDiscCell.ReadOnly = true;
                        checkMpdTaskCardCell.ReadOnly = true;
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

                row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell });
                discCell.ReadOnly = true;
                taskCardCell.ReadOnly = true;

                dataGridViewItems.Rows.Add(row);
            }

            #endregion

            #region Директивы летной годности

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
                discCell.Value = "(AD)" + item.Title + " " + item.WorkType + " §:" + item.Paragraph;

                row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell });

                discCell.ReadOnly = true;
                taskCardCell.ReadOnly = true;

                dataGridViewItems.Rows.Add(row);
            }
			#endregion

	        #region SB

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
		        discCell.Value = "(SB)" + item.Title + " " + item.WorkType + " §:" + item.Paragraph;

		        row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell });

		        discCell.ReadOnly = true;
		        taskCardCell.ReadOnly = true;

		        dataGridViewItems.Rows.Add(row);
	        }

	        #endregion

	        #region EO

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
		        discCell.Value = "(EO)" + item.Title + " " + item.WorkType + " §:" + item.Paragraph;

		        row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell });

		        discCell.ReadOnly = true;
		        taskCardCell.ReadOnly = true;

		        dataGridViewItems.Rows.Add(row);
	        }

	        #endregion

			#region Повреждения

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
                discCell.Value = "(DRI)" + item.Title + " " + item.WorkType + " §:" + item.Paragraph;

                row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell });

                discCell.ReadOnly = true;
                taskCardCell.ReadOnly = true;

                dataGridViewItems.Rows.Add(row);
            }
            #endregion

            #region OutOfPhaseItems

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
                discCell.Value = "(OP)" + item.Title + " " + item.WorkType + " §:" + item.Paragraph;

                row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell });

                discCell.ReadOnly = true;
                taskCardCell.ReadOnly = true;

                dataGridViewItems.Rows.Add(row);
            }
            #endregion

            #region Отложенные дефекты

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
                discCell.Value = "(DI)" + item.Title + " " + item.WorkType + " §:" + item.Paragraph;

                row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell });

                discCell.ReadOnly = true;
                taskCardCell.ReadOnly = true;

                dataGridViewItems.Rows.Add(row);
            }
            #endregion

            #region Компоненты и задачи по компонентам

            var componentDirectives = _workPackage.ComponentDirectives.ToList();
            foreach (var item in _workPackage.Components)
            {
                List<ComponentDirective> dds =
                   componentDirectives.Where(dd => dd.ParentComponent != null &&
                                                dd.ParentComponent.ItemId == item.ItemId).ToList();

                foreach (var componentDirective in dds)
                {
                    componentDirectives.Remove(componentDirective);
                }

                DataGridViewRow row = new DataGridViewRow { Tag = item };

                DataGridViewCell discCell = new DataGridViewTextBoxCell();
                DataGridViewCell taskCardCell = new DataGridViewTextBoxCell();
                DataGridViewCell compntCell = new DataGridViewCheckBoxCell { Value = item.PrintInWorkPackage };
                discCell.Value = "CCO:" + item.Description + " " + item.PartNumber + " " + item.SerialNumber;

                row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell });

                discCell.ReadOnly = true;
                taskCardCell.ReadOnly = true;

                dataGridViewItems.Rows.Add(row);

            }
            foreach (ComponentDirective item in componentDirectives)
            {
                Component d = item.ParentComponent;
                DataGridViewRow row = new DataGridViewRow { Tag = item };

                DataGridViewCell discCell = new DataGridViewTextBoxCell();
                DataGridViewCell taskCardCell = new DataGridViewTextBoxCell();
                DataGridViewCell compntCell = new DataGridViewCheckBoxCell { Value = item.PrintInWorkPackage };
                discCell.Value = "CCO:" + item.DirectiveType + " for " + d.Description + " " + d.PartNumber + " " + d.SerialNumber;

                row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell });

                discCell.ReadOnly = true;
                taskCardCell.ReadOnly = true;

                dataGridViewItems.Rows.Add(row);
            }
            #endregion

            #region Нерутинные задачи

            foreach (NonRoutineJob item in _workPackage.NonRoutines)
            {
                DataGridViewRow row = new DataGridViewRow { Tag = item };

                DataGridViewCell discCell = new DataGridViewTextBoxCell { Value = "(Non-Routine)" + item.Title };
                DataGridViewCell taskCardCell = new DataGridViewTextBoxCell();
                DataGridViewCell compntCell = new DataGridViewCheckBoxCell { Value = item.PrintInWorkPackage };

                row.Cells.AddRange(new[] { discCell, taskCardCell, compntCell });

                discCell.ReadOnly = true;
                taskCardCell.ReadOnly = true;

                dataGridViewItems.Rows.Add(row);
            }
            #endregion
        }
        #endregion

        #region private void AnimatedThreadWorkerDoCreate(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoCreate(object sender, DoWorkEventArgs e)
        {
            _animatedThreadWorker.ReportProgress(0, "Save print settings");

            Save();
            
            ConcatenatePdfDocuments();

            _animatedThreadWorker.ReportProgress(100, "Create Complete");
        }
        #endregion

        #region private void BackgroundWorkerRunWorkerCreateCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void BackgroundWorkerRunWorkerCreateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region private void ConcatenatePdfDocuments()
        /// <summary>
        /// This sample adds a consecutive number in the middle of each page.
        /// It shows how you can add graphics to an imported page.
        /// </summary>
        private void ConcatenatePdfDocuments()
        {
            List<MaintenanceCheck> selectedChecks = new List<MaintenanceCheck>(_workPackage.MaintenanceChecks);
            List<MaintenanceDirective> selectedMpds = new List<MaintenanceDirective>(_workPackage.MaintenanceDirectives);
            selectedMpds.AddRange((from record in _workPackage.MaintenanceCheckBindTaskRecords
                                 where record.TaskType == SmartCoreType.MaintenanceDirective
                                 select record.Task as MaintenanceDirective));
            selectedMpds = selectedMpds.Distinct().OrderBy(cm => cm.TaskNumberCheck).ToList();
            List<Directive> selectedADs = new List<Directive>(_workPackage.AdStatus);
			selectedADs.AddRange(_workPackage.SbStatus);
			selectedADs.AddRange(_workPackage.EoStatus);
            List<Directive> selectedDamages = new List<Directive>(_workPackage.Damages);
            List<Directive> selectedOofs = new List<Directive>(_workPackage.OutOfPhaseItems);
            List<Directive> selectedDeffereds = new List<Directive>(_workPackage.DefferedItems);
            List<ComponentDirective> selectedComponentDirectives = new List<ComponentDirective>(_workPackage.ComponentDirectives);
            List<Component> selectedComponents = new List<Component>(_workPackage.Components);
            List<NonRoutineJob> selectedNrjs = new List<NonRoutineJob>(_workPackage.NonRoutines);

            _animatedThreadWorker.ReportProgress(10, "Sample of Maintenance checks and MPD");

            #region Выборка Чеков и директив программы обслуживания

            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (!(row.Tag is MaintenanceCheck)) continue;
                if (row.Cells.Count < 3 || !(row.Cells[2] is DataGridViewCheckBoxCell))
                    continue;
                MaintenanceCheck check = row.Tag as MaintenanceCheck;
                DataGridViewCheckBoxCell printCell = (DataGridViewCheckBoxCell)row.Cells[2];
                if (!(bool)printCell.Value)
                {
                    //Если чек не выбран для распечатки,
                    //то из результирующей коллекции для распечатки нужно исключить как сам чек,
                    //так и его элементы
                    selectedChecks.Remove(check);

                    if (check.Grouping)
                    {
                        MaintenanceNextPerformance mnp = check.GetNextPergormanceGroupWhereCheckIsSenior();
                        if (mnp != null && mnp.PerformanceGroup != null && mnp.PerformanceGroup.Checks.Count > 0
                            && _workPackage.Aircraft != null && _workPackage.Aircraft.MSG == MSG.MSG3)
                        {
                            foreach (MaintenanceCheck mc in mnp.PerformanceGroup.Checks)
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
                        }
                        else
                        {
                            List<MaintenanceDirective> checkMpds =
                            (from record in _workPackage.MaintenanceCheckBindTaskRecords
                             where record.TaskType == SmartCoreType.MaintenanceDirective && record.CheckId == check.ItemId
                             select record.Task as MaintenanceDirective)
                                .OrderBy(cm => cm.TaskNumberCheck)
                                .ToList();

                            checkMpds.AddRange(check.BindMpds);
                            foreach (MaintenanceDirective checkMpd in checkMpds)
                                selectedMpds.Remove(checkMpd);
                        }
                    }
                    else
                    {
                        List<MaintenanceDirective> checkMpds =
                            (from record in _workPackage.MaintenanceCheckBindTaskRecords
                             where record.TaskType == SmartCoreType.MaintenanceDirective && record.CheckId == check.ItemId
                             select record.Task as MaintenanceDirective)
                                .OrderBy(cm => cm.TaskNumberCheck)
                                .ToList();

                        checkMpds.AddRange(check.BindMpds);
                        foreach (MaintenanceDirective checkMpd in checkMpds)
                            selectedMpds.Remove(checkMpd); 
                    }
                }
            }

            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (!(row.Tag is MaintenanceDirective)) continue;
                if (row.Cells.Count < 3 || !(row.Cells[2] is DataGridViewCheckBoxCell))
                    continue;
                MaintenanceDirective mpd = row.Tag as MaintenanceDirective;
                DataGridViewCheckBoxCell printCell = (DataGridViewCheckBoxCell)row.Cells[2];
                if (!(bool)printCell.Value)
                {
                    //Если директива программы обслуживания не выбрана для распечатки,
                    //то ее нужно исключить из результирующей коллекции для распечатки 
                    MaintenanceDirective directive = selectedMpds.FirstOrDefault(sm => sm.ItemId == mpd.ItemId);
                    if (directive != null)
                        selectedMpds.Remove(directive);
                }
                else
                {
                    if (row.Cells.Count < 4 || !(row.Cells[3] is DataGridViewComboBoxCell))
                        continue;
                    //Если директива программы обслуживания имеет связные с ней задачи по 
                    //компонентам и Выбрана для распечатки,
                    //то нужно определить, сколько копий директивы надо включить в распечатку
                    //1. По одной на каждую связную задачу по компоненту
                    //2. Одну на все связные задачи по компонентам
                    MaintenanceDirective directive = selectedMpds.FirstOrDefault(sm => sm.ItemId == mpd.ItemId);
                    if (directive != null)
                    {
                        DataGridViewComboBoxCell countCell = (DataGridViewComboBoxCell)row.Cells[3];
                        if (countCell.EditedFormattedValue.ToString() == _comboBoxItemOneToOne)
                            directive.CountForPrint = directive.ItemRelations.Count;
                        else if (countCell.EditedFormattedValue.ToString() == _comboBoxItemOneForAll)
                            directive.CountForPrint = 1;
                    }
                }
            }

            #endregion

            _animatedThreadWorker.ReportProgress(15, "Sample of AD");

            #region Выборка Директив летной годности

            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (!(row.Tag is Directive)) continue;
                if (row.Cells.Count < 3 || !(row.Cells[2] is DataGridViewCheckBoxCell))
                    continue;
                Directive directive = row.Tag as Directive;
                DataGridViewCheckBoxCell printCell = (DataGridViewCheckBoxCell)row.Cells[2];
                if (!(bool)printCell.Value)
                {
                    if (directive.DirectiveType == DirectiveType.AirworthenessDirectives &&
                        selectedADs.FirstOrDefault(sm => sm.ItemId == directive.ItemId) != null)
                        selectedADs.Remove(directive);
                    if (directive.DirectiveType == DirectiveType.DamagesRequiring &&
                        selectedDamages.FirstOrDefault(sm => sm.ItemId == directive.ItemId) != null)
                        selectedDamages.Remove(directive);
                    if (directive.DirectiveType == DirectiveType.DeferredItems &&
                        selectedDeffereds.FirstOrDefault(sm => sm.ItemId == directive.ItemId) != null)
                        selectedDeffereds.Remove(directive);
                    if (directive.DirectiveType == DirectiveType.OutOfPhase &&
                        selectedOofs.FirstOrDefault(sm => sm.ItemId == directive.ItemId) != null)
                        selectedOofs.Remove(directive);
					if (directive.DirectiveType == DirectiveType.SB &&
					   selectedOofs.FirstOrDefault(sm => sm.ItemId == directive.ItemId) != null)
						selectedOofs.Remove(directive);
					if (directive.DirectiveType == DirectiveType.EngineeringOrders &&
					   selectedOofs.FirstOrDefault(sm => sm.ItemId == directive.ItemId) != null)
						selectedOofs.Remove(directive);
				}
            }
            #endregion

            _animatedThreadWorker.ReportProgress(20, "Sample of Component directives");

            #region Выборка Задач по компонентам

            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (!(row.Tag is ComponentDirective)) continue;
                if (row.Cells.Count < 3 || !(row.Cells[2] is DataGridViewCheckBoxCell))
                    continue;
                ComponentDirective directive = row.Tag as ComponentDirective;
                DataGridViewCheckBoxCell printCell = (DataGridViewCheckBoxCell)row.Cells[2];
                if (!(bool)printCell.Value && selectedComponentDirectives.FirstOrDefault(sm => sm.ItemId == directive.ItemId) != null)
                {
                    selectedComponentDirectives.Remove(directive);
                }
            }
            #endregion

            _animatedThreadWorker.ReportProgress(25, "Sample of Components");

            #region Выборка компонентов

            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (!(row.Tag is Component)) continue;
                if (row.Cells.Count < 3 || !(row.Cells[2] is DataGridViewCheckBoxCell))
                    continue;
                Component directive = row.Tag as Component;
                DataGridViewCheckBoxCell printCell = (DataGridViewCheckBoxCell)row.Cells[2];
                if (!(bool)printCell.Value && selectedComponents.FirstOrDefault(sm => sm.ItemId == directive.ItemId) != null)
                {
                    selectedComponents.Remove(directive);
                }
            }
            #endregion

            _animatedThreadWorker.ReportProgress(30, "Sample of Non-routine jobs");

            #region Выборка нерутинных работ

            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (!(row.Tag is NonRoutineJob)) continue;
                if (row.Cells.Count < 3 || !(row.Cells[2] is DataGridViewCheckBoxCell))
                    continue;
                NonRoutineJob directive = row.Tag as NonRoutineJob;
                DataGridViewCheckBoxCell printCell = (DataGridViewCheckBoxCell)row.Cells[2];
                if (!(bool)printCell.Value && selectedNrjs.FirstOrDefault(sm => sm.ItemId == directive.ItemId) != null)
                {
                    selectedNrjs.Remove(directive);
                }
            }
            #endregion

            _selectedItems.Clear();
            _selectedItems.AddRange(selectedChecks.ToArray());
            _selectedItems.AddRange(selectedMpds.ToArray());
            _selectedItems.AddRange(selectedADs.ToArray());
            _selectedItems.AddRange(selectedDamages.ToArray());
            _selectedItems.AddRange(selectedOofs.ToArray());
            _selectedItems.AddRange(selectedDeffereds.ToArray());
            _selectedItems.AddRange(selectedComponentDirectives.ToArray());
            _selectedItems.AddRange(selectedComponents.ToArray());
            _selectedItems.AddRange(selectedNrjs.ToArray());

        }
        #endregion

        #region private void Save()
        /// <summary>
        /// Сохраняет настроики печати элементов
        /// </summary>
        private void Save()
        {
            //foreach (DataGridViewRow row in dataGridViewItems.Rows)
            //{
            //    if (!(row.Tag is MaintenanceDirective)) continue;
            //    if (row.Cells.Count < 3 || !(row.Cells[2] is DataGridViewCheckBoxCell))
            //        continue;
            //    MaintenanceDirective mpd = row.Tag as MaintenanceDirective;
            //    DataGridViewCheckBoxCell printCell = (DataGridViewCheckBoxCell)row.Cells[2];

            //    mpd.PrintInWorkPackage = (bool) printCell.Value;

            //    try
            //    {
            //        GlobalObjects.CasEnvironment.Keeper.Save(mpd, false);
            //    }
            //    catch (Exception ex)
            //    {
            //        Program.Provider.Logger.Log("Error while save print settings", ex);
            //    }
            //}        
        }
        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)
        private void ButtonOkClick(object sender, EventArgs e)
        {
            _animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoCreate;
            _animatedThreadWorker.RunWorkerCompleted -= BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerCreateCompleted;

            _animatedThreadWorker.RunWorkerAsync();

            //Save();

            DialogResult = DialogResult.OK;
            //Close();
        }
        #endregion

        #endregion
    }
}
