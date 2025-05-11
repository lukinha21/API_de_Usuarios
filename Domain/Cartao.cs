using System;
using System.ComponentModel.DataAnnotations;

namespace Pagamentos.Domain
{
    /// <summary>
    /// Representa um cartão de pagamento.
    /// </summary>
    public class Cartao
    {
        /// <summary>
        /// Número do cartão, que também é a chave primária.
        /// </summary>
        [Key]
        public string Numero { get; set; }

        /// <summary>
        /// Data de validade do cartão.
        /// </summary>
        public DateTime Validade { get; set; }
    }
}
