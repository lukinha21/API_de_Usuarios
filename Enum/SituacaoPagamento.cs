namespace Pagamentos.Enums
{

    /// <summary>
    /// Representa as possíveis situações de um pagamento.
    /// </summary>
    public enum SituacaoPagamento
    {
        /// <summary>
        /// Pagamento pendente.
        /// </summary>
        Pendente = 1,
        /// <summary>
        /// Pagamento confirmado.
        /// </summary>
        Confirmado = 2,
        /// <summary>
        /// Pagamento cancelado.
        /// </summary>
        Cancelado = 3
    }
}
