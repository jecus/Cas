using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CAS.UI
{
    /// <summary>
    /// Список разработчиков системы
    /// </summary>
    public enum ActiveProgrammer
    {
        /// <summary>
        /// Предусмотрен для нормального запуска системы
        /// </summary>
        [Description("Релиз")]
        Release,
        /// <summary>
        /// 
        /// </summary>
        SergeyDomrachev,
        /// <summary>
        /// 
        /// </summary>
        SergeyFrolov,
        /// <summary>
        /// 
        /// </summary>
        DimaSemyonov,
        /// <summary>
        /// 
        /// </summary>
        PeterYeremenko,
        /// <summary>
        /// 
        /// </summary>
        AlekseyBaryshnikov,
        /// <summary>
        /// 
        /// </summary>
        ZarifSafiullin,
        /// <summary>
        /// 
        /// </summary>
        TimurIsakjanov,
        /// <summary>
        /// Дядя Вася
        /// </summary>
        Unknown,
    }
}
