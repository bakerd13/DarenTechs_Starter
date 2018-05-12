using System;
using System.Collections.Generic;
using System.Text;

namespace DarenTechs.Infrastructure.Helpers
{
    public static class PageCalculator
    {
        public static int TotalPages(long count, int pageSize)
        {
            return (int)Math.Ceiling((decimal)count / (decimal)pageSize);
        }
    }
}
