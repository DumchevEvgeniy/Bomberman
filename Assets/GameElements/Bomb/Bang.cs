using System;
using UnityEngine;

public class Bang : DynamicGameObject {
    Cell cell;

    public Bang(Int32 row, Int32 column) {
        cell = new Cell(row, column);
    }

    public override GameObject CreateGameObject() {
        var bang = base.CreateGameObject();
        bang.transform.position = new Vector3(cell.IndexRow, 1, cell.IndexColumn);
        return bang;
    }

    protected override String GetPrefabName() {
        return "Prefabs/Bang";
    }
}