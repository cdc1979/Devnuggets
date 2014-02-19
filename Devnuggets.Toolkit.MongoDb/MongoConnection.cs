using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Devnuggets.Toolkit.MongoDb
{
    public class MongoConnection : IDisposable
    {
        private MongoDatabase _db;
        private MongoServer _server;

        // use MongoConnectionStringFromWebConfig class (uses connectionstring key "MongoServerSettings") or inject your own

        public MongoConnection(string databaseName, IMongoConnectionstring mongoConnectionString)
        {
            MongoClient client = new MongoClient( mongoConnectionString.GetConnectionstring() );
            _server =  client.GetServer();
            _db = _server.GetDatabase(databaseName);
        }

        public MongoDatabase GetDbContext()
        {
            return _db;
        }

        public bool CreateIndex(string collection, string[] keynames)
        {
            _db.GetCollection(collection).EnsureIndex(keynames);
            return true;
        }

        public bool CopyCollection(string sourceCollection, string destinationCollection) 
        {
            if (_db.CollectionExists(destinationCollection)) 
            {
                throw new Exception("Destination collection already exists");
            }
            var source = _db.GetCollection(sourceCollection);
            var dest = _db.GetCollection(destinationCollection);
            dest.InsertBatch(source.FindAll());
            return true;
        }

        public List<CommandResult> CompactCollections(string[] collectionnames)
        {
            List<CommandResult> r = new List<CommandResult>();
            foreach (string s in collectionnames)
            {
                r.Add(CompactCollection(s));
            }
            return r;
        }

        public CommandResult CompactCollection(string collectionname)
        {
            
            return _db.RunCommand(new CommandDocument("compact", collectionname));
        }

        public string GetStats()
        {
            return JsonConvert.SerializeObject(_db.GetStats());
        }

        public CollectionStatsResult GetStats(string collectionName)
        {
            return _db.GetCollection(collectionName).GetStats();
        }

        public CommandResult RepairDatabase()
        {
            return _db.RunCommand(new CommandDocument("repairDatabase", 1));
        }

        public void Dispose()
        {
            // no need to disconnect, driver handles it
        }
    }
}
