using System;
using System.Linq;
using System.Collections.Generic;

public class RandomPlacementMethod : BasePlacementMethod {
    public override IEnumerable<Cell> GetPlacements(Field field, Int32 elementsCount) {
        var result = new List<Cell>();
        var emptyCells = field.GetEmptyCells();
        var availableCells = GetAvailableCells(emptyCells, field).ToList();
        while(result.Count != elementsCount && !emptyCells.IsEmpty()) {
            var indexCell = UnityEngine.Random.Range(0, availableCells.Count);
            result.Add(availableCells[indexCell]);
            availableCells.RemoveAt(indexCell);
        }
        return result;
    }

    private IEnumerable<Cell> GetAvailableCells(IEnumerable<Cell> emptyCells, Field field) {
        var prohibitedForUsingCells = GetProhibitedForUsingCells(field);
        if(prohibitedForUsingCells == null)
            return emptyCells;
        return emptyCells.Except(prohibitedForUsingCells);
    }

    protected virtual IEnumerable<Cell> GetProhibitedForUsingCells(Field field) {
        return null;
    }
}