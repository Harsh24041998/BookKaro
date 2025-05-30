﻿namespace Bussiness.Features.Category.Queries.GetAllCategoryQuery
{
    public class GetAllCategoryDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid IndustryId { get; set; } = default;
        public string IndustryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;

        #endregion
    }
}
