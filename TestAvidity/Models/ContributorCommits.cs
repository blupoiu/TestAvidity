using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAvidity.Models
{
    public class ContributorCommits
    {
        public string Login { get; set; }
        public DateTime FirstContribution { get; set; }
        public DateTime LastContribution { get; set; }
        public int TotalContributions { get; set; }
        public decimal AvgAdditions { get; set; }
        public decimal AvgDeletions { get; set; } 
        public decimal AvgCommits { get; set; }
        public int Commits { get; set; }
    }
}
