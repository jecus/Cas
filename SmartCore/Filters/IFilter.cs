namespace SmartCore.Filters
{
    ///<summary>
    ///</summary>
    public interface IFilter
    {
        ///<summary>
        /// Проверяется, подходит ли элемент под фильтр
        ///</summary>
        ///<param name="item">Проверяемый элемент</param>
        ///<returns>Результат - подходит ли элемент</returns>
        bool Acceptable(object item);
    }
}