using BlazorAppTTHH.Models;

namespace BlazorAppTTHH.Mediator
{
    public interface IMediatorService
    {
        Task<List<Emisor>> GetEmisores();
        Task<UsuarioResponse> Login(LoginModel usuarioLogin);
    }
}
