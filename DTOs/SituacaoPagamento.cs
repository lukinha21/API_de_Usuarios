namespace Pagamentos.DTOs
{
    /// <summary>
    /// Objeto de transferência de dados para solicitar o cálculo de parcelas de um pagamento.
    /// </summary>
    public class CalculoParcelasRequest
    {
        /// <summary>
        /// Valor total da transação que será parcelada.
        /// </summary>
        /// <example>1000.50</example>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Taxa de juros aplicada ao parcelamento.
        /// </summary>
        /// <example>0.05</example>
        public decimal TaxaJuros { get; set; }

        /// <summary>
        /// Quantidade de parcelas desejadas.
        /// </summary>
        /// <example>12</example>
        public int QuantidadeParcelas { get; set; }
    }
}
