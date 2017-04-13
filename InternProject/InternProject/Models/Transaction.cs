using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace InternProject.Models
{
    public class Transaction : RealmObject
    {
        [PrimaryKey]
        public long Id { get; set; }

        public string Description { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Note { get; set; }
        public string Username { get; set; }
    }
}
