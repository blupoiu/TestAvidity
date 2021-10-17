using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAvidity.Models
{
    public class CommitModel
    {
        public string Login { get; set; }
        public DateTime Date { get; set; }
        public int Additions { get; set; }
        public int Deletions { get; set; } 
        public int Total { get; set; }
    }
}
