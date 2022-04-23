
using Tickets.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Tickets.Models
{
    public class TicketViewModel : RegisterTicketViewModel
    {
        public int EntranceId { get; set; }

        public IEnumerable<SelectListItem> Entrances { get; set; }

    }
}
