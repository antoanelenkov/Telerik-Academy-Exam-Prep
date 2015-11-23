namespace Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class CreateGameRequestModel:IValidatableObject
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        public string Number { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var digits = this.Number
                .Distinct();

            if (true)//invalid
            {
                yield return new ValidationResult("Number is invalid");
            }
        }
    }
}