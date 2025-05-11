namespace Pagamentos.DTOs
{

    /// <summary>
    /// Objeto de transferência de dados para criar um pagamento.
    /// </summary>
    public class TransacaoRequest
    {
        /// <summary>
        /// Número do cartão de crédito a ser utilizado na transação.
        /// </summary>
        /// <example>1111222233334444</example>
        public string Cartao { get; set; }

        /// <summary>
        /// Valor total da transação que será processada.
        /// </summary>
        /// <example>100.50</example>
        public decimal Valor { get; set; }

        /// <summary>
        /// Código de verificação do cartão (CVV).
        /// </summary>
        /// <example>123</example>
        public string Cvv { get; set; }

        /// <summary>
        /// Número de parcelas para o pagamento.
        /// </summary>
        /// <example>3</example>
        public int Parcelas { get; set; }
    }
}
