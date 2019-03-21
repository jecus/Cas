using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SmartCore.Entities.General.Directives;

namespace CAS.UI.ExcelExport
{
	public class DirectiveComparer : IComparer<Directive>
	{
		public int Compare(Directive x, Directive y)
		{
			string Pattern = "^\\s*(?<Year>\\d+)\\-(?<Number1>\\d+)\\-(?<Number2>\\d+)?";
			var SortMultiplier = -1;

			Match xMatch = Regex.Match(x.Title, Pattern);
			Match yMatch = Regex.Match(y.Title, Pattern);
			if (xMatch.Success && yMatch.Success)
			{
				int xYear;
				int xNumber1;
				int xNumber2;
				int.TryParse(xMatch.Groups["Year"].Value, out xYear);
				int.TryParse(xMatch.Groups["Number1"].Value, out xNumber1);
				int.TryParse(xMatch.Groups["Number2"].Value, out xNumber2);
				string xParagraphLetter = "";
				if (xMatch.Groups["ParagraphLetter"].Success)
					xParagraphLetter = xMatch.Groups["ParagraphLetter"].Value;
				int xParagraphNumber = 0;
				if (xMatch.Groups["ParagraphNumber"].Success)
					xParagraphNumber = int.Parse(xMatch.Groups["ParagraphNumber"].Value);
				int yYear;
				int yNumber1;
				int yNumber2;
				int.TryParse(yMatch.Groups["Year"].Value, out yYear);
				int.TryParse(yMatch.Groups["Number1"].Value, out yNumber1);
				int.TryParse(yMatch.Groups["Number2"].Value, out yNumber2);
				string yParagraphLetter = "";
				if (yMatch.Groups["ParagraphLetter"].Success)
					yParagraphLetter = yMatch.Groups["ParagraphLetter"].Value;
				int yParagraphNumber = 0;
				if (yMatch.Groups["ParagraphNumber"].Success)
					yParagraphNumber = int.Parse(yMatch.Groups["ParagraphNumber"].Value);

				if (xYear < 100)
					xYear += 1900;
				if (yYear < 100)
					yYear += 1900;
				return (xYear == yYear)
					? (xNumber1 == yNumber1) ? (xNumber2 == yNumber2) ? (xParagraphLetter == yParagraphLetter)
						?
						(xParagraphNumber == yParagraphNumber) ? 0 : (xParagraphNumber - yParagraphNumber)
						: string.Compare(xParagraphLetter, yParagraphLetter) :
					SortMultiplier * (xNumber2 - yNumber2) : SortMultiplier * (xNumber1 - yNumber1)
					: SortMultiplier * (xYear - yYear);
			}
			if (xMatch.Success)
				return -1;
			if (yMatch.Success)
				return 1;

			return SortMultiplier * string.Compare(x.Title, y.Title);
		}
	}
}
