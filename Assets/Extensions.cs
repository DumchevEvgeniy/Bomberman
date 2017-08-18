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
    public static GameObject SetPosition(this GameObject gameObject, Single x, Single y, Single z) {
        gameObject.transform.position.Set(x, y, z);
        return gameObject;
    }
    public static GameObject SetPosition(this GameObject gameObject, Coordinate coordinate, Single value) {
        gameObject.transform.position = gameObject.transform.position.Set(coordinate, value);
        return gameObject;
    }

    public static Boolean ActionWithAnimator(this GameObject gameObject, Action<Animator> action) {
        var animator = gameObject.GetComponent<Animator>();
        if(animator == null)
            return false;
        action(animator);
        return true;
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

    public static Vector3 Set(this Vector3 vector, Coordinate coordinate, Single value) {
        var x = vector.x;
        var y = vector.y;
        var z = vector.z;
        switch(coordinate) {
            case Coordinate.X:
                vector.Set(value, y, z);
                break;
            case Coordinate.Y:
                vector.Set(x, value, z);
                break;
            case Coordinate.Z:
                vector.Set(x, y, value);
                break;
        }
        return vector;
    }

    public static Int32 Sign(this Vector3 vector) {
        Int32 sign = Math.Sign(vector.x);
        if(sign != 0)
            return sign;
        sign = Math.Sign(vector.y);
        if(sign != 0)
            return sign;
        return Math.Sign(vector.z);
    } 
}

public static class SceneExtensions {
    public static GameObject FindPlayer(this Scene scene) {
        return GetAllElementsByTag(scene, Player.tag).FirstOrDefault();
    }

    public static IEnumerable<GameObject> FindAllBreakCube(this Scene scene) {
        return GetAllElementsByTag(scene, BreakCube.tag);
    }

    public static GameObject FindMainCamera(this Scene scene) {
        return scene.GetAllElementsByTag("MainCamera").FirstOrDefault();
    }

    public static IEnumerable<GameObject> GetAllElementsByTag(this Scene scene, String tag) {
        return scene.GetRootGameObjects().Where(g => g.CompareTag(tag));
    }

    public static Field GetField(this Scene scene) {
        var map = scene.GetAllElementsByTag("Map").FirstOrDefault();
        if(map == null)
            return null;
        var level = map.GetComponent<Level>();
        if(level == null)
            return null;
        return level.Map.Field;
    }
}

public static class NumberExtensions {
    public static Boolean IsEven(this Int32 number) {
        return number % 2 == 0;
    }
    public static Boolean IsUneven(this Int32 number) {
        return !number.IsEven();
    }
    public static Int32 Normalize(this Int32 number) {
        return number == 0 ? 0 : Math.Sign(number);
    }

    public static Boolean IsEven(this Single number) {
        return ((Int32)Math.Round(number)).IsEven();
    }
    public static Boolean IsUneven(this Single number) {
        return !number.IsEven();
    }
}