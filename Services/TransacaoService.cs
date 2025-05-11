using Pagamentos.Domain;
using Pagamentos.Enums;
using Pagamentos.Services.Interface;


public class TransacaoService : ITransacaoService
{
    private readonly PagamentoDbContext _db;

    public TransacaoService(PagamentoDbContext db)
    {
        _db = db;
    }

    public List<Parcela> CalcularParcelas(decimal valorTotal, decimal taxaJuros, int quantidadeParcelas)
    {
        var parcelas = new List<Parcela>();

        // Calcula o valor total com juros
        decimal valorTotalComJuros = valorTotal * (1 + taxaJuros);

        // Calcula o valor de cada parcela
        decimal valorParcela = valorTotalComJuros / quantidadeParcelas;

        // Preenche a lista de parcelas
        for (int i = 1; i <= quantidadeParcelas; i++)
        {
            parcelas.Add(new Parcela
            {
                Numero = i,
                Valor = valorParcela
            });
        }

        return parcelas;
    }


    public int CriarPagamento(Transacao transacao)
    {
        transacao.Situacao = SituacaoPagamento.Pendente;
        _db.Transacao.Add(transacao);
        _db.SaveChanges();
        return transacao.TransacaoId;
    }

    public SituacaoPagamento ObterSituacao(int id)
    {
        var transacao = _db.Transacao.Find(id);
        return transacao?.Situacao ?? SituacaoPagamento.Pendente;
    }

    public bool ConfirmarPagamento(int id)
    {
        var transacao = _db.Transacao.Find(id);
        if (transacao != null && transacao.Situacao == SituacaoPagamento.Pendente)
        {
            transacao.Situacao = SituacaoPagamento.Confirmado;
            _db.SaveChanges();
            return true;
        }
        return false;
    }

    public bool CancelarPagamento(int id)
    {
        var transacao = _db.Transacao.Find(id);
        if (transacao != null && transacao.Situacao == SituacaoPagamento.Pendente)
        {
            transacao.Situacao = SituacaoPagamento.Cancelado;
            _db.SaveChanges();
            return true;
        }
        return false;
    }
}
