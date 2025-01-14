using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Features.User.Queries.GetAllUserQuery
{
    public class GetAllUserDTO
    {
        #region properties

        public Guid Id { get; set; }
        public Guid GenderId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public int OTPAttempts { get; set; } = default;
        public bool IsActive { get; set; } = default;
        public string Gender { get; set; } = string.Empty;

        #endregion
    }
}
