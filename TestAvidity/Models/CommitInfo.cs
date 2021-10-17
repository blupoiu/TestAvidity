using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAvidity.Models
{
    public class CommitInfo
    {
        public Stats Stats { get; set; }
        public Commit Commit { get; set; }
        public Author Author { get; set; }
    }
}
