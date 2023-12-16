using BlazorAppTTHH.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Web;

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

        public async Task<UsuarioResponse> Login(LoginModel usuarioLogin)
        {
            // Preparar la cadena de consulta con los parámetros de usuario y contraseña
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["usuario"] = usuarioLogin.Usuario;
            query["password"] = usuarioLogin.Password;
            var queryString = query.ToString();

            // Hacer la llamada al endpoint con los parámetros de consulta
            var response = await _httpClient.GetAsync($"Usuarios?{queryString}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            // Cambio aquí para deserializar como una lista
            var usuarios = JsonConvert.DeserializeObject<List<UsuarioResponse>>(content);

            if (usuarios == null || !usuarios.Any())
            {
                throw new InvalidOperationException("Ocurrió un error.");
            }

            // Puedes decidir qué hacer si hay múltiples usuarios, por ejemplo, devolver el primero
            return usuarios.FirstOrDefault();

        }


    }
}
