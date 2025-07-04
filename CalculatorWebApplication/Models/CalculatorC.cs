using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculatorWebApplication.Models
{
    [Table("calculator")]
    public class CalculatorC
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal operand1 { get; set; }
        [Required]
        public decimal operand2 { get; set; }
        [Required]
        public char operation {  get; set; }
       
        public decimal result { get; set; }
    }
}
