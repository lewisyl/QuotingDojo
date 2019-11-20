using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class Quote
    {
        [Required]
        [MinLength(3)]
        public string Name {get;set;}

        [Required]
        [MinLength(10)]
        [Display(Name="Quote")]
        public string QuoteDetail {get;set;}
    }
}