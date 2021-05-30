using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAL_Models
{
    public abstract class BaseClass
    {
        /*
         *Aanmaken abstracte variabele
         */
        public abstract string this[string columName] { get; }

        /*
         *IsGeldig methode voor het opvangen van errors.
         */
        public bool IsGeldig()
        {
            return string.IsNullOrWhiteSpace(ErrorMessages);
        }

        /*
         *Voor het aanmaken van error teksten.
         */
        public string ErrorMessages
        {
            get
            {
                string errorMessage = "";

                foreach (var item in this.GetType().GetProperties())
                {
                    if (item.CanRead)
                    {
                        string fout = this[item.Name];
                        if (!string.IsNullOrWhiteSpace(fout))
                        {
                            errorMessage += fout + Environment.NewLine;
                        }
                    }
                }

                return errorMessage;
            }
        }
    }
}
