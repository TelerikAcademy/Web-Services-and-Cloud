using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tests.Api
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}