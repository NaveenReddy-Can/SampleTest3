using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleTest3.Attributes
{
    public class IsPositiveNumberAttribute : ValidationAttribute
    {
        // TEST NOTE: Finish creating this attribute such that it will validate the property is a positive number
        public IsPositiveNumberAttribute() : base("Number should be positive")
        {
        }

        public override bool IsValid(object value)
        {
            try
            {
                int intValue = Convert.ToInt32(value);
                return intValue >= 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}