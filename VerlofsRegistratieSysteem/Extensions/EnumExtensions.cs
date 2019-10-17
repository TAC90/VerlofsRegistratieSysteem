using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace VerlofsRegistratieSysteem.Extensions
{
    public static class EnumExtensions
    {
        public static string DisplayName(this Enum e)
            => e.GetType().GetMember(e.ToString()).First().GetCustomAttribute<DisplayNameAttribute>().ToString();
    }
}