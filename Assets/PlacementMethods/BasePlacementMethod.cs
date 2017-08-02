using System;
using System.Collections.Generic;

public abstract class BasePlacementMethod {
    public abstract IEnumerable<CellOnField> GetPlacements(Field field, Int32 elementsCount);
}