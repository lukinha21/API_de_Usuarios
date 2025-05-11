using Pagamentos.Services.Interface;

namespace Pagamentos.Services
{
    public class BandeiraService : IBandeiraService
    {
        public string ObterBandeira(string numeroCartao)
        {
            if (string.IsNullOrWhiteSpace(numeroCartao) || numeroCartao.Length < 8)
                return null;

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