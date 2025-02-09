using Bussiness.Features.CoreAssetBooking.Queries.GetAllCoreAssetBookingQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Features.CoreAssetBookingSlot.Queries.GetAllCoreAssetBookingSlotQuery
{
    public class GetAllCoreAssetBookingSlotQuery
         : IRequest<IEnumerable<GetAllCoreAssetBookingSlotQueryDTO>>
    {
    }
}
