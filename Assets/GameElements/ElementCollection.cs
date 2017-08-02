using System;
using System.Collections.Generic;

public class ElementCollection<T> where T : BasePlacementMethod, new() {
    public DynamicGameObject Element { get; private set; }
    private Int32 elementsCount;

    public ElementCollection(DynamicGameObject element, Int32 elementsCount) {
        Element = element;
        this.elementsCount = elementsCount;
    }

    public IEnumerable<CellOnField> GetPlacements(Field field) {
        return new T().GetPlacements(field, elementsCount);
    }
}