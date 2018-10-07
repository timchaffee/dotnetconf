using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetconf.Models
{
    public class Session
    {
        public Session()
        {
            Votes = new HashSet<Vote>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Presentors { get; set; }
        public string URL { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
