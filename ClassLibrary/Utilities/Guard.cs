using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeLib.Utilities
{
    public static class Guard
    {
        public static void NotNull<T>(T value, string name)
        {
            if (value == null)
                throw new ArgumentNullException(name);
        }

        public static void NotEmpty<T>(IEnumerable<T> collection, string name)
        {
            if (!collection.Any())
                throw new InvalidOperationException($"Collection '{name}' must not be empty.");
        }
    }
}
