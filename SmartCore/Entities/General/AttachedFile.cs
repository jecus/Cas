using System;
using System.Collections.Generic;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General
{
    /// <summary>
    /// �����, ��������� ������������� ����
    /// </summary>
    [Table("Files","dbo","ItemId")]
    [Dto(typeof(AttachedFileDTO))]
	[Serializable]
    public class AttachedFile : BaseEntityObject, IEquatable<AttachedFile>, IEqualityComparer<AttachedFile>
    {

        /*
        *  ��������
        */

        #region public String FileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private string _fileName;
        [TableColumnAttribute("FileName")]
        public String FileName
        {
            get { return _fileName; }
            set
            {
                if (_fileName != value)
                {
                    _fileName = value;
                    OnPropertyChanged("FileName");
                }
            }
        }
        #endregion

        #region public Byte[] FileData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private byte[] _fileData;
        [TableColumnAttribute("FileData", forced:true )]
        public Byte[] FileData
        {
            get { return _fileData; }
            set
            {
                if (_fileData != value)
                {
                    _fileData = value;
                    OnPropertyChanged("FileData");
                }
            }
        }
        #endregion

        #region int? FileSize

        private int? _fileSize;
	    [TableColumnAttribute("FileSize", ColumnAccessType.ReadOnly)]
        public int? FileSize
        {
            get { return _fileSize; }
            set
            {
                if (_fileSize != value)
                {
                    _fileSize = value;
                    OnPropertyChanged("FileSize");
                }
            }
        }


		#endregion

	    #region Implement of IEquatable

        #region public bool Equals(AttachedFile other)
        public bool Equals(AttachedFile other)
        {
            //��� ��������������� ������ GetHashCode ������ ����� �� ��������
            //������? - ��

            //Check whether the compared object is null.
            if (ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return FileName == other.FileName && FileSize == other.FileSize;
        }
        #endregion

        #region public override int GetHashCode()
        public override int GetHashCode()
        {
            int fileNameHash = _fileName.GetHashCode();
            int fileSizeHash = Convert.ToInt32(_fileSize).GetHashCode();

            return fileSizeHash ^ fileNameHash;
        }
        #endregion

        #endregion

        #region IEqualityComparer<AttachedFile>

        #region public bool Equals(AttachedFile x, AttachedFile y)
        public bool Equals(AttachedFile x, AttachedFile y)
        {
            //��� ��������������� ������ GetHashCode(AttachedFile) ������ ����� �� ��������
            //������? - ��

            //Check whether the compared object references the same data.
            if (ReferenceEquals(x, y)) return true;

            //Check whether the compared object is null.
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;

            //Check whether the products' properties are equal.
            return x.FileName == y.FileName && x.FileSize == y.FileSize;
        }
        #endregion

        #region public int GetHashCode(AttachedFile lifelength)
        public int GetHashCode(AttachedFile lifelength)
        {
            if (ReferenceEquals(lifelength, null) == true)
                return 0;
            int fileNameHash = _fileName.GetHashCode();
            int fileSizeHash = Convert.ToInt32(_fileSize).GetHashCode();

            return fileSizeHash ^ fileNameHash;
        }
        #endregion

        #endregion

        /*
		*  ������ 
		*/

        #region public AttachedFile()
        /// <summary>
        /// ������� ������������� ��� �������������� ����������
        /// </summary>
        public AttachedFile()
        {
            ItemId = -1;
            IsDeleted = false;
			SmartCoreObjectType = SmartCoreType.AttachedFile;
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// ����������� ��� �������
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FileSize != null ? $"Size: {FileSize} bytes" : "File is null";
        }
        #endregion
    }
}
