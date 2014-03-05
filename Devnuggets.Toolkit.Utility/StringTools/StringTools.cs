using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Devnuggets.Toolkit.Utility
{
    public static class StringTools
    {
        const string HTML_TAG_PATTERN = "<.*?>";

        ///<summary>
        ///<para>Removes HTML tags from a string.</para>
        ///</summary>
        public static string StripHTML(string inputString)
        {
            return Regex.Replace
              (inputString, HTML_TAG_PATTERN, string.Empty);
        }

        ///<summary>
        ///<para>Removes any bad characters from a string e.g. tabs, newlines.</para>
        ///</summary>
        public static string RemoveAll(string i)
        {
            string s = i;
            s = Regex.Replace(s, @"[^a-zA-Z0-9/ ]", " ");
            return s;
        }

        ///<summary>
        ///<para>Trims a string at x number of words, adds ... if required</para>
        ///</summary>
        public static string stringTrim(string l, int wordcount)
        {
            string[] words = l.Split(new char[] { ' ' });

            if (words.Length > wordcount)
            {
                string strret = "";
                int icount = 0;
                foreach (string s in words)
                {
                    if (icount < wordcount)
                    {
                        strret += s + " ";
                        icount++;
                    }
                }
                return strret + "...";
            }
            else
            {
                return l;
            }
        }

        ///<summary>
        ///<para>Convert to Propercase (English)</para>
        ///</summary>
        public static string ProperCase(string stringInput)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            bool fEmptyBefore = true;
            foreach (char ch in stringInput)
            {
                char chThis = ch;
                if (Char.IsWhiteSpace(chThis))
                    fEmptyBefore = true;
                else
                {
                    if (Char.IsLetter(chThis) && fEmptyBefore)
                        chThis = Char.ToUpper(chThis);
                    else
                        chThis = Char.ToLower(chThis);
                    fEmptyBefore = false;
                }
                sb.Append(chThis);
            }
            return sb.ToString();
        }
    }
}
