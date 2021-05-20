using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAL_Models
{
    public abstract class BaseClass
    {
        public abstract string this[string columName] { get; }

        public bool IsGeldig()
        {
            return string.IsNullOrWhiteSpace(ErrorMessages);
        }

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
