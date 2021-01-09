using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class GenAuto
    {
        public static string CreateID(String headID, String lastID)
        {
            String ID = headID;
            if(lastID == null )
            {
                ID += "100";
            }
            else
            {
                int k = Convert.ToInt32(lastID.Substring(1,3));
                k++;
                ID += k.ToString();
            }
            return ID;
        }
    }
}
