using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceQuotes.Common
{
    public class Price
    {
        public long Id { get; set; }
        public string key { get; set; }

        public PriceValue value { get; set; }
    }

    public class PriceValue
    {
        public long Id { get; set; }
        public string time { get; set; }

        public double value { get; set; }
    }

}
