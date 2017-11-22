using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Vidk.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MemberShipType  MemberShipType { get; set; }

        public byte MemberShipTypeId { get; set; }
    }
}