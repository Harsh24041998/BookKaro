using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.Address.Commands.CreateAddressCommand;
using Bussiness.Features.Address.Commands.DeleteAddressCommand;
using Bussiness.Features.Address.Commands.UpdateAddressCommand;
using Bussiness.Features.Address.Queries.GetAllAddressQuery;
using Bussiness.Features.Address.Queries.GetAddressByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class AddressMapper : Profile
    {
        public AddressMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateAddressCommand, AddressDO>();
            CreateMap<UpdateAddressCommand, AddressDO>();
            CreateMap<DeleteAddressCommand, AddressDO>();

            //Response Mapper(s)
            CreateMap<AddressDO, GetAllAddressDTO>();
            CreateMap<AddressDO, GetAddressByIdDTO>();
            CreateMap<AddressDO, CreateAddressCommandDTO>();
            CreateMap<AddressDO, UpdateAddressCommandDTO>();
            CreateMap<AddressDO, DeleteAddressCommandDTO>();
        }
    }
}
