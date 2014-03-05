using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devnuggets.Toolkit.Utility
{
    public static class DataTools
    {
        ///<summary>
        ///<para>Generate a new GUID</para>
        ///</summary>
        public static string newGuid()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}
