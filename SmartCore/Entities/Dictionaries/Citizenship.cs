using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class Citizenship : StaticDictionary
	{
		#region private static List<Education> _Items = new List<Education>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<Citizenship> _Items = new CommonDictionaryCollection<Citizenship>();
		#endregion

		public static Citizenship Australia = new Citizenship(1, "AUS", "Australia");
		public static Citizenship Austria = new Citizenship(2, "AUT", "Austria");
		public static Citizenship Azerbaijan = new Citizenship(3, "AZE", "Azerbaijan");
		public static Citizenship Albania = new Citizenship(4, "ALB", "Albania");
		public static Citizenship Algeria = new Citizenship(5, "DZA", "Algeria");
		public static Citizenship Anguilla = new Citizenship(6, "AIA", "Anguilla");
		public static Citizenship Angola = new Citizenship(7, "AGO", "Angola");
		public static Citizenship Andorra = new Citizenship(8, "AND", "Andorra");
		public static Citizenship Argentina = new Citizenship(9, "ARG", "Argentina");
		public static Citizenship Armenia = new Citizenship(10, "ARM", "Armenia");
		public static Citizenship Afghanistan = new Citizenship(11, "AFG", "Afghanistan");
		public static Citizenship Bahamas = new Citizenship(12, "BHS", "Bahamas");
		public static Citizenship Bangladesh = new Citizenship(13, "BGD", "Bangladesh");
		public static Citizenship Barbados = new Citizenship(14, "BRB", "Barbados");
		public static Citizenship Bahrain = new Citizenship(15, "BHR", "Bahrain");
		public static Citizenship Belarus = new Citizenship(16, "BLR", "Belarus");
		public static Citizenship Belize = new Citizenship(17, "BLZ", "Belize");
		public static Citizenship Belgium = new Citizenship(18, "BEL", "Belgium");
		public static Citizenship Benin = new Citizenship(19, "BEN", "Benin");
		public static Citizenship Bermuda = new Citizenship(20, "BMU", "Bermuda");
		public static Citizenship Bulgaria = new Citizenship(21, "BGR", "Bulgaria");
		public static Citizenship Bolivia = new Citizenship(22, "BOL", "Bolivia");
		public static Citizenship BosniaHerzegovina = new Citizenship(23, "BIH", "Bosnia & Herzegovina");
		public static Citizenship Brazil = new Citizenship(24, "BRA", "Brazil");
		public static Citizenship BruneiDarussalam = new Citizenship(25, "BRN", "Brunei Darussalam");
		public static Citizenship Burundi = new Citizenship(26, "BDI", "Burundi");
		public static Citizenship Vatican = new Citizenship(27, "VAT", "Vatican ");
		public static Citizenship Gabon = new Citizenship(28, "GAB", "Gabon");
		public static Citizenship Gambia = new Citizenship(29, "GMB", "Gambia");
		public static Citizenship Ghana = new Citizenship(30, "GHA", "Ghana");
		public static Citizenship Germany = new Citizenship(31, "DEU", "Germany");
		public static Citizenship Gibraltar = new Citizenship(32, "GIB", "Gibraltar");
		public static Citizenship GreatBritain = new Citizenship(33, "GBR", "Great Britain");
		public static Citizenship Guadeloupe = new Citizenship(34, "GLP", "Guadeloupe");
		public static Citizenship Guatemala = new Citizenship(35, "GTM", "Guatemala");
		public static Citizenship Guinea = new Citizenship(36, "GIN", "Guinea");
		public static Citizenship Guyana = new Citizenship(37, "GUY", "Guyana");
		public static Citizenship Haiti = new Citizenship(38, "HTI", "Haiti");
		public static Citizenship Hungary = new Citizenship(39, "HUN", "Hungary");
		public static Citizenship Honduras = new Citizenship(40, "HND", "Honduras");
		public static Citizenship HongKong = new Citizenship(41, "HKG", "Hong Kong");
		public static Citizenship Grenada = new Citizenship(42, "GRD", "Grenada");
		public static Citizenship Greenland = new Citizenship(43, "GRL", "Greenland");
		public static Citizenship Greece = new Citizenship(44, "GRC", "Greece");
		public static Citizenship Georgia = new Citizenship(45, "GEO", "Georgia");
		public static Citizenship Denmark = new Citizenship(46, "DNK", "Denmark");
		public static Citizenship Dominica = new Citizenship(47, "DMA", "Dominica");
		public static Citizenship DominicanRepublic = new Citizenship(48, "DOM", "Dominican Republic");
		public static Citizenship Egypt = new Citizenship(49, "EGY", "Egypt");
		public static Citizenship Zambia = new Citizenship(50, "ZMB", "Zambia");
		public static Citizenship Zimbabwe = new Citizenship(51, "ZWE", "Zimbabwe");
		public static Citizenship Israel = new Citizenship(52, "ISR", "Israel");
		public static Citizenship India = new Citizenship(53, "IND", "India");
		public static Citizenship Indonesia = new Citizenship(54, "IDN", "Indonesia");
		public static Citizenship Jordan = new Citizenship(55, "JOR", "Jordan");
		public static Citizenship Iraq = new Citizenship(56, "IRQ", "Iraq");
		public static Citizenship Iran = new Citizenship(57, "IRN", "Iran");
		public static Citizenship Ireland = new Citizenship(58, "IRL", "Ireland");
		public static Citizenship Iceland = new Citizenship(59, "ISL", "Iceland");
		public static Citizenship Spain = new Citizenship(60, "ESP", "Spain");
		public static Citizenship Italy = new Citizenship(61, "ITA", "Italy");
		public static Citizenship Yemen = new Citizenship(62, "YEM", "Yemen");
		public static Citizenship CapeVerde = new Citizenship(63, "CPV", "Cape Verde");
		public static Citizenship Kazakhstan = new Citizenship(64, "KAZ", "Kazakhstan");
		public static Citizenship CaymanIslands = new Citizenship(65, "CYM", "Cayman Islands");
		public static Citizenship Cambodia = new Citizenship(66, "KHM", "Cambodia");
		public static Citizenship Cameroon = new Citizenship(67, "CMR", "Cameroon");
		public static Citizenship Canada = new Citizenship(68, "CAN", "Canada");
		public static Citizenship Qatar = new Citizenship(69, "QAT", "Qatar");
		public static Citizenship Kenya = new Citizenship(70, "KEN", "Kenya");
		public static Citizenship Cyprus = new Citizenship(71, "CYP", "Cyprus");
		public static Citizenship Kyrgyzstan = new Citizenship(72, "KGZ", "Kyrgyzstan");
		public static Citizenship China = new Citizenship(73, "CHN", "China");
		public static Citizenship Colombia = new Citizenship(74, "COL", "Colombia");
		public static Citizenship Congo = new Citizenship(75, "COG", "Congo");
		public static Citizenship CostaRica = new Citizenship(76, "CRI", "Costa Rica");
		public static Citizenship Cuba = new Citizenship(77, "CUB", "Cuba");
		public static Citizenship Kuwait = new Citizenship(78, "KWT", "Kuwait");
		public static Citizenship Latvia = new Citizenship(79, "LVA", "Latvia");
		public static Citizenship Lesotho = new Citizenship(80, "LSO", "Lesotho");
		public static Citizenship Liberia = new Citizenship(81, "LBR", "Liberia");
		public static Citizenship Lebanon = new Citizenship(82, "LBN", "Lebanon");
		public static Citizenship Lithuania = new Citizenship(83, "LTU", "Lithuania");
		public static Citizenship Liechtenstein = new Citizenship(84, "LIE", "Liechtenstein");
		public static Citizenship Luxembourg = new Citizenship(85, "LUX", "Luxembourg");
		public static Citizenship Mauritania = new Citizenship(86, "MRT", "Mauritania");
		public static Citizenship Madagascar = new Citizenship(87, "MDG", "Madagascar");
		public static Citizenship Macau = new Citizenship(88, "MAC", "Macau ");
		public static Citizenship Macedonia = new Citizenship(89, "MKD", "Macedonia ");
		public static Citizenship Malaysia = new Citizenship(90, "MYS", "Malaysia ");
		public static Citizenship Maldives = new Citizenship(91, "MDV", "Maldives ");
		public static Citizenship Malta = new Citizenship(92, "MLT", "Malta ");
		public static Citizenship Marocco = new Citizenship(93, "MAR", "Marocco ");
		public static Citizenship Mexico = new Citizenship(94, "MEX", "Mexico ");
		public static Citizenship Moldova = new Citizenship(95, "MDA", "Moldova ");
		public static Citizenship Monaco = new Citizenship(96, "MCO", "Monaco ");
		public static Citizenship Mongolia = new Citizenship(97, "MNG", "Mongolia ");
		public static Citizenship Myanmar = new Citizenship(98, "MMR", "Myanmar ");
		public static Citizenship Nepal = new Citizenship(99, "NPL", "Nepal ");
		public static Citizenship Nigeria = new Citizenship(100, "NGA", "Nigeria ");
		public static Citizenship Netherlands = new Citizenship(101, "NLD", "Netherlands");
		public static Citizenship NewZealand = new Citizenship(102, "NZL", "New Zealand");
		public static Citizenship Norway = new Citizenship(103, "NOR", "Norway");
		public static Citizenship UnitedArabEmirates = new Citizenship(104, "ARE", "United Arab Emirates");
		public static Citizenship Oman = new Citizenship(105, "OMN", "Oman");
		public static Citizenship Pakistan = new Citizenship(106, "PAK", "Pakistan");
		public static Citizenship Panama = new Citizenship(107, "PAN", "Panama");
		public static Citizenship Paraguay = new Citizenship(108, "PRY", "Paraguay");
		public static Citizenship Peru = new Citizenship(109, "PER", "Peru");
		public static Citizenship Poland = new Citizenship(110, "POL", "Poland");
		public static Citizenship Portugal = new Citizenship(111, "PRT", "Portugal");
		public static Citizenship PuertoRico = new Citizenship(112, "PRI", "Puerto Rico");
		public static Citizenship Russia = new Citizenship(113, "RUS", "Russia");
		public static Citizenship Romania = new Citizenship(114, "ROM", "Romania");
		public static Citizenship SanMarino = new Citizenship(115, "SMR", "San Marino");
		public static Citizenship SaudiArabia = new Citizenship(116, "SAU", "Saudi Arabia");
		public static Citizenship SaintLucia = new Citizenship(117, "LCA", "Saint Lucia");
		public static Citizenship Singapore = new Citizenship(118, "SGP", "Singapore");
		public static Citizenship Syria = new Citizenship(119, "SYR", "Syria");
		public static Citizenship SlovakRepublic = new Citizenship(120, "SVK", "Slovak Republic");
		public static Citizenship Slovenia = new Citizenship(121, "SVN", "Slovenia");
		public static Citizenship USA = new Citizenship(122, "USA", "United States of America");
		public static Citizenship Sudan = new Citizenship(123, "SDN", "Sudan");
		public static Citizenship Tadjikistan = new Citizenship(124, "TJK", "Tadjikistan");
		public static Citizenship Thailand = new Citizenship(125, "THA", "Thailand");
		public static Citizenship Taiwan = new Citizenship(126, "TWN", "Taiwan");
		public static Citizenship Tanzania = new Citizenship(127, "TZA", "Tanzania");
		public static Citizenship Togo = new Citizenship(128, "TGO", "Togo");
		public static Citizenship Tunisia = new Citizenship(129, "TUN", "Tunisia");
		public static Citizenship Turkmenistan = new Citizenship(130, "TKM", "Turkmenistan");
		public static Citizenship Turkey = new Citizenship(131, "TUR", "Turkey");
		public static Citizenship Uganda = new Citizenship(132, "UGA", "Uganda");
		public static Citizenship Uzbekistan = new Citizenship(133, "UZB", "Uzbekistan");
		public static Citizenship Ukraine = new Citizenship(134, "UKR", "Ukraine");
		public static Citizenship Uruguay = new Citizenship(135, "URY", "Uruguay");
		public static Citizenship Philippines = new Citizenship(136, "PHL", "Philippines");
		public static Citizenship Finland = new Citizenship(137, "FIN", "Finland");
		public static Citizenship France = new Citizenship(138, "FRA", "France");
		public static Citizenship Croatia = new Citizenship(139, "HRV", "Croatia");
		public static Citizenship Africa = new Citizenship(140, "CAF", "Africa");
		public static Citizenship CzechRepublic = new Citizenship(141, "CZE", "Czech Republic");
		public static Citizenship Chili = new Citizenship(142, "CHL", "Chili");
		public static Citizenship Switzerland = new Citizenship(143, "CHE", "Switzerland");
		public static Citizenship Sweden = new Citizenship(144, "SWE", "Sweden");
		public static Citizenship SriLanka = new Citizenship(145, "LKA", "Sri Lanka");
		public static Citizenship Ecuador = new Citizenship(146, "ECU", "Ecuador");
		public static Citizenship Estonia = new Citizenship(147, "EST", "Estonia");
		public static Citizenship Korea = new Citizenship(148, "KOR", "Korea ");
		public static Citizenship Jamaica = new Citizenship(149, "JAM", "Jamaica");
		public static Citizenship Japan = new Citizenship(150, "JPN", "Japan");
		public static Citizenship Venezuela = new Citizenship(151, "VEN", "Venezuela");
		public static Citizenship VietNam = new Citizenship(152, "VNM", "Viet Nam");

		#region public static Education UNK = new Education(-1, "UNK", "Unknown");

		public static Citizenship UNK = new Citizenship(-1, "UNK", "Unknown");

		#endregion

		/*
		 * Методы
		 */
		#region public static Citizenship GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static Citizenship GetItemById(Int32 maintenanceTypeId)
		{
			foreach (Citizenship t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<Citizenship> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<Citizenship> Items
		{
			get
			{
				return _Items;
			}
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// Переводит тип директивы в строку
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"{FullName} ({ShortName})";
		}
		#endregion

		/*
		 * Реализация
		 */
		#region public Citizenship()
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		public Citizenship()
		{
		}
		#endregion

		#region public Citizenship(Int32 itemID, String shortName, String fullName)
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public Citizenship(Int32 itemId, String shortName, String fullName)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;

			_Items.Add(this);
		}
		#endregion

		#region public override int CompareTo(object y)
		public override int CompareTo(object y)
		{
			if (y is Citizenship)
				return FullName.CompareTo(((Citizenship)y).FullName);
			return 0;
		}
		#endregion
	}
}