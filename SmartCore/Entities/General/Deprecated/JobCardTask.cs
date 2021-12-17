using System;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Deprecated
{

    /// <summary>
    /// ����� ��������� ������ ������� �����
    /// </summary>
    [Table("JobCardTasks", "dbo", "ItemId")]
    [Dto(typeof(JobCardTaskDTO))]
	[Condition("IsDeleted", "0")]
    [Serializable]
    public class JobCardTask : BaseEntityObject
    {

        /*
        *  ��������
        */

        #region public JobCard JobCard { get; set; }
        /// <summary>
		/// ������� �����, � ������ ������� ���������� ������ ������
		/// </summary>
        [TableColumn("JobCardId")]
        [Parent]
        public JobCard JobCard { get; set; }
		#endregion

        #region public JobCardTask ParentTask { get; set; }

        private int _parentTaskId;

        /// <summary>
        /// ������������ ������ ������ ������ ������� �����, 
        /// </summary>
        [TableColumn("ParentTaskId")]
        public int ParentTaskId
        {
            get { return ParentTask != null ? ParentTask.ItemId : _parentTaskId; }
            set { _parentTaskId = value; }
        }
        #endregion

        #region public JobCardTask ParentTask { get; set; }

        /// <summary>
        /// ������������ ������ ������ ������ ������� �����, 
        /// </summary>
        public JobCardTask ParentTask { get; set; }

        #endregion

        #region public String TaskNumber { get; set; }
        /// <summary>
		/// 
		/// </summary>
        [TableColumn("Number")]
        public String Number { get; set; }
		#endregion

        #region public String Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Description", -1)]
        public String Description { get; set; }
        #endregion

        #region public int Man { get; set; }
        /// <summary>
        /// ���-�� ������� ��� ���������� ������� �����
        /// </summary>
        [TableColumn("Man"), MinMaxValueAttribute(1, 1000)]
        public int Man { get; set; }
        #endregion

        #region public Double ManHours { get; set; }
        /// <summary>
        /// �������� �����������
        /// </summary>
        [TableColumn("ManHours"), MinMaxValueAttribute(0, 1000000)]
        public Double ManHours { get; set; }
        #endregion

        #region public Double Cost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Cost"), MinMaxValueAttribute(0, 1000000000)]
        public Double Cost { get; set; }
        #endregion

        #region public CommonCollection<JobCardTask> Tasks

        private CommonCollection<JobCardTask> _tasks;
        /// <summary>
        /// ��������� ������ ������
        /// </summary>
        //[Child(RelationType.OneToMany, "ParentTaskId", "ParentTask")]
        public CommonCollection<JobCardTask> Tasks
        {
            get { return _tasks ?? (_tasks = new CommonCollection<JobCardTask>()); }
            internal set
            {
                if (_tasks != value)
                {
                    if (_tasks != null)
                        _tasks.Clear();
                    if (value != null)
                        _tasks = value;
                }
            }
        }
        #endregion

        /*
		*  ������ 
		*/

        #region public JobCardTask()
        /// <summary>
        /// ������� ������ ������� ����� ��� �������������� ����������
        /// </summary>
        public JobCardTask()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.JobCardTask;
            Man = 1;
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// ����������� ��� �������
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "";
        }
        #endregion

        #region public new JobCardTask GetCopyUnsaved()

        public new JobCardTask GetCopyUnsaved(bool marked = true)
        {
            JobCardTask jobCardTask = (JobCardTask) MemberwiseClone();
            jobCardTask.ItemId = -1;
            jobCardTask.UnSetEvents();

            jobCardTask.Tasks=new CommonCollection<JobCardTask>();
            foreach (JobCardTask jobCardT in Tasks)
            {
                JobCardTask newObject = jobCardT.GetCopyUnsaved(marked);
                jobCardTask.Tasks.Add(newObject);
            }

            return jobCardTask;
        }

        #endregion
    }

}
