using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D9
{
    #region Exetention Method
    /*
    //V1
    class StringHelper
    {
        public static bool IsCapitalized(string str) 
        {
            if(string.IsNullOrEmpty(str)) return false;
            return char.IsUpper(str[0]);
        }
    }
    static class StaticStringHelper // static class
    {
         
        public static bool IsCapitalized(this string str) // static method(1st arg this)
        {
            if (string.IsNullOrEmpty(str)) return false;
            return char.IsUpper(str[0]);
        }
        public static bool CheckLength(this string str,int len) // static method(1st arg this,...)
        {
            if (string.IsNullOrEmpty(str)||str.Length!=len) return false ;
            return true;
        }
    }
    internal class ExetentionMethods
    {
        static void Main(string[] args)
        {
            string str = "hello";
            //V1
            Console.WriteLine(StringHelper.IsCapitalized(str));  // class.Method(arg0,arg1,arg2,...)
            // V2
            Console.WriteLine(StaticStringHelper.IsCapitalized(str)); // old Calling 

            // new Calling 
            Console.WriteLine(str.IsCapitalized()); // arg0.Method

            Console.WriteLine(str.CheckLength(5));// arg0.Method(arg1,arg2,...)

        }
    }
    */
    #endregion

    
    
}
