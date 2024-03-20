
using IdentityModel.Client;
using MovieClient.Models;
using Newtonsoft.Json;

namespace MovieClient.APIservises
{
    public class MovieAPIService : IMovieAPiServises
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MovieAPIService()
        {
            
        }

        public Task<Movie> CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> DeleteMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            var apiClientCredentials = new ClientCredentialsTokenRequest
            {
                Address = "https://localhost:7094/connect/token",

                ClientId = "movieClient",
                ClientSecret = "ama",

                // This is the scope our Protected API requires. 
                Scope = "movieApi"
            };
            var client = new HttpClient();

            //// just checks if we can reach the Discovery document. Not 100% needed but..
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:7094");
            if (disco.IsError)
            {
                return null; // throw 500 error
            }

            //// 2. Authenticates and get an access token from Identity Server
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentials);
            if (tokenResponse.IsError)
            {
                return null;
            }

            //// Another HttpClient for talking now with our Protected API
            var apiClient = new HttpClient();

            //// 3. Set the access_token in the request Authorization: Bearer <token>
               client.SetBearerToken(tokenResponse.AccessToken);

            //// 4. Send a request to our Protected API
            var response = await client.GetAsync("https://localhost:7020/api/movies");
             response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var movieList = JsonConvert.DeserializeObject<List<Movie>>(content);
             return movieList;

        }


        public Task<Movie> UpdateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
