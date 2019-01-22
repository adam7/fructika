using Fructika.Helpers;
using Fructika.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fructika.Services
{
    public class RemoteDataStore : IRemoteDataStore
    {
        static readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        // CosmosDB creds
        static readonly string accountURL = @"https://fructose.documents.azure.com:443/";
        static readonly string accountKey = Secrets.CosmosAccountKey;
        static readonly string databaseId = @"Fructose";
        static readonly string foodCollectionId = @"Foods";
        static readonly string foodGroupCollectionId = @"FoodGroups";
        static readonly Uri foodCollectionLink = UriFactory.CreateDocumentCollectionUri(databaseId, foodCollectionId);
        static readonly Uri foodGroupCollectionLink = UriFactory.CreateDocumentCollectionUri(databaseId, foodGroupCollectionId);

        static IDocumentClient DocumentClient { get; set; }

        public RemoteDataStore() : this(new DocumentClient(new Uri(accountURL), accountKey, serializerSettings))
        {
        }

        public RemoteDataStore(IDocumentClient documentClient)
        {
            DocumentClient = documentClient;
        }

        public async Task<IEnumerable<RemoteFoodGroup>> GetFoodGroupsAsync()
        {
            var foodGroupsQuery = DocumentClient
                .CreateDocumentQuery<RemoteFoodGroup>(foodGroupCollectionLink)
                .Where(foodGroup => foodGroup.Language == "en")
                .AsDocumentQuery();

            // TODO: Switch to C# 8 here and make use of async yield return :)
            IList<RemoteFoodGroup> foodGroups = new List<RemoteFoodGroup>();

            foreach(var foodGroup in await foodGroupsQuery.ExecuteNextAsync<RemoteFoodGroup>())
            {
                foodGroups.Add(foodGroup);
            }

            return foodGroups;
        }

        public async Task<IEnumerable<RemoteFood>> GetFoodsAsync()
        {
            var foodQuery = DocumentClient
                .CreateDocumentQuery<RemoteFood>(foodCollectionLink, new FeedOptions { })
                .Where(food => food.Language == "en")
                .Take(100)
                .AsDocumentQuery();

            // TODO: Switch to C# 8 here and make use of async yield return :)
            var foods = new List<RemoteFood>();

            foreach (var food in await foodQuery.ExecuteNextAsync<RemoteFood>())
            {
                foods.Add(food);
            }

            return foods;
        }
    }
}
