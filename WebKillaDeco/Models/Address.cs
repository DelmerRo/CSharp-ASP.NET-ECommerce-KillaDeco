using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebKillaDeco.Helpers;
namespace WebKillaDeco.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        public int? UserId { get; set; }

        public int? LocationId { get; set; }

        [StringLength(Restrictions.MaxStreet, MinimumLength = Restrictions.MinStreet, ErrorMessage = ErrorMsgs.StrMaxMin)]
        [Display(Name = Alias.Street)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        public string? Street { get; set; }


        public int Number { get; set; }

        public string? Tower { get; set; }

        public int Floor { get; set; }
        public string? Department { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        // Propiedades de navegación
        public User? User { get; set; }
        public Location? Location { get; set; }
    }
}
