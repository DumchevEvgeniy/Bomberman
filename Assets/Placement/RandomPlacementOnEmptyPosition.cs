using System.Collections.Generic;

public class RandomPlacementOnEmptyPosition : RandomPlacement {
    protected override IEnumerable<CellOnField> GetNeededCells(Field field) {
        return field.GetEmptyCells();
    }
}