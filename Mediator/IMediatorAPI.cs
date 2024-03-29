﻿using BlazorAppTTHH.Models;

namespace BlazorAppTTHH.Mediator
{
    public interface IMediatorAPI
    {
        Task<List<Emisor>> GetEmisores();
        Task<UsuarioResponse> Login(LoginModel usuarioLogin);
        Task<List<CentroCosto>> ObtenerCentroCostos();
        Task<CentroCosto> InsertarCentroCosto(CentroCosto centroCosto);
        Task<CentroCosto> ActualizarCentroCosto(int? codigoCentroCostos, string descripcionCentroCostos);
        Task<CentroCosto> EliminarCentroCosto(int codigoCentroCostos, string descripcionCentroCostos);
        Task<List<Trabajador>> ObtenerTrabajadoresPorSucursal(int sucursal);
        Task<List<MovimientoPlanilla>> ObtenerMovimientosPlanilla();

    }
}
