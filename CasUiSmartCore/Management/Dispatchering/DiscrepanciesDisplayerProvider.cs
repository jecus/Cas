/*
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using SmartCore.Entities.General;

namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    /// Класс, возвращающий <see cref="IDisplayer"/> для <see cref="IMaintainable"/>
    /// </summary>
    public class DiscrepanciesDisplayerProvider
    {
        Dictionary<Type, Type> typeHash = new Dictionary<Type, Type>();

        /// <summary>
        /// Creates an instance of <see cref="DiscrepanciesDisplayerProvider" />
        /// </summary>
        public DiscrepanciesDisplayerProvider()
        {
            typeHash.Add(typeof(AbstractDetail), typeof(DispatcheredDetailScreen));
            typeHash.Add(typeof(BaseDetailDirective), typeof(DispatcheredDirectiveScreen));
            typeHash.Add(typeof(MaintenanceDirective), typeof(DispatcheredMaintenanceStatusControl));
        }

        /// <summary>
        /// Returns new displayer for specified entity
        /// </summary>
        /// <param name="item">Specified entity to display in displayer</param>
        /// <returns></returns>
        public IDisplayingEntity GetDisplayer(IMaintainable item)
        {
            Type displayerType = null;
            Type type = item.GetType();

            foreach (KeyValuePair<Type, Type> pair in typeHash)
            {
                if (type.IsSubclassOf(pair.Key)) displayerType = pair.Value;
            }
            if (null == displayerType) throw new ArgumentException("Cannot find displayer for specified type", "type");
            if (displayerType==typeof(DispatcheredDirectiveScreen))
            {
                if ((((BaseDetailDirective)item)).DirectiveType == DirectiveTypeCollection.Instance.OutOffPhaseDirectiveType)
                    displayerType = typeof(DispatcheredOutOffPhaseReferenceScreen);
                else if ((((BaseDetailDirective)item)).DirectiveType == DirectiveTypeCollection.Instance.CPCPDirectiveType)
                    displayerType = typeof(DispatcheredCPCPDirectiveScreen);
            }
            Assembly assembly = Assembly.GetAssembly(displayerType);
            List<object> parameters = new List<object>();

            parameters.Add(item);
            object result =
                assembly.CreateInstance(displayerType.FullName, true, BindingFlags.CreateInstance, null,
                                        parameters.ToArray(), CultureInfo.CurrentCulture, null);

            return result as IDisplayingEntity;
        }
    }

}
*/
