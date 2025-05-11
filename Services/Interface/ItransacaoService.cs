using Pagamentos.Domain;
using Pagamentos.Enums;

namespace Pagamentos.Services.Interface
{
    public interface ITransacaoService
    {
        List<Parcela> CalcularParcelas(decimal valorTotal, decimal taxaJuros, int quantidadeParcelas);
        int CriarPagamento(Transacao transacao);
        SituacaoPagamento ObterSituacao(int id);
        bool ConfirmarPagamento(int id);
        bool CancelarPagamento(int id);
    }

    public class Parcela
    {
        public int Numero { get; set; }
        public decimal Valor { get; set; }
    }
}
