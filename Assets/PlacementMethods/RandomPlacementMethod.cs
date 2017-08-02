using System;
using System.Linq;
using System.Collections.Generic;

public class RandomPlacementMethod : BasePlacementMethod {
    public override IEnumerable<CellOnField> GetPlacements(Field field, Int32 elementsCount) {
        var result = new List<CellOnField>();
        var emptyCells = field.GetEmptyCells();
        var availableCells = GetAvailableCells(emptyCells, field).ToList();
        while(result.Count != elementsCount && !emptyCells.IsEmpty()) {
            var indexCell = UnityEngine.Random.Range(0, availableCells.Count);
            result.Add(availableCells[indexCell]);
            availableCells.RemoveAt(indexCell);
        }
        return result;
    }

    private IEnumerable<CellOnField> GetAvailableCells(IEnumerable<CellOnField> emptyCells, Field field) {
        var prohibitedForUsingCells = GetProhibitedForUsingCells(field);
        if(prohibitedForUsingCells == null)
            return emptyCells;
        return emptyCells.Except(prohibitedForUsingCells);
    }

    protected virtual IEnumerable<CellOnField> GetProhibitedForUsingCells(Field field) {
        return null;
    }
}