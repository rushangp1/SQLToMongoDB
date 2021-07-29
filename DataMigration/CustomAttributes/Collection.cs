using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataMigration.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class Collection : Attribute
    {
        public Collection(string collectionName)
        {
            CollectionName = collectionName;
        }
        public string CollectionName { get; }
    }
}
