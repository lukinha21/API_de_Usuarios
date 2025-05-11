using Pagamentos.Enums;

namespace Pagamentos.Domain
{
    public class Transacao
    {
        /// <summary>
        /// Representa uma transação de pagamento.
        /// </summary>
        public int TransacaoId { get; set; }
        /// <summary>
        /// Valor total da transação.
        /// </summary>
        public decimal Valor { get; set; }
        /// <summary>
        /// Número do cartão de crédito associado à transação.
        /// </summary>
        public string Cartao { get; set; }
        /// <summary>
        /// Código de verificação do cartão (CVV).
        /// </summary>
        public string Cvv { get; set; }
        /// <summary>
        /// Número de parcelas para o pagamento.
        /// </summary>
        public int Parcelas { get; set; }
        /// <summary>
        /// Situação atual da transação, representada por um valor numérico.
        /// </summary>
        public SituacaoPagamento Situacao { get; set; } // Alterado para usar o enum
    }
}
