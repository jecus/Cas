using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.ObjectCache
{
    public class CommonEntitiesCache : ICommonEntitiesCache
    {
        public ICommonCollection GetObjectCollection()
        {
            throw new NotImplementedException();
        }

        public ICommonCollection<T> GetObjectCollection<T>() where T : IBaseEntityObject
        {
            throw new NotImplementedException();
        }
    }
}
