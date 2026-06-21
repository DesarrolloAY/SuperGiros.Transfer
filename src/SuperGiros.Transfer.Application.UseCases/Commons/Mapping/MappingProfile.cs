using AutoMapper;
using SuperGiros.Transfer.Domain.Entities;
using SuperGiros.Transfer.Application.UseCases.Features.Users.Commands.CreateUser;
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

namespace SuperGiros.Transfer.Application.UseCases.Commons.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeos de Usuarios
            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));

            // Mapeos de Clientes (Customer)
            CreateMap<CreateCustomerCommand, Customer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpdateCustomerCommand, Customer>();
            CreateMap<Customer, GetCustomerResponseDto>();
            CreateMap<Customer, GetAllCustomerResponseDto>();

            // Mapeos de Oficinas (Offices)
            CreateMap<CreateOfficeCommand, Offices>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpdateOfficeCommand, Offices>();
            CreateMap<Offices, GetOfficeResponseDto>();
            CreateMap<Offices, GetAllOfficeResponseDto>();

            // Mapeos de Transacciones (Transactions)
            // Nota: El nuevo campo 'Fase' y 'State' se mapean automáticamente por convención 
            // de nombres ya que los comandos, DTOs y la Entidad comparten los mismos tipos de C#
            CreateMap<CreateTransactionCommand, Transaction>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateTransactionCommand, Transaction>();

            CreateMap<Transaction, GetTransactionResponseDto>();
            CreateMap<Transaction, GetAllTransactionResponseDto>();
        }
    }
}