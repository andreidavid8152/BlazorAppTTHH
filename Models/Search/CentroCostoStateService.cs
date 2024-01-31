namespace BlazorAppTTHH.Models.Search
{
    public class CentroCostoStateService
    {
        private List<CentroCosto> centroCostos;

        public void SetCentroCostos(List<CentroCosto> centros)
        {
            centroCostos = centros;
        }

        public CentroCosto GetCentroCostoPorCodigo(int codigo)
        {
            return centroCostos?.FirstOrDefault(cc => cc.Codigo == codigo);
        }
    }
}
