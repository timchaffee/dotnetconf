using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetconf.Models
{
    public class Vote
    {
        public int SessionId { get; set; }
        public string UserId { get; set; }

        public Session Session { get; set; }
    }
}
