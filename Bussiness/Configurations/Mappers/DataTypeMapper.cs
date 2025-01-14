using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.DataType.Commands.CreateDataTypeCommand;
using Bussiness.Features.DataType.Commands.DeleteDataTypeCommand;
using Bussiness.Features.DataType.Commands.UpdateDataTypeCommand;
using Bussiness.Features.DataType.Queries.GetAllDataTypeQuery;
using Bussiness.Features.DataType.Queries.GetDataTypeByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class DataTypeMapper : Profile
    {
        public DataTypeMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateDataTypeCommand, DataTypeDO>();
            CreateMap<UpdateDataTypeCommand, DataTypeDO>();
            CreateMap<DeleteDataTypeCommand, DataTypeDO>();

            //Response Mapper(s)
            CreateMap<DataTypeDO, GetAllDataTypeDTO>();
            CreateMap<DataTypeDO, GetDataTypeByIdDTO>();
            CreateMap<DataTypeDO, CreateDataTypeCommandDTO>();
            CreateMap<DataTypeDO, UpdateDataTypeCommandDTO>();
            CreateMap<DataTypeDO, DeleteDataTypeCommandDTO>();
        }
    }
}
