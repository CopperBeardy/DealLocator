using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    [ExcludeFromCodeCoverage]
    public class Deal
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }


        [Required]
        [MaxLength(100, ErrorMessage = "Deal description should be no more than 100 characters")]
        [MinLength(3, ErrorMessage = "Deal description should be more than 2 characters")]
        public string Description { get; set; }

        [Required]
        [Range(typeof(int), "0", "14", ErrorMessage = "Deal can be of a Duration of {0}, {1} ")]

        public int Duration { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }

      
        public Guid BusinessId { get; set; }
        public Business Business { get; set; }

        public DealStatus DealStatus { get; set; }

        [Required]
        public Category Category { get; set; }
    }
}