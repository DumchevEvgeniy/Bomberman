using System;
using System.Collections.Generic;

public class CellOnField : Cell {
    public Field Owner { get; private set; }
    public List<DynamicGameObject> DynamicGameObjects { get; set; }

    public CellOnField(Int32 indexRow, Int32 indexColumn, Field owner)
        : base(indexRow, indexColumn) {
        DynamicGameObjects = new List<DynamicGameObject>();
        Owner = owner;
    }

    public Boolean IsEmpty() {
        return DynamicGameObjects.IsEmpty();
    }
    public void AddGameObject(DynamicGameObject dynamicGameObject) {
        DynamicGameObjects.Add(dynamicGameObject);
    }
}
