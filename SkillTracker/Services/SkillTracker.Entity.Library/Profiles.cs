using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillTracker.Entity
{
    public class Profiles :Document, IValidatableObject
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 5)]
          public string AssociateId { get; set; }

        [Phone]
        [StringLength(maximumLength: 10, MinimumLength = 10)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Mobile number should not have the characters")]
        public string Mobile { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public TechnicalSkills TechSkills { get; set; }
        public NonTechnicalSkills NonTechSkills { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.Equals(AssociateId.Substring(0,2),"CTS"))
            {
                yield return new ValidationResult("Associate ID must start with CTS"); ;
            }

        }
    }


    public class TechnicalSkills
    {
        [Required]
        [Range(0, 20,ErrorMessage = "Expertise level for {0} must range between 0-20")]
        public int Html { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Expertise level for {0} must range between 0-20")]
        public int Angular { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Expertise level for {0} must range between 0-20")]
        public int React { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Expertise level for {0} must range between 0-20")]
        public int AspNetCore { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Expertise level for {0} must range between 0-20")]
        public int Restful { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Expertise level for {0} must range between 0-20")]
        public int EntityFramework { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Expertise level for {0} must range between 0-20")]
        public int Git { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Expertise level for {0} must range between 0-20")]
        public int Docker { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Expertise level for {0} must range between 0-20")]
        public int Jenkins { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Expertise level for {0} must range between 0-20")]
        public int Azure { get; set; }

    }

    public class NonTechnicalSkills
    {
        [Required]
        [Range(0, 20, ErrorMessage = "Expertise level for {0} must range between 0-20")]
        public int Spoken { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Expertise level for {0} must range between 0-20")]
        public int Communication { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Expertise level for {0} must range between 0-20")]
        public int Aptitude { get; set; }
    }
}
