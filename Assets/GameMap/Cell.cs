using System;
using UnityEngine;

public class Cell {
    public Int32 IndexRow { get; private set; }
    public Int32 IndexColumn { get; private set; }
    public Field Owner { get; private set; }
    public DynamicGameObject DynamicGameObject { get; set; }
    
    public Cell(Int32 indexRow, Int32 indexColumn, Field owner) {
        IndexRow = indexRow;
        IndexColumn = indexColumn;
        Owner = owner;
    }

    public Boolean IsEmpty() {
        return DynamicGameObject == null;
    }
    public void PutGameObject(DynamicGameObject dynamicGameObject) {
        DynamicGameObject = dynamicGameObject;
    }
}
