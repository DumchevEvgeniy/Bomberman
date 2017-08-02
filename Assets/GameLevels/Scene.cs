using System;
using UnityEngine;

public class Scene : MonoBehaviour {
    public Int32 length = 21;
    public Int32 width = 13;
    public Int32 sandCubesCount = 54;

    private void Start() {
        var gameMapWithComponents = new GameMapWithComponents(length, 
            width, 
            new MapFloor(), 
            new ConcreteCube());
        gameMapWithComponents.AddElements(new ElementCollection<RandomPlacementMethod>(
            new Player(1, 2, false), 1));
        gameMapWithComponents.AddElements(new ElementCollection<RandomPlacementMethodWithConsideringPlayerDistance>(
            new SandCube(), sandCubesCount));
        gameMapWithComponents.AddElements(new ElementCollection<RandomPlacementMethodWithConsideringPlayerDistance>(
            new Enemy("Enemy", 100, 1, 2, false), 6));
        gameMapWithComponents.CreateAll();
    }
}
