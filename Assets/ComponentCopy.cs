using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class ComponentCopy {
    public static void PlayerCopy(GameObject source, GameObject destination) {
        TransformCopy(source, destination);
        SettingsCopy(source, destination);
    }

    public static void TransformCopy(GameObject source, GameObject destination) {
        var sourceTransform = source.GetComponent<Transform>();
        var destinationTransform = destination.GetComponent<Transform>();
        destinationTransform.position = sourceTransform.position;
        destinationTransform.rotation = sourceTransform.rotation;
        destinationTransform.localScale = sourceTransform.localScale;
    }
    public static void SettingsCopy(GameObject source, GameObject destination) {
        var sourceTransform = source.GetComponent<CunningBombermanSettings>();
        var destinationTransform = destination.GetComponent<CunningBombermanSettings>();
        destinationTransform.movementSpeed = sourceTransform.movementSpeed;
        destinationTransform.rotationSpeed = sourceTransform.rotationSpeed;
        destinationTransform.wallpass = sourceTransform.wallpass;
        destinationTransform.numberOfLives = sourceTransform.numberOfLives;
        destinationTransform.gamePoints = sourceTransform.gamePoints;
        destinationTransform.maxCountBomb = sourceTransform.maxCountBomb;
        destinationTransform.bangDistance = sourceTransform.bangDistance;
        destinationTransform.preDetonatePossible = sourceTransform.preDetonatePossible;
    }
}