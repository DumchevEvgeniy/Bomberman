using System;
using UnityEngine;

public class Scene : MonoBehaviour {
    public Int32 length = 5;
    public Int32 width = 5; 

    private void Start() {
        var gameMapWithComponents = new GameMapWithComponents(length, 
            width, 
            new MapFloor(), 
            new DynamicGameObjectCreator("Prefabs/ConcreteCube"));
        gameMapWithComponents.AddElements(new ElementCollection<RandomPlacementMethod>(new Player(), 1));
        gameMapWithComponents.AddElements(new ElementCollection<RandomPlacementMethodWithConsideringPlayerDistance>(
            new DynamicGameObjectCreator("Prefabs/SandCube"), 10));
        gameMapWithComponents.AddElements(new ElementCollection<RandomPlacementMethodWithConsideringPlayerDistance>(
            new Enemy(), 5));
        gameMapWithComponents.CreateAll();
    }
}
