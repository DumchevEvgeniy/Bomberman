using System;
using UnityEngine;

public class Bomb : DynamicGameObject {
    private Cell cellForBomb;

    public Bomb(Cell cellForBomb) {
        this.cellForBomb = cellForBomb;
    }

    protected override String GetPrefabName() {
        return "Prefabs/Bomb";
    }

    public override GameObject CreateGameObject() {
        var bomb = base.CreateGameObject();
        bomb.transform.position = new Vector3(cellForBomb.IndexRow, bomb.transform.position.y, cellForBomb.IndexColumn);
        return bomb;
    }
}
