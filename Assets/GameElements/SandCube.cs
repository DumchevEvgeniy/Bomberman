using System;
using UnityEngine;

public class SandCube : DynamicGameObject {
    public const String Tag = "BreakCube";

    protected override String GetPrefabName() {
        return "Prefabs/SandCube";
    }

    public override GameObject CreateGameObject() {
        var sandCube = base.CreateGameObject();
        sandCube.AddComponent<SandCubeSettings>();
        return sandCube;
    }
}
