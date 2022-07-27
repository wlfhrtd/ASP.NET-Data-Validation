using Mvc.Validation;
using System.ComponentModel.DataAnnotations;


namespace Mvc.Models
{
    public class SoftwareLicenseAgreement
    {
        public SoftwareLicenseAgreement()
        {
            AgreementText = "Some agreement text";
        }


        [Required]
        public string AgreementText { get; set; }

        [Required]
        [StringLength(50)]
        public string SoftwareProductName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Licensee Name")]
        public string LicenseeName { get; set; }

        [ConfirmValue(true, ErrorMessage = "Please accept the licensing agreement.")]
        [Display(Name = "Agreement Accepted")]
        public bool AgreementAccepted { get; set; }
    }
}
