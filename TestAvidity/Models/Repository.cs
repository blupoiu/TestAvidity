using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAvidity.Models
{
    public class Repository
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string contributors_url { get; set; }
        public string commits_url { get; set; }
        public List<ContributorModel> Contributors { get; set; }


}
}
