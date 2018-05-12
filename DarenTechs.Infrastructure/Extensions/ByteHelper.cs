using System;
using System.Collections.Generic;
using System.Text;

namespace DarenTechs.Infrastructure.Extensions
{
    public static class ByteHelper
    {
        public static byte[] ToByteArray(this string str)
        {
            return System.Text.Encoding.ASCII.GetBytes(str);
        }
    }
}
