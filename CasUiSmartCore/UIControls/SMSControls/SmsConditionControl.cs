using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Entity.Models.DTO.Dictionaries;
using CAS.UI.Interfaces;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.SMS;

namespace CAS.UI.UIControls.SMSControls
{
    ///<summary>
    /// ЭУ для редектирования данных по запускам силовыз установок
    ///</summary>
    public partial class SmsConditionControl : EditObjectControl
    {

        #region public EventCondition EventCondition

        /// <summary>
        /// Запись с которой связан контрол
        /// </summary>
        public EventCondition EventCondition
        {
            get { return AttachedObject as EventCondition; }
            set { AttachedObject = value; }
        }
        #endregion

        #region public object ConditionValue

        /// <summary>
        /// Возвращает значение выбранное в комбобоксе
        /// </summary>
        public object ConditionValue
        {
            get { return treeDictionaryComboCond.SelectedItem; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public SmsConditionControl()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        private SmsConditionControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public SmsConditionControl(EventCondition eventCondition) : this()
        /// <summary>
        /// Контрол редактирует данные об условии наступления события
        /// </summary>
        public SmsConditionControl(EventCondition eventCondition)
            : this()
        {
            AttachedObject = eventCondition;
            Program.MainDispatcher.ProcessControl(this);
        }
        #endregion

        /*
         * Перегружаемые методы
         */

        #region public override void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {
            if (EventCondition != null)
            {
                EventCondition.Value = treeDictionaryComboCond.SelectedItem;
            }

            base.ApplyChanges();
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();

            if (EventCondition != null)
            {
                InitTree();

                if (EventCondition.ItemId > 0)
                {
                    treeDictionaryComboCond.SelectedItem = EventCondition.Value;

                    if (treeDictionaryComboCond.SelectedItem == null && EventCondition.Value != null)
                    {
                        //Искомый узел недействителен
                        treeDictionaryComboCond.Nodes.Add(new TreeNode
                                                              {
                                                                  //Name = EventCondition.Value.ToString(),
                                                                  Text = EventCondition.Value.ToString(),
                                                                  Tag = EventCondition.Value
                                                              });
                        treeDictionaryComboCond.SelectedItem = EventCondition.Value;
                    }
                }
                else
                {
                    treeDictionaryComboCond.SelectedItem = null;
                }

                if (treeDictionaryComboCond.SelectedItem != null 
                    && treeDictionaryComboCond.SelectedItem is BaseEntityObject
                    && ((BaseEntityObject)treeDictionaryComboCond.SelectedItem).IsDeleted)
                {
                    treeDictionaryComboCond.BackColor = Color.FromArgb(Highlight.Red.Color);    
                }
                else treeDictionaryComboCond.BackColor = Color.White;
            }
            EndUpdate();
        }
        #endregion

        #region public override bool CheckData()
        /// <summary>
        /// Проверяет введенные данные.
        /// Если какое-либо поле не подходит по формату, следует сразу кидать MessageBox, ставить курсор в необходимое поле и возвращать false в качестве результата метода
        /// </summary>
        /// <returns></returns>
        public override bool CheckData()
        {
            return treeDictionaryComboCond.SelectedItem != null;
        }
        #endregion

        #region private void InitTree()
        /// <summary>
        /// Инициализация древовидного словаря
        /// </summary>
        private void InitTree()
        {
            treeDictionaryComboCond.Nodes.Clear();

            #region Aircraft

            TreeNode newNode = new TreeNode { Text = "Aircraft", Name = "Aircraft" };
            treeDictionaryComboCond.Nodes.Add(newNode);
            TreeNode currentParent = newNode;

            newNode = new TreeNode { Text = "Model", Name = "Model" };
            currentParent.Nodes.Add(newNode);
            currentParent = newNode;

            IList<AircraftModel> aircraftModels;
            if(GlobalObjects.CasEnvironment != null)
                aircraftModels = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, AircraftModel>(new Filter("ModelingObjectTypeId", 7));
            else aircraftModels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, AircraftModel>(new Filter("ModelingObjectTypeId", 7));
            foreach (var o in aircraftModels)
            {
                newNode = new TreeNode { Text = o.ToString(), Name = o.ToString(), Tag = o };
                currentParent.Nodes.Add(newNode);
            }
            currentParent = currentParent.Parent;

            newNode = new TreeNode { Text = "Phase of flight", Name = "Phase of flight" };
            currentParent.Nodes.Add(newNode);
            currentParent = newNode;
            foreach (object o in Enum.GetValues(typeof(DetectionPhase)))
            {
                newNode = new TreeNode { Text = o.ToString(), Name = o.ToString(), Tag = o };
                currentParent.Nodes.Add(newNode);
            }
            #endregion

            #region Maintenance

            SmsEventArea area = SmsEventArea.Roots[0];
            currentParent = null;
            while (area != null)
            {
                newNode = new TreeNode { Text = area.ToString(), Name = area.ToString(), };
                //if (area.Children.Count == 0)
                    newNode.Tag = area;

                if (currentParent == null)
                {
                    treeDictionaryComboCond.Nodes.Add(newNode);
                }
                else
                {
                    currentParent.Nodes.Add(newNode);
                }

                if (area.Children.Count > 0)
                {
                    //Если у выбранного узла есть подузлы - осуществляется переход на первый подузел
                    area = area.Children[0];
                    currentParent = newNode;
                }
                else
                {
                    //У выбранного узла подузлов нет
                    if (area.Next != null)
                    {
                        //Если есть след. узел на этом уровне - переход на него
                        area = area.Next;
                    }
                    else
                    {
                        //На данном уровне след. узла нет.
                        SmsEventArea parent = area.Parent;
                        while (parent != null)
                        {
                            currentParent = currentParent != null ? currentParent.Parent : null;
                            //Переход вверх по дереву до тех пор, пока на уровне не появится след.узел
                            //переход на след. узел на верхнем уровне
                            if (parent.Next != null)
                            {
                                area = parent.Next;
                                break;
                            }
                            parent = parent.Parent;
                        }

                        if (parent == null)
                            area = null;
                    }
                }
            }
            #endregion
        }
        #endregion
        /*
         * Реализация
         */

        #region public bool ShowHeaders { get; set; }

        /// <summary>
        /// Отображать ли заголовки
        /// </summary>
        public bool ShowHeaders
        {
            get { return labelCondition.Visible; }
            set
            {
                labelCondition.Visible = value;
            }
        }

        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (Deleted != null)
                Deleted(this, EventArgs.Empty);
        }
        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        #endregion

    }
}
