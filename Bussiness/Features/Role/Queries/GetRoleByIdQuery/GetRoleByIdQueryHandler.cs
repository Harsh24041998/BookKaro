using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using MediatR;

namespace Bussiness.Features.Role.Queries.GetRoleByIdQuery
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, GetRoleByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _RoleRepository;

        #endregion

        #region Ctor

        public GetRoleByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IRoleRepository RoleRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _RoleRepository = RoleRepository;
        }

        #endregion

        #region methods

        public async Task<GetRoleByIdDTO> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var RoleResponse = new GetRoleByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _RoleRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                RoleResponse = _mapper.Map<GetRoleByIdDTO>(response);
                return RoleResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
