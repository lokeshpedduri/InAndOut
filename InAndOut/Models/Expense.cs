using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
    public class Expense
    {
        private const double minAmount = 0.1;

        [Key]
        public int Id { get; set; }

        [DisplayName("Expense Name")]
        [Required]
        public string ExpenseName { get; set; }

        [Required]
        [Range(minAmount, double.MaxValue, ErrorMessage = "Amount should be greater than zero" )]
        public double Amount { get; set; }
    }
}
