using System.Collections.Generic;

namespace MainApp
{
    public static class Util
    {
        public enum Type
        {
            Home = 0,
            News = 1,
            Sports = 2,
            ArtsAndEntertainment = 3,
            Opinions = 4
        }

        public static string BreakLines(string text)
        {
            string ret = "";
            for (int i = 0; i < text.Length; i++)
            {
                ret += text[i];
                if (i % 33 == 0 && i != 0)
                {
                    ret += '\n';
                }
            }

            return ret;
        }

        public static bool invertBool(bool b)
        {
            if (b)
            {
                return false;
            }

            return true;
        }
    }
}