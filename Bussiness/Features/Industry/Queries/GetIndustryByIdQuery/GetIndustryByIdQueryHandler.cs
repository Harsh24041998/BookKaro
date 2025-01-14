using AutoMapper;
using Bussiness.Contracts.Repositories;
using Bussiness.Contracts;
using Bussiness.Features.Industry.Queries.GetIndustryByIdQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Features.Industry.Queries.GetIndustryByIdQuery
{
    public class GetIndustryByIdQueryHandler : IRequestHandler<GetIndustryByIdQuery, GetIndustryByIdDTO>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIndustryRepository _IndustryRepository;

        #endregion

        #region Ctor

        public GetIndustryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IIndustryRepository IndustryRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _IndustryRepository = IndustryRepository;
        }

        #endregion

        #region methods

        public async Task<GetIndustryByIdDTO> Handle(GetIndustryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var IndustryResponse = new GetIndustryByIdDTO();
                var requestModel = request.Id;

                string propertiesToInclude = "";
                var response = await _IndustryRepository.ReadByIdAsync(request.Id.GetValueOrDefault(), propertiesToInclude, cancellationToken);

                IndustryResponse = _mapper.Map<GetIndustryByIdDTO>(response);
                return IndustryResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
