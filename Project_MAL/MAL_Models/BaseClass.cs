using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAL_Models
{
    public abstract class BaseClass
    {
        public string ErrorMessages
        {
            get
            {
                string errorMessage = "";

                foreach (var item in this.GetType().GetProperties())
                {
                    if (item.CanRead && item.CanWrite)
                    {
                        string error = Validate(item.Name);

                        if (!string.IsNullOrWhiteSpace(error))
                        {
                            errorMessage += error + Environment.NewLine;
                        }
                    }
                }

                return errorMessage;
            }
        }

        public abstract string Validate(string propertyname);
    }
}
