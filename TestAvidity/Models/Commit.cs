using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAvidity.Models
{
    public class Commit
    {
        public string Url { get; set; }


        public Author Author { get; set; }
        public CommitInfo CommitInfo { get; set; }

    }
}
