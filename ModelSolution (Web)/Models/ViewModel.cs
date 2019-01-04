using System;
using System.Collections.Generic;

namespace ModelSolution.Models
{
    public class ViewModel
    {
        public IEnumerable<Assignment> Upcoming { get; set; }
        public IEnumerable<Assignment> Previous { get; set; }
        public Assignment Assignment { get; set; }
    }
}
