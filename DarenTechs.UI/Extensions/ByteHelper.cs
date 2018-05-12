using System;
using System.Collections.Generic;
using System.Text;

namespace DarenTechs.UI.Extensions
{
    public static class ByteHelper
    {
        public static byte[] ToByteArray(this string str)
        {
            return System.Text.Encoding.ASCII.GetBytes(str);
        }
    }
}
