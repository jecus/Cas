

namespace CASTerms
{
    /// <summary>
    ///  ласс, предназначенный дл€ управлени€ сообщени€ в CAS
    /// </summary>
    public class MessageInfoProvider:IndexAccessElementProvider
    {
        #region Fields
        
        private static Hash containedElements;

        #endregion

        #region Constructors

        #region static MessageInfoProvider()

        /// <summary>
        /// initializes static members of <see cref="MessageInfoProvider" />
        /// </summary>
        static MessageInfoProvider()
        {
            containedElements = new Hash();
            FillHash(containedElements);

        }

        #endregion

        #endregion

        #region Methods

        #region private static void FillHash(Hash hash)
        /// <summary>
        /// Fills hash with project errors information
        /// </summary>
        /// <param name="hash"></param>
        private static void FillHash(Hash hash)
        {
            hash.Add(MessageType.ConnectionError.ToString(), "");
            hash.Add(MessageType.LicenseInformationNotEqual.ToString(), "License information given during installation process is not correct.\n\rYou need to reinstall the CAS infomation system to fix this problem.");
            hash.Add(MessageType.USBKeyAbsence.ToString(), "Waiting for USB license key for {0}. Working with CAS information system without USB license key is not possible.");
            hash.Add(MessageType.USBKeyNotValid.ToString(), "Waiting for USB license key for {0}. Working with CAS information system without USB license key is not possible.");
            hash.Add(MessageType.LicenseExpired.ToString(), "License for your copy of CAS information system has expired. Please contact " + (new GlobalTermsProvider())["CompanyName"] + " at sales@avalonkg.com or visit official web site at http://www.avalonkg.com/cas/ for futher information.");
            hash.Add(MessageType.LicenseExpiresNULL.ToString(), "License information not valid");
            hash.Add(MessageType.LicenseNotFound.ToString(), "Licence not found");
            hash.Add(MessageType.DeleteError.ToString(), "Error while deleting data\n{0}");
            hash.Add(MessageType.LoadError.ToString(), "Error while opening report\n{0}");
            hash.Add(MessageType.InvalidValue.ToString(), "{0}: Invalid value");
            hash.Add(MessageType.SaveError.ToString(), "Error while saving");
            hash.Add(MessageType.LicenseViolation.ToString(), "License violation. Program will be closed.");
        }

        #endregion
        #endregion

        #region Indexers

        #region public override object this[int keyCode]

        /// <summary>
        /// Returns an item from terms dictionary by it's code
        /// </summary>
        /// <param name="keyCode">Key code of requested item </param>
        /// <returns></returns>
        public override object this[int keyCode]
        {
            get { return containedElements[keyCode]; }
        }

        #endregion

        #region public override object this[string key]

        /// <summary>
        /// Returns an item from terms dictionary by specified key
        /// </summary>
        /// <param name="key">Key of requested term</param>
        /// <returns></returns>
        public override object this[string key]
        {
            get { return containedElements[key]; }
        }

        #endregion

        #endregion

    }
}