using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.Transaction.Commands.CreateTransactionCommand;
using Bussiness.Features.Transaction.Commands.DeleteTransactionCommand;
using Bussiness.Features.Transaction.Commands.UpdateTransactionCommand;
using Bussiness.Features.Transaction.Queries.GetTransactionByIdQuery;
using Bussiness.Features.Transaction.Queries.GetAllTransactionQuery;

namespace Bussiness.Configurations.Mappers
{
    public class TransactionMapper : Profile
    {
        public TransactionMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateTransactionCommand, TransactionDO>();
            CreateMap<UpdateTransactionCommand, TransactionDO>();
            CreateMap<DeleteTransactionCommand, TransactionDO>();

            //Response Mapper(s)
            CreateMap<TransactionDO, GetAllTransactionDTO>();
            CreateMap<TransactionDO, GetTransactionByIdDTO>();
            CreateMap<TransactionDO, CreateTransactionCommandDTO>();
            CreateMap<TransactionDO, UpdateTransactionCommandDTO>();
            CreateMap<TransactionDO, DeleteTransactionCommandDTO>();
        }
    }
}
