using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using SuperGiros.Transfer.Services.gRPC.Protos;
using SuperGiros.Transfer.Application.UseCases.Features.Offices.Commands.CreateOffice;
using SuperGiros.Transfer.Application.UseCases.Features.Offices.Commands.UpdateOffice;
using SuperGiros.Transfer.Application.UseCases.Features.Offices.Querys.GetOffice;
using SuperGiros.Transfer.Application.UseCases.Features.Offices.Querys.GetAllOffice;
using SuperGiros.Transfer.Application.UseCases.Features.Customer.Commands.CreateCustomer;
using SuperGiros.Transfer.Application.UseCases.Features.Customer.Commands.UpdateCustomer;
using SuperGiros.Transfer.Application.UseCases.Features.Customer.Querys.GetCustomer;
using SuperGiros.Transfer.Application.UseCases.Features.Customer.Querys.GetAllCustomer;
using SuperGiros.Transfer.Application.UseCases.Features.Transaction.Commands.CreateTransaction;
using SuperGiros.Transfer.Application.UseCases.Features.Transaction.Commands.UpdateTransaction;
using SuperGiros.Transfer.Application.UseCases.Features.Transaction.Querys.GetTransaction;
using SuperGiros.Transfer.Application.UseCases.Features.Transaction.Querys.GetAllTransaction;
using DomainEnums = SuperGiros.Transfer.Domain.Enums;

namespace SuperGiros.Transfer.Services.gRPC.Commons.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeos globales de tipos primitivos comunes
            CreateMap<DateTime, Timestamp>()
                .ConvertUsing(x => Timestamp.FromDateTime(DateTime.SpecifyKind(x, DateTimeKind.Utc)));
            CreateMap<Timestamp, DateTime>()
                .ConvertUsing(x => x != null ? x.ToDateTime() : DateTime.UtcNow);

            CreateMap<decimal, double>().ConvertUsing(x => (double)x);
            CreateMap<double, decimal>().ConvertUsing(x => (decimal)x);

            // ==========================================
            // MAPEOS DE OFICINAS (Offices)
            // ==========================================
            CreateMap<OfficeStatus, DomainEnums.OfficeStatus>()
                .ConvertUsing(src => (DomainEnums.OfficeStatus)(int)src);
            CreateMap<DomainEnums.OfficeStatus, OfficeStatus>()
                .ConvertUsing(src => (OfficeStatus)(int)src);

            CreateMap<GetAllOfficeResponseDto, OfficeResponse>()
                .ForMember(d => d.Estado, o => o.MapFrom(s => (OfficeStatus)(int)s.Estado));
            CreateMap<GetOfficeResponseDto, OfficeResponse>()
                .ForMember(d => d.Estado, o => o.MapFrom(s => (OfficeStatus)(int)s.Estado));

            CreateMap<CreateOfficeRequest, CreateOfficeCommand>()
                .ForMember(d => d.Estado, o => o.MapFrom(s => (DomainEnums.OfficeStatus)(int)s.Estado));
            CreateMap<UpdateOfficeRequest, UpdateOfficeCommand>()
                .ForMember(d => d.Estado, o => o.MapFrom(s => (DomainEnums.OfficeStatus)(int)s.Estado));


            // ==========================================
            // MAPEOS DE CLIENTES (Customer) - ¡AGREGADO REGLAS DE CONVERSIÓN DE ENUMS!
            // ==========================================
            CreateMap<CustomerDocumentType, DomainEnums.CustomerDocumentType>()
                .ConvertUsing(src => (DomainEnums.CustomerDocumentType)(int)src);
            CreateMap<DomainEnums.CustomerDocumentType, CustomerDocumentType>()
                .ConvertUsing(src => (CustomerDocumentType)(int)src);

            CreateMap<CustomerState, DomainEnums.State>()
                .ConvertUsing(src => (DomainEnums.State)(int)src);
            CreateMap<DomainEnums.State, CustomerState>()
                .ConvertUsing(src => (CustomerState)(int)src);

            // DTOs -> Proto Response (Salida)
            CreateMap<GetAllCustomerResponseDto, CustomerResponse>()
                .ForMember(d => d.TipoDocumento, o => o.MapFrom(s => (CustomerDocumentType)(int)s.TipoDocumento))
                .ForMember(d => d.State, o => o.MapFrom(s => (CustomerState)(int)s.State));

            CreateMap<GetCustomerResponseDto, CustomerResponse>()
                .ForMember(d => d.TipoDocumento, o => o.MapFrom(s => (CustomerDocumentType)(int)s.TipoDocumento))
                .ForMember(d => d.State, o => o.MapFrom(s => (CustomerState)(int)s.State));

            // Proto Request -> Commands (Entrada)
            CreateMap<CreateCustomerRequest, CreateCustomerCommand>()
                .ForMember(d => d.TipoDocumento, o => o.MapFrom(s => (DomainEnums.CustomerDocumentType)(int)s.TipoDocumento));

            CreateMap<UpdateCustomerRequest, UpdateCustomerCommand>()
                .ForMember(d => d.TipoDocumento, o => o.MapFrom(s => (DomainEnums.CustomerDocumentType)(int)s.TipoDocumento));


            // ==========================================
            // MAPEOS DE TRANSACCIONES (Transactions)
            // ==========================================
            CreateMap<TransactionState, DomainEnums.State>()
                .ConvertUsing(src => (DomainEnums.State)(int)src);
            CreateMap<DomainEnums.State, TransactionState>()
                .ConvertUsing(src => (TransactionState)(int)src);

            CreateMap<TransactionPhase, DomainEnums.FaseGiro>()
                .ConvertUsing(src => (DomainEnums.FaseGiro)(int)src);
            CreateMap<DomainEnums.FaseGiro, TransactionPhase>()
                .ConvertUsing(src => (TransactionPhase)(int)src);

            CreateMap<GetAllTransactionResponseDto, TransactionResponse>()
                .ForMember(d => d.State, o => o.MapFrom(s => (TransactionState)(int)s.State))
                .ForMember(d => d.Fase, o => o.MapFrom(s => (TransactionPhase)(int)s.Fase));

            CreateMap<GetTransactionResponseDto, TransactionResponse>()
                .ForMember(d => d.State, o => o.MapFrom(s => (TransactionState)(int)s.State))
                .ForMember(d => d.Fase, o => o.MapFrom(s => (TransactionPhase)(int)s.Fase));

            CreateMap<CreateTransactionRequest, CreateTransactionCommand>();

            CreateMap<UpdateTransactionRequest, UpdateTransactionCommand>()
                .ForMember(d => d.State, o => o.MapFrom(s => (DomainEnums.State)(int)s.State))
                .ForMember(d => d.Fase, o => o.MapFrom(s => (DomainEnums.FaseGiro)(int)s.Fase));
        }
    }
}