using BlazorAppTTHH.Models;

namespace BlazorAppTTHH.Mediator
{
    public interface IMediatorAPI
    {
        Task<List<Emisor>> GetEmisores();
        Task<UsuarioResponse> Login(LoginModel usuarioLogin);
    }
}
