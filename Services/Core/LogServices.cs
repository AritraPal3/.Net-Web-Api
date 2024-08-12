using MongoDB.Driver;
using Capsitech.Models;
using System.Text.Json;
using MongoDB.Driver.Linq;
using Capsitech.Models.DTO;
using Capsitech.Models.DAO;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Capsitech.Services.Core
{
    public class LogServices
    {
        private readonly IMongoCollection<ChangeLogs> _logCollection;
        public LogServices(IOptions<FormDataBaseSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _logCollection = database.GetCollection<ChangeLogs>(mongoDBSettings.Value.LogCollections);
        }
        public async void CreateLog(ChangeLogs logs)
        {
            var jsonData = JsonSerializer.Serialize(logs);
            Console.WriteLine(jsonData);
            await _logCollection.InsertOneAsync(logs);
        }

        public async void UpdateLog(ChangeLogs logs)
        {
            Console.WriteLine(logs.userId);
            var filter=Builders<ChangeLogs>.Filter.Eq(s=>s.userId,logs.userId);
            var upddate=Builders<ChangeLogs>.Update
                .Set(s=>s.UpdatedBy,logs.UpdatedBy)
                .Set(s=>s.UpdatedDate,logs.UpdatedDate);
            await _logCollection.UpdateOneAsync(filter, upddate);
        }

    }
}
