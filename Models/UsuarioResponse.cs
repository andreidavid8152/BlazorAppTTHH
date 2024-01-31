using System.Text.Json.Serialization;

namespace BlazorAppTTHH.Models
{
    public class UsuarioResponse
    {
        [JsonPropertyName("OBSERVACION")]
        public string Observacion { get; set; }
        public string Emisor { get; set; }
        [JsonPropertyName("PERFIL")]
        public string Perfil { get; set; }
        [JsonPropertyName("NOMBREEMISOR")]
        public string NombreEmisor { get; set; }
        [JsonPropertyName("NOMBREUSUARIO")]
        public string NombreUsuario { get; set; }
        [JsonPropertyName("RucUsuario")]
        public string RucUsuario { get; set; }
    }
}
