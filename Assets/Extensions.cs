using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class EnumerableExtensions {
    public static Boolean IsEmpty<T>(this IEnumerable<T> collection) {
        return collection.Count() == 0;
    }
}

public static class GameObjectExtensions {
    public static GameObject SetNewPosition(this GameObject gameObject, Single x, Single y, Single z) {
        gameObject.transform.position = new Vector3(x, y, z);
        return gameObject;
    }
    public static GameObject SetNewPosition(this GameObject gameObject, Coordinate coordinate, Single value) {
        var x = gameObject.transform.position.x;
        var y = gameObject.transform.position.y;
        var z = gameObject.transform.position.z;
        switch(coordinate) {
            case Coordinate.X:
                return gameObject.SetNewPosition(value, y, z);
            case Coordinate.Y:
                return gameObject.SetNewPosition(x, value, z);
            case Coordinate.Z:
                return gameObject.SetNewPosition(x, y, value);
        }
        return gameObject;
    }
}

public enum Coordinate {
    X,
    Y,
    Z
}