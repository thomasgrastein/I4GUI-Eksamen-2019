using System;
using System.ComponentModel.DataAnnotations;

namespace ModelSolution.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Expenses ($)")]
        [Range(0,99999999)]
        public int Value { get; set; }

        public int AssignmentId { get; set; }
    }
}