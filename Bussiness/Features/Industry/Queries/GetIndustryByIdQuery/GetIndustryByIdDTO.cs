﻿namespace Bussiness.Features.Industry.Queries.GetIndustryByIdQuery
{
    public class GetIndustryByIdDTO
    {
        #region Properties

        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }

        #endregion
    }
}
