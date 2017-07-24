using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class EnumerableExtensions {
    public static Boolean IsEmpty<T>(this IEnumerable<T> collection) {
        return collection.Count() == 0;
    }
}
