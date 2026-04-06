using MongoDB.Bson;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Telemetry.Api.Application.Interfaces;
using Telemetry.Api.Domain.Models;

namespace Telemetry.Api.Infrastructure.Persistence
{
    internal sealed class MongoNativeDbContext : IApplicationDbContext
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        private readonly IMongoCollection<EventRecord> _eventsCollection;
        private readonly IMongoCollection<ScriptRecord> _scriptCollection;

        public MongoNativeDbContext(IMongoClient mongoClient, string mongodbName)
        {
            _mongoClient = mongoClient;
            _mongoDatabase = _mongoClient.GetDatabase(mongodbName);

            _eventsCollection = _mongoDatabase.GetCollection<EventRecord>(GetCollectionName<EventRecord>());
            _scriptCollection = _mongoDatabase.GetCollection<ScriptRecord>(GetCollectionName<ScriptRecord>());
        }


        private static string GetCollectionName<T>()
        {
            var table = typeof(T).GetCustomAttribute<TableAttribute>();
            return table?.Name ?? typeof(T).Name;
        }

        public async Task AddEventRecord(EventRecord eventRecord, CancellationToken cancellationToken)
        {
            await _eventsCollection.InsertOneAsync(eventRecord, new InsertOneOptions(), cancellationToken);
        }

        public async Task AddScriptRecord(ScriptRecord scriptRecord, CancellationToken cancellationToken)
        {
            await _scriptCollection.InsertOneAsync(scriptRecord, new InsertOneOptions(), cancellationToken);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public async Task<bool> CanConnectAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _mongoClient.GetDatabase("admin")
                    .RunCommandAsync<BsonDocument>(new BsonDocument("ping", 1), cancellationToken: cancellationToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetDbProvider()
        {
            return "MongoDB Native";
        }

        public async Task<string> GetDbVersionAsync(CancellationToken cancellationToken)
        {
            BsonDocumentCommand<BsonDocument> command = new(new BsonDocument {{"buildInfo", 1}});
            BsonValue? version = await _mongoDatabase.RunCommandAsync(command, cancellationToken: cancellationToken);
            return version["version"].AsString;
        }
    }
}