using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace notelohell.Utils
{
    public class HeroesStandard
    {
        public static IList<string> Categories = 
            new List<string>()
            {
                "Offensive",
                "Defensive",
                "Tank",
                "Support"
            };

        public static IDictionary<string, string> Heroes = new Dictionary<string, string>()
        {

        };
    }
}