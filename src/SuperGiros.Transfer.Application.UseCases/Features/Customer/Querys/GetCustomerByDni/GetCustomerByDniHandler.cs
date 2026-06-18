// src/SuperGiros.Transfer.Application.UseCases/Features/Customer/Querys/GetCustomerByDni/GetCustomerByDniHandler.cs
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SuperGiros.Transfer.Application.Interfaces.Persistence;
using SuperGiros.Transfer.Application.UseCases.Features.Customer.Querys.GetCustomer;
using SuperGiros.Transfer.Domain.Enums; // 🛠️ CORRECCIÓN: Necesario para comparar el estado

namespace SuperGiros.Transfer.Application.UseCases.Features.Customer.Querys.GetCustomerByDni
{
    public class GetCustomerByDniHandler : IRequestHandler<GetCustomerByDniQuery, GetCustomerResponseDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetCustomerByDniHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<GetCustomerResponseDto> Handle(GetCustomerByDniQuery request, CancellationToken cancellationToken)
        {
            // 🛠️ CORRECCIÓN: Comparamos int con int, y casteamos el Enum para la validación de estado
            var customer = await _applicationDbContext.customers
                .FirstOrDefaultAsync(x => x.NroDocumento == request.NroDocumento && (int)x.State == 1, cancellationToken);

            // Reutilizamos el mapa existente de Customer -> GetCustomerResponseDto
            return _mapper.Map<GetCustomerResponseDto>(customer);
        }
    }
}