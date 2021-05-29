using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAL_Models;

namespace MAL_DAL
{
    public partial class Collection : BaseClass
    {
        /*
         uitbreiding op Collection klasse.
         */

        public override string this[string columName]
        {
            get
            {
                if (columName == "name" && string.IsNullOrWhiteSpace(name))
                {
                    return "Naam is een verplicht veld!";
                }

                return "";
            }
        }
    }
}
