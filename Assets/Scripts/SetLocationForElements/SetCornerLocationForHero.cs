using System;
using System.Collections.Generic;

public class SetCornerLocationForHero : BaseSetLocationForElements {
    protected override IEnumerable<Cell> GetCellsForLocationElementPrefab(Field field, Int32 neededCountElements) {
        yield return field.GetCell(1, 1);
    }
}