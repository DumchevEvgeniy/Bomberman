﻿using System;
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
}

public static class SceneAnalizer {
    public static GameObject FindPlayer(this Scene scene) {
        return GetAllElementsByTag(scene, Player.Tag).FirstOrDefault();
    }

    public static IEnumerable<GameObject> FindAllBreakCube(this Scene scene) {
        return GetAllElementsByTag(scene, BreakCube.Tag);
    } 

    public static IEnumerable<GameObject> GetAllElementsByTag(this Scene scene, String tag) {
        return scene.GetRootGameObjects().Where(g => g.CompareTag(tag));
    }
}

public enum Coordinate {
    X,
    Y,
    Z
}