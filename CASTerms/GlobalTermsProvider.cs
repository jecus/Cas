using System.IO;

namespace CASTerms
{
    ///<summary>
    /// Provider of some project information. 
    ///</summary>
    public class GlobalTermsProvider: IndexAccessElementProvider
    {
        #region Fields

        protected static readonly Hash ContainedElements;
        #endregion

        #region Constructors


        #region static GlobalTermsProvider()
        /// <summary>
        /// initializes static members of <see cref="GlobalTermsProvider" />
        /// </summary>
        static GlobalTermsProvider()
        {
            ContainedElements = new Hash();
            FillHash(ContainedElements);
        }
        #endregion

        #endregion

        #region Indexers

        #region public override CoreType this[int keyCode]
        /// <summary>
        /// Returns an item from terms dictionary by it's code
        /// </summary>
        /// <param name="keyCode">Key code of requested item </param>
        /// <returns></returns>
        public override object this[int keyCode]
        {
            get
            {
                return null;
            }
        }
        #endregion

        #region public override CoreType this[string key]
        /// <summary>
        /// Returns an item from terms dictionary by specified key
        /// </summary>
        /// <param name="key">Key of requested term</param>
        /// <returns></returns>
        public override object this[string key]
        {
            get
            {
                return ContainedElements[key];
            }
        }
        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Fills hash with project terms information
        /// </summary>
        /// <param name="hash"></param>
        protected static void FillHash(Hash hash)
        {
            hash.Add("ProductWebsite", "");
            hash.Add("SystemShortName", "CAS");
            hash.Add("SystemName", "Continuing Airworthiness System");
            hash.Add("DeleteQuestion", "Do you really want to delete current {0}?");
            hash.Add("DeleteQuestionSeveral", "Do you really want to delete selected {0}?");
            hash.Add("CutOffSubCheckQuestion", "Do you really want to cutoff selected subcheck?");
            hash.Add("ReportFooter", @"I hereby certify that the data specified above has been verified throughout. Authorize signature ________________________");
            hash.Add("ReportFooterPrepared", @"Produced by CAS ");
            hash.Add("ReportFooterLink", @"Visit www.avalonkg.com/cas for more information.");
            hash.Add("JobCardFooterPrepared", @"This job card was prepared by Continuing Airworthiness System.");
            hash.Add("Copyright", " 2006-2021 Avalon Worldgroup Inc. All rights reserved");
            hash.Add("CopyrightMultiline", " 2006-2021\r\nAvalon  Worldgroup Inc.\r\nAll rights reserved");
            hash.Add("CompanyName", "Avalon Worldgroup Inc.");
            hash.Add("CompanyNameIO", "Avalon Worldgroup Inc");
            //hash.Add("RussianLanguage", "");
            //hash.Add("EnglishLanguage", "English");
            hash.Add("ProductVersion", "3.1");
            hash.Add("ProductBuild", "4800");//<<$SvnVersion$>>
            hash.Add("DateFormat","dd.MM.yyyy");
            hash.Add("DateFormatShort","dd.MM.yy");
            hash.Add("ReverseDateFormat","yyyy.MM.dd");
            hash.Add("CAARequirements", "The work specified / recordered was carried out in accordance" +
                                        " with the requirements of the Republic of Seychelles - Civil Aviation" +
                                        " Authority (CAA) and EASA - 145 and, in that respect, the aircraft" +
                                        " / equipment considered to be fit for release to service under Seychelles Approval" +
                                        " - Air Operations Certificate (AOC) No. 001 (January 01, 2000)");
            hash.Add("Revision", "PA EF 25 R0/January2000");

        }

        #region public  string GetLoginSettingsPath()

        /// <summary>
        /// Возаращает папку для сохранения настроек подключения
        /// </summary>
        /// <returns></returns>
        public string GetLoginSettingsPath()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData) + "\\"
                   + this["CompanyNameIO"] + "\\"
                   + this["SystemName"]
                   + "\\LoginSettings.xml";
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Directory.Exists)
                fileInfo.Directory.Create();
            return path;
        }

        #endregion



        #endregion

    }
}
