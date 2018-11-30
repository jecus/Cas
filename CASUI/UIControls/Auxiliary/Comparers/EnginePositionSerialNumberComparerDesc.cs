using System.Collections.Generic;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Aircrafts.Parts.Templates;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{

    #region public class EnginePositionSerialNumberComparerDesc : IComparer<Engine>

    /// <summary>
    /// Сравнивалка <see cref="Engine"/>
    /// </summary>
    public class EnginePositionSerialNumberComparerDesc : IComparer<Engine>
    {
        #region IComparer<Engine> Members

        ///<summary>
        ///Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        ///</summary>
        ///
        ///<returns>
        ///Value Condition Less than zerox is less than y.Zerox equals y.Greater than zerox is greater than y.
        ///</returns>
        ///
        ///<param name="y">The second object to compare.</param>
        ///<param name="x">The first object to compare.</param>
        public int Compare(Engine x, Engine y)
        {
            return string.Compare(y.PositionNumber, x.PositionNumber) == 0 ? string.Compare(y.SerialNumber, x.SerialNumber) : string.Compare(y.PositionNumber, x.PositionNumber);
        }

        #endregion
    }

    #endregion

    #region public class TemplateEnginePositionSerialNumberComparerDesc : IComparer<TemplateEngine>

    /// <summary>
    /// Сравнивалка <see cref="TemplateEngine"/>
    /// </summary>
    public class TemplateEnginePositionSerialNumberComparerDesc : IComparer<TemplateEngine>
    {
        #region IComparer<Engine> Members

        ///<summary>
        ///Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        ///</summary>
        ///
        ///<returns>
        ///Value Condition Less than zerox is less than y.Zerox equals y.Greater than zerox is greater than y.
        ///</returns>
        ///
        ///<param name="y">The second object to compare.</param>
        ///<param name="x">The first object to compare.</param>
        public int Compare(TemplateEngine x, TemplateEngine y)
        {
            return string.Compare(x.Model, y.Model);
        }

        #endregion
    }

    #endregion
    
}
