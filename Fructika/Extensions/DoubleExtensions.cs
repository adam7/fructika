using System;
using System.Collections.Generic;
using System.Text;

namespace Fructika.Extensions
{
    public static class DoubleExtensions
    {
        public static string GetGrams(this double? value)
        {
            return $"{value?.ToString("0.0") ?? "?"}g";
        }        
    }
}
