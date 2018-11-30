using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    /// <summary>
    /// Описывает интерфейс древовидного словаря
    /// </summary>
    public interface IDictionaryTreeItem : IDictionaryItem
    {
        /// <summary>
        /// Родительский узел элемента
        /// </summary>
        IDictionaryTreeItem Parent { get; }

        /// <summary>
        /// Предыдущий элемент на уровне
        /// </summary>
        IDictionaryTreeItem Prev { get; }

        /// <summary>
        /// Следующий элемент на уровне
        /// </summary>
        IDictionaryTreeItem Next { get; }

        /// <summary>
        /// Дочерние элементы данного элемента
        /// </summary>
        IDictionaryCollection Children { get; }

        /// <summary>
        /// Возвращает значение является ли данный узел равным или подузлом переданного элемента
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        bool IsNodeOrSubNodeOf(IDictionaryTreeItem node);
    }
}
