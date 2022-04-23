using Microsoft.AspNetCore.Mvc.Rendering;
using Tickets.Data.Entities;

namespace Tickets.Helpers
{
    public interface ICombosHelper
    {
            Task<IEnumerable<SelectListItem>> GetComboEntrancesAsync();
    }
}
