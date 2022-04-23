

using System.Web.Mvc;

namespace Tickets.Data.Entities
{
    public class Entrance
    {
        public int Id { get; set; }

       /// [Display(Name = "Descripción")]
        ///[MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public String Description { get; set; }

        public ICollection<Ticket> Tickets { get; set; }


    }
}
