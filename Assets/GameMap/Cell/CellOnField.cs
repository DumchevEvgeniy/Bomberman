using System;
using System.Collections.Generic;
using System.Linq;

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
    public void RemoveGameElement(Type elementType) {
        var element = DynamicGameObjects.FirstOrDefault(el => el.IsDerived(elementType));
        if(element != null)
            DynamicGameObjects.Remove(element);
    }
}
