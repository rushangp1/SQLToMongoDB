using DataMigration.Common;
using DataMigration.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataMigration.DBManagerService
{
    public class MongoDBService : IMongoDBService
    {
        private readonly MongoDBSettings _mongoDBSettings;
        private readonly MongoClient _dbClient;
        private readonly IMongoDatabase _db;
        public MongoDBService(MongoDBSettings mongoDBSettings)
        {
            _mongoDBSettings = mongoDBSettings;
            _dbClient = new MongoClient(mongoDBSettings.ConnectionString);
            _db = _dbClient.GetDatabase(mongoDBSettings.DatabaseName);
        }
        public void InsertOne<T>(T TData) where T : class
        {
            var collection = GetCollection<T>();
            collection.InsertOne(TData);
        }
        public void InsertMany<T>(IEnumerable<T> TData) where T : class
        {
            var collection = GetCollection<T>();
            collection.InsertMany(TData);
        }
        public IEnumerable<T> GetAll<T>() where T : class
        {
            var collection = GetCollection<T>();
            return collection.Find(x => true).ToList();
        }
        private string GetCollectionName(Type collection)
        {
            var attribute = (collection.GetCustomAttributes(collection, true)).FirstOrDefault();
            string retVal = "";
            if (attribute != null)
            {
                retVal = (attribute as CustomAttributes.Collection).CollectionName;
            }
            else
            {
                retVal = collection.Name;
            }
            return retVal;
        }
        public IMongoCollection<T> GetCollection<T>() where T : class
        {
            return _db.GetCollection<T>(GetCollectionName(typeof(T)));
        }
    }
}
