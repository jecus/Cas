using System;

namespace SmartCore.Entities.General.MTOP
{
	[Serializable]
	public class Phase : BaseEntityObject, IComparable<Phase>
	{
		public int FirstPhase { get; set; }
		public int SecondPhase { get; set; }
		public bool IsZeroPhase { get; set; }

		public int Difference
		{
			get { return SecondPhase - FirstPhase; }
		}


		#region public override bool Equals(object obj)

		public override bool Equals(object obj)
		{
			return Equals(obj as Phase);
		}

		#endregion

		#region public bool Equals(Phase y)

		public bool Equals(Phase y)
		{
			if (y == null)
				return false;

			if (FirstPhase != y.FirstPhase &&
			    SecondPhase != y.SecondPhase)
				return false;

			return true;
		}

		#endregion

		public override int CompareTo(object y)
		{
			var other = y as Phase;
			if (other == null)
				return 0;

			var firstComparison = FirstPhase.CompareTo(other.FirstPhase);
			return firstComparison != 0 ? firstComparison : SecondPhase.CompareTo(other.SecondPhase);
		}

		#region public override int GetHashCode()

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		#endregion

		#region public int CompareTo(Phase other)

		public int CompareTo(Phase other)
		{
			var firstComparison = FirstPhase.CompareTo(other.FirstPhase);
			return firstComparison != 0 ? firstComparison : SecondPhase.CompareTo(other.SecondPhase);
		}

		#endregion

		#region public override string ToString()

		public override string ToString()
		{
			return IsZeroPhase ? $"0-{FirstPhase}-{Difference}" : $"1-{FirstPhase}-{Difference}";
		}

		#endregion
	}
}