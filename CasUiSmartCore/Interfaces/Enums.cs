using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CAS.UI.Interfaces
{
	public enum DisplayerType
	{
		/// <summary>
		/// Экран
		/// </summary>
		Screen = 1,
		/// <summary>
		/// Форма
		/// </summary>
		Form = 2,

	}

	public enum OrderFormType
	{
		Quotation = 0,
		Initial = 1,
		Purchase = 2,
	}

	public enum WorkItemsRelationTypeUI
	{
		[Description("Incorrect")]
		Incorrect = 0,

		[Description("This item depends from another")]
		ThisItemDependsFromAnother = 1,

		[Description("This item affect on another")]
		ThisItemAffectOnAnother = 2
	}

}
