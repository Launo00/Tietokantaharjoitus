using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TietokantaHarjoitus
{
    public class Tuote
    { 
        [Key]
        public int id { get; set; }
        public string tuoteNimi { get; set; }
        public int hinta { get; set; }
        public int varastoSaldo { get; set; }
    }
}
