using System;

public class CellOnField : Cell {
    public Field Owner { get; private set; }
    public DynamicGameObject DynamicGameObject { get; set; }

    public CellOnField(Int32 indexRow, Int32 indexColumn, Field owner)
        : base(indexRow, indexColumn) {
        Owner = owner;
    }

    public Boolean IsEmpty() {
        return DynamicGameObject == null;
    }
    public void PutGameObject(DynamicGameObject dynamicGameObject) {
        DynamicGameObject = dynamicGameObject;
    }
}
