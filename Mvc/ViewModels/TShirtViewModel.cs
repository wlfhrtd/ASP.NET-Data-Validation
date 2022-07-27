using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mvc.Validation;


namespace Mvc.ViewModels
{
    public class TShirtViewModel
    {
        private const string AlphabetRegEx = @"^[A-Z]+[a-zA-Z''-'\s]*$";


        public TShirtViewModel()
        {
            SalesStartDate = DateTime.Now;
            SaleEndDate = DateTime.Now.AddDays(7);
            Price = 5;
        }


        [ScaffoldColumn(false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start selling this item on: ", Order = 3)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SalesStartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Stop selling this item on: ", Order = 4)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SaleEndDate { get; set; }

        [Required]
        [Display(Name = "T-Shirt Name", Order = 1)]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "T-Shirt Name must have at least 6 and at top 30 characters.")]
        [RegularExpression(AlphabetRegEx, ErrorMessage = "T-Shirt Name can only contain letters")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "T-Shirt Description", Order = 2)]
        [DataType(DataType.MultilineText)]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Description must have at least 6 and at top 255 characters.")]
        public string Description { get; set; }

        [Required]
        [Range(5, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string SellerEmailAddress { get; set; }

        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Compare("SellerEmailAddress")]
        public string ConfirmSellerEmailAddress { get; set; }

        [ConfirmValue(true, ErrorMessage = "Please accept terms and conditions")]
        [Required]
        [Display(Name = "Accept terms and conditions.")]
        public bool AgreeToTermsAndConditions { get; set; }
    }
}
