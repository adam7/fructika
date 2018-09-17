using System;
using System.Collections.Generic;
using System.Text;

namespace Fructika.Extensions
{
    public static class DecimalExtensions
    {
        public static string GetGrams(this decimal? value)
        {
            return $"{value?.ToString("0.0") ?? "?"}g";
        }        
    }
}
