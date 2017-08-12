using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public static GameObject GetParent(this GameObject gameObject) {
        GameObject parentObject = gameObject;
        while(parentObject.transform.parent != null)
            parentObject = parentObject.transform.parent.gameObject;
        return parentObject;
    }

    public static Vector3 GetIntegerPosition(this GameObject gameObject) {
        var position = gameObject.transform.position;
        return new Vector3((Int32)Math.Round(position.x), (Int32)Math.Round(position.y), (Int32)Math.Round(position.z));
    }

    public static Boolean OneFrom(this GameObject gameObject, params String[] tags) {
        if(tags == null || tags.Length == 0)
            return false;
        return tags.Any(tag => gameObject.CompareTag(tag));
    }
}

public static class VectorExtensions {
    public static Cell ToCell(this Vector3 vector) {
        return new Cell((Int32)vector.x, (Int32)vector.z);
    }
}

public static class SceneExtensions {
    public static GameObject FindPlayer(this Scene scene) {
        return GetAllElementsByTag(scene, Player.tag).FirstOrDefault();
    }

    public static IEnumerable<GameObject> FindAllBreakCube(this Scene scene) {
        return GetAllElementsByTag(scene, BreakCube.tag);
    } 

    public static IEnumerable<GameObject> GetAllElementsByTag(this Scene scene, String tag) {
        return scene.GetRootGameObjects().Where(g => g.CompareTag(tag));
    }
}

public static class Int32Extensions {
    public static Boolean IsEven(this Int32 number) {
        return number % 2 == 0;
    }
    public static Boolean IsUneven(this Int32 number) {
        return !number.IsEven();
    }
    public static Int32 Normalize(this Int32 number) {
        return number == 0 ? 0 : Math.Sign(number);
    }
}