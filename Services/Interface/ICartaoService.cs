namespace Pagamentos.Services.Interface
{
    public interface ICartaoService
    {
        bool VerificarExistenciaEValidade(string numeroCartao);
        string ObterBandeira(string numeroCartao);
    }
}
