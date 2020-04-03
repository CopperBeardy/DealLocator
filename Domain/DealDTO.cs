using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    [ExcludeFromCodeCoverage]
    public class DealDTO
    {
        public  string DealTitle { get; set; }

        public string DealDescription { get; set; }

        public string BusinessName { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
