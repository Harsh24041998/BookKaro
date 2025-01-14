using AutoMapper;
using Bussiness.DomainObjects;
using Bussiness.Features.Category.Commands.CreateCategoryCommand;
using Bussiness.Features.Category.Commands.DeleteCategoryCommand;
using Bussiness.Features.Category.Commands.UpdateCategoryCommand;
using Bussiness.Features.Category.Queries.GetAllCategoryQuery;
using Bussiness.Features.Category.Queries.GetCategoryByIdQuery;

namespace Bussiness.Configurations.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateCategoryCommand, CategoryDO>();
            CreateMap<UpdateCategoryCommand, CategoryDO>();
            CreateMap<DeleteCategoryCommand, CategoryDO>();

            //Response Mapper(s)
            CreateMap<CategoryDO, GetAllCategoryDTO>();
            CreateMap<CategoryDO, GetCategoryByIdDTO>();
            CreateMap<CategoryDO, CreateCategoryCommandDTO>();
            CreateMap<CategoryDO, UpdateCategoryCommandDTO>();
            CreateMap<CategoryDO, DeleteCategoryCommandDTO>();
        }
    }
}
