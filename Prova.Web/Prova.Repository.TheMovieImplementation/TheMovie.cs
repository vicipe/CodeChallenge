using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Prova.Repository.TheMovieImplementation
{
    public class TheMovie
    {
        private readonly string key;
        private readonly string token;
        private readonly string baseAddress = "https://api.themoviedb.org/3/";
        private readonly HttpClient httpClient;

        private TheMovie()
        {
            this.token = ConfigurationManager.AppSettings["token"];
            this.key = ConfigurationManager.AppSettings["apiKey"];

            if (token == null)
            {
                throw new Exception("");
            }

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<Resultado> ListarFilmes()
        {
            Resultado resultado = null;

            try
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

                var response = await httpClient.GetAsync($"list/1?api_key={key}");

                var content = await response.Content.ReadAsStringAsync();

                resultado = JsonConvert.DeserializeObject<Resultado>(content);
            }
            catch (Exception e)
            {

            }
            return await Task.FromResult(resultado);
        }

        public async Task<Filme> BuscarFilme(string id)
        {
            Filme resultado = null;

            try
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

                var response = await httpClient.GetAsync($"movie/{id}?api_key={key}");

                var content = await response.Content.ReadAsStringAsync();

                resultado = JsonConvert.DeserializeObject<Filme>(content);
            }
            catch (Exception e)
            {

            }
            return await Task.FromResult(resultado);
        }

        public static TheMovie Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TheMovie();
                }
                return instance;
            }
        }

        private static TheMovie instance;
    }

    public class Resultado
    {
        [JsonProperty("page")]
        public int Pagina { get; set; }

        [JsonProperty("items")]
        public List<Filme> Filmes { get; set; }
    }

    public class Filme
    {

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public object BackdropPath { get; set; }

        [JsonProperty("belongs_to_collection")]
        public object BelongsToCollection { get; set; }

        [JsonProperty("budget")]
        public long Budget { get; set; }

        [JsonProperty("genres")]
        public Genre[] Genres { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public long Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("production_companies")]
        public object[] ProductionCompanies { get; set; }

        [JsonProperty("production_countries")]
        public object[] ProductionCountries { get; set; }

        [JsonProperty("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("revenue")]
        public long Revenue { get; set; }

        [JsonProperty("runtime")]
        public long Runtime { get; set; }

        [JsonProperty("spoken_languages")]
        public object[] SpokenLanguages { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("vote_average")]
        public long VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public long VoteCount { get; set; }
    }

    public partial class Genre
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}