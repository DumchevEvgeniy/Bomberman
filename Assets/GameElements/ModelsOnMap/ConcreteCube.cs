using System;

public class ConcreteCube : DynamicGameObject {
    public const String tag = "ConcreteCube";
    
    protected override String GetPrefabName() {
        return "Prefabs/ConcreteCube";
    }
}