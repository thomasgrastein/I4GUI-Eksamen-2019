using System;
using System.ComponentModel.DataAnnotations;

namespace ModelSolution.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }
    }
}