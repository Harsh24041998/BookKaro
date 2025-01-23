using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.Subscription.Commands.CreateSubscriptionCommand;
using Bussiness.Features.Subscription.Commands.DeleteSubscriptionCommand;
using Bussiness.Features.Subscription.Commands.UpdateSubscriptionCommand;
using Bussiness.Features.Subscription.Queries.GetAllSubscriptionQuery;
using Bussiness.Features.Subscription.Queries.GetSubscriptionByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class SubscriptionMapper : Profile
    {
        public SubscriptionMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateSubscriptionCommand, SubscriptionDO>();
            CreateMap<UpdateSubscriptionCommand, SubscriptionDO>();
            CreateMap<DeleteSubscriptionCommand, SubscriptionDO>();

            //Response Mapper(s)
            CreateMap<SubscriptionDO, GetAllSubscriptionDTO>();
            CreateMap<SubscriptionDO, GetSubscriptionByIdDTO>();
            CreateMap<SubscriptionDO, CreateSubscriptionCommandDTO>();
            CreateMap<SubscriptionDO, UpdateSubscriptionCommandDTO>();
            CreateMap<SubscriptionDO, DeleteSubscriptionCommandDTO>();
        }
    }
}
