using BlazorAppTTHH.Models;
using Newtonsoft.Json;
using System.Web;

namespace BlazorAppTTHH.Mediator
{
    public class MediatorAPI : IMediatorAPI
    {
        private readonly HttpClient _httpClient;

        public MediatorAPI(IHttpClientFactory clientFactory)
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

        public async Task<List<CentroCosto>> ObtenerCentroCostos()
        {
            // Hacemos la llamada al servicio externo
            var response = await _httpClient.GetAsync("Varios/CentroCostosSelect");
            response.EnsureSuccessStatusCode();

            // Deserializamos la respuesta a una lista de objetos CentroCosto
            var centroCostos = await response.Content.ReadFromJsonAsync<List<CentroCosto>>();

            // Verificamos que la respuesta no esté vacía
            if (centroCostos == null)
            {
                throw new InvalidOperationException("No se recibieron datos de los centros de costos.");
            }

            return centroCostos;
        }

        public async Task<CentroCosto> InsertarCentroCosto(CentroCosto centroCosto)
        {
            // Construye la URL con los parámetros de consulta.
            var url = $"Varios/CentroCostosInsert?codigocentrocostos={centroCosto.Codigo}&descripcioncentrocostos={Uri.EscapeDataString(centroCosto.NombreCentroCostos)}";

            // Envía una solicitud POST a la URL con un cuerpo de solicitud vacío, ya que los datos se envían en la cadena de consulta.
            var response = await _httpClient.PostAsync(url, null);
            response.EnsureSuccessStatusCode();

            // El servidor responde con un arreglo de objetos CentroCosto.
            var centroCostosRespuesta = await response.Content.ReadFromJsonAsync<List<CentroCosto>>();

            // Suponiendo que el servidor responde con al menos un objeto CentroCosto.
            return centroCostosRespuesta.FirstOrDefault();
        }
    }
}
