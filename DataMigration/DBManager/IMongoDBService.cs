using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataMigration.DBManagerService
{
    public interface IMongoDBService
    {
        void InsertOne<T>(T TData) where T : class;
        void InsertMany<T>(IEnumerable<T> TData) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        IMongoCollection<T> GetCollection<T>() where T : class;

    }
}
