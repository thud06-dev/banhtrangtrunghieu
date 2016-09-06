using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KoK_Source.Common
{
    public class CommonCnv
    {
        /// <summary>
        /// Convert to Thoundsand
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public string Convert1000Separator(string val)
        {
            string retVal = "";
            if (val != "")
            {
                if (IsNumeric(val))
                {

                    if (IsDecimal(double.Parse(val)))
                    {
                        retVal = string.Format("{0:N}\r\n", Decimal.Parse(val));
                    }
                    else {
                        retVal = string.Format("{0:#,0}\r\n", double.Parse(val));
                    }
                }
                else
                {
                    retVal = val;
                }
            }

            return retVal;

        }
        
        public bool CnvBool(object val)
        {
            return Convert.ToBoolean(val);
        }

        #region Check bool
        /// <summary>
        /// Check Numeric
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool IsNumeric(string val)
        {
            int num;
            bool isNum = Int32.TryParse(val, out num);

            if (isNum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Check Decimal
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool IsDecimal(double val)
        {
            decimal num;
            bool isNum = Decimal.TryParse(val.ToString(), out num);

            if (isNum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        public string getMota(string str,int maxlenght)
        {
            if (string.IsNullOrEmpty(str))
            {
                str = string.Empty;
            }
            if (maxlenght >= str.Length)
            {
                return str;
            }
            else
            {
                return str.Substring(str.Length - maxlenght);
            }
        }
    }
}