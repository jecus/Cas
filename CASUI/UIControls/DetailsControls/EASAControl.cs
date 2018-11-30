using System.Drawing;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.DetailsControls
{
    public class EASAControl : WindowsFormAttachedFileControl
    {
        #region Fields

        private readonly AbstractDetail currentDetail;

        #endregion


        #region Constructor

        public EASAControl(AbstractDetail detail, string filter, string description1, string description2, Image icon)
        {
            currentDetail = detail;
            AttachedFile attachedFile = new AttachedFile();
            attachedFile.FileData = currentDetail.EASAdata;
            attachedFile.FileName = "EASA Form 8330.pdf";
            AttachedFile = attachedFile;
            this.filter = filter;
            this.description1 = description1;
            this.description2 = description2;
            this.icon = icon;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region Methods

        #region public override void UpdateInformation()

        /// <summary>
        /// Обновляет информацию
        /// </summary>
        public void UpdateInformation()
        {
            if (AttachedFile != null)
                AttachedFile.FileData = currentDetail.EASAdata;
            UpdateInfo();
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            if (currentDetail.EASAdata == null) 
            {
                if (AttachedFile == null)
                    return false;
                else
                    return AttachedFile.FileData != null;
            }
            else
            {
                if (AttachedFile == null)
                    return true;
                else
                    return AttachedFile.FileData != currentDetail.EASAdata;
            }
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные заданного агрегата
        /// </summary>
        public void SaveData()
        {
            if (AttachedFile == null)
            {
                if (currentDetail.EASAdata != null)
                    currentDetail.EASAdata = null;
            }
            else
            {
                if (currentDetail.EASAdata != AttachedFile.FileData)
                    currentDetail.EASAdata = AttachedFile.FileData;
            }
        }

        #endregion

        #endregion

        
    }
}
