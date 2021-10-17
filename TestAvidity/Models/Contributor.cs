using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAvidity.Models
{
    public class ContributorModel
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Url { get; set; }
        public string Avatar_url { get; set; }
        public int Contributions { get; set; }
        public ContributorCommits ContributorCommits { get; set; }

    }
}
