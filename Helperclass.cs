using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public interface IGraphQLClient
    {
        Task<string> PostAsync(string url, string query);
    }

    public class GraphQLHelper
    {
        private readonly IGraphQLClient _client;

        public GraphQLHelper(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task<User> GetUserById(string id)
        {
            var query = $"{{ user(id: \"{id}\") {{ id name }} }}";
            var response = await _client.PostAsync("graphql-api-url", query);
            // Parse response and return user object
            return ParseUserResponse(response);
        }

        private User ParseUserResponse(string response)
        {
             var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response);
            var userData = jsonResponse.data.user;

            var user = new User
            {
                id = userData.id.ToString(),
                name = userData.name.ToString()
            };

            return user;
        }
    }

}
