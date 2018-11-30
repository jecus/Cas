namespace SmartCore.Calculations
{
    public abstract class ByteConvertible
    {
        #region public static ByteConvertible ConvertFromByteArray(byte[] data)
        /// <summary>
        /// Конвертирует данные из последовательности баитов в объект 
        /// </summary>
        /// <param name="data"></param>
        public static ByteConvertible ConvertFromByteArray(byte[] data)
        {
            return null;
        }

        #endregion

        #region public byte[] ConvertToByteArray()
        ///<summary>
        /// Создается массив байт, представляющий оъект для сохранения в базе
        ///</summary>
        ///<returns>Созданные данные</returns>
        public byte[] ConvertToByteArray()
        {
            return null;
        }
        #endregion
    }
}
