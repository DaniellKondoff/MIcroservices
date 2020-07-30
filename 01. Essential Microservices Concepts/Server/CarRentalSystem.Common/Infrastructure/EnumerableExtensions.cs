using System;
using System.Collections.Generic;

namespace CarRentalSystem.Common.Infrastructure
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumrable, Action<T> action)
        {
            foreach (var item in enumrable)
            {
                action(item);
            }
        }
    }
}
