
using Pagamentos.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Pagamentos.Services
{
    public class CartaoService : ICartaoService
    {
        private readonly PagamentoDbContext _db;

        public CartaoService(PagamentoDbContext db)
        {
            _db = db;
        }

        public bool VerificarExistenciaEValidade(string numeroCartao)
        {
            var cartao = _db.Cartao
                             .AsNoTracking()
                             .FirstOrDefault(c => c.Numero == numeroCartao);

            if (cartao == null)
            {
                return false;
            }

            return cartao.Validade > DateTime.Now;
        }

        public string ObterBandeira(string numeroCartao)
        {
            // Verifica se o cartão é nulo, em branco ou se não tem exatamente 13 dígitos
            if (string.IsNullOrWhiteSpace(numeroCartao) || numeroCartao.Length != 13)
            {
                throw new ArgumentException("O número do cartão deve ter exatamente 13 dígitos.");
            }

            string bin = numeroCartao.Substring(0, 4);
            char oitavoDigito = numeroCartao[7];

            return (bin, oitavoDigito) switch
            {
                ("1111", '1') => "VISA",
                ("2222", '2') => "MASTERCARD",
                ("3333", '3') => "ELO",
                _ => null
            };
        }

    }
}
