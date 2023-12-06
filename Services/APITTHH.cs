using BlazorAppTTHH.Models;
using System.Net.Http.Json;


namespace BlazorAppTTHH.Services
{
    public class APITTHH
    {
        private readonly HttpClient _httpClient;

        public APITTHH(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("ApiService");
        }

        public async Task<List<Emisor>> GetEmisores()
        {
            var response = await _httpClient.GetAsync("Varios/GetEmisor"); // endpoint de emisores
            response.EnsureSuccessStatusCode();

            var emisores = await response.Content.ReadFromJsonAsync<List<Emisor>>();

            // Enviar mensaje en caso de que los emisores no tengan contenido.
            if (emisores == null)
            {
                throw new InvalidOperationException("No se recibieron datos de emisores.");
            }

            return emisores;
        }
    }
}
