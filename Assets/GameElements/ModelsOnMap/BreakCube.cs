using System;
using UnityEngine;

public class BreakCube : DynamicGameObject {
    public const String tag = "BreakCube";

    protected override String GetPrefabName() {
        return "Prefabs/BreakCube";
    }

    public override GameObject CreateGameObject() {
        var sandCube = base.CreateGameObject();
        sandCube.AddComponent<BreakCubeSettings>();
        return sandCube;
    }
}
