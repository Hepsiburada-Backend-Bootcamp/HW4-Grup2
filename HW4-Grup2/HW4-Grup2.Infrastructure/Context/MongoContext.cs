using HW4_Grup2.Domain.Repositories;
using MongoDB.Driver;

namespace HW4_Grup2.Infrastructure.Context
{
    public class MongoContext : IMongoDbContext
    {
        private static IMongoDatabase _db;
        private static MongoClient _client;
        public IMongoDatabase db => _db;

        public MongoContext()
        {
            if (_db == null)
                Init();
        }

        public void Init()
        {
            if (_client == null)
                _client = new MongoClient();

            if (_client != null && _db == null)
                _db = _client.GetDatabase("local");
        }

        //private MongoClientSettings CreateSettings()
        //{
        //    var internalIdentity = new MongoInternalIdentity("local");
        //    var passwordEvidence = new PasswordEvidence("password");
        //    var mongoCredential = new MongoCredential("SCRAM-SHA-1", internalIdentity, passwordEvidence);
        //    return new MongoClientSettings
        //    {
        //        Credential = mongoCredential,
        //        ReadPreference = ReadPreference.SecondaryPreferred,
        //        WriteConcern = WriteConcern.Acknowledged
        //    };
        //}
    }
}
