using System;

namespace Entity.Abstractions.Attributte
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class ConditionAttribute : Attribute
	{
		private string _columnName;
		private object _condition;

		public ConditionAttribute(string tableColumnName, object condition)
		{
			_columnName = tableColumnName;
			_condition = condition;
		}

		public string ColumnName
		{
			get { return _columnName; }
		}

		public object Condition
		{
			get { return _condition; }
		}
	}
}