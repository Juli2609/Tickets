﻿
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Tickets.Data.Entities
{
    public class Entrance
    {
        public int Id { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Description { get; set; }

        public ICollection<Ticket> tickets { get; set; }



    }
}
