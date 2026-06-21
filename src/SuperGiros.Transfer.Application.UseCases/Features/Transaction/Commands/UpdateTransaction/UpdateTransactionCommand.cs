using MediatR;
using SuperGiros.Transfer.Domain.Enums;


namespace SuperGiros.Transfer.Application.UseCases.Features.Transaction.Commands.UpdateTransaction
{
    public class UpdateTransactionCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public TransactionType TipoMovimiento { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public string Descripcion { get; set; }
        public string Sede { get; set; }
        public DateTime FechaRealizacion { get; set; }
        public State State { get; set; }      // <--- Cambiado de TransactionStatus a State
        public FaseGiro Fase { get; set; }
    }
}
