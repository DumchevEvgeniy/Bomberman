using System;
using System.Collections.Generic;

public class CornerPlacementMethod : BasePlacementMethod {
    public override IEnumerable<Cell> GetPlacements(Field field, Int32 elementsCount) {
        yield return field.GetCell(1, 1);
    }
}