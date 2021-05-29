using MAL_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAL_DAL
{
    public partial class Anime : BaseClass
    {
        /*
         uitbreiding van Anime klasse.
         */
        public override string this[string columName]
        {
            get
            {
                if (columName == "name" && string.IsNullOrWhiteSpace(name))
                {
                    return "Naam is verplicht";
                }
                if (columName == "status" && string.IsNullOrWhiteSpace(status))
                {
                    return "De huidige status van de Anime is verplicht!";
                }

                return "";
            }
        }
    }
}
