using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignLogic
{
    public class FullButton
    {
        public static int IdCounter = 1;
        public int Id { get; set; }
        public string Sign { get; set; }
        public string Description { get; set; }
    }
}
