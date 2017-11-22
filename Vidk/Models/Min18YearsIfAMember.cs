using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Vidk.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipTypeId == MemberShipType.Unknown || 
                customer.MemberShipTypeId == MemberShipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("birth day is required");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                        ? ValidationResult.Success
                        : new ValidationResult("customer should be at least 18 or more ");

                 
            
        }
    }
}