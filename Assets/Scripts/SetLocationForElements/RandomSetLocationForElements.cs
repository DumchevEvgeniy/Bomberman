using System;
using System.Linq;
using System.Collections.Generic;

public class RandomSetLocationForElements : BaseSetLocationForElements {
    protected override IEnumerable<Cell> GetCellsForLocationElementPrefab(Field field, Int32 neededCountElements) {
        var result = new List<Cell>();
        var emptyCells = field.GetAllEmptyCells();
        emptyCells = GetAvailableCells(emptyCells, field);
        while(result.Count != neededCountElements && !emptyCells.IsEmpty()) {
            var indexCell = UnityEngine.Random.Range(0, emptyCells.Count);
            result.Add(emptyCells[indexCell]);
            emptyCells.RemoveAt(indexCell);
        }
        return result;
    }

    private List<Cell> GetAvailableCells(List<Cell> emptyCells, Field field) {
        var prohibitedForUsingCells = GetProhibitedForUsingCells(field);
        if(prohibitedForUsingCells == null)
            return emptyCells;
        return emptyCells.Except(prohibitedForUsingCells).ToList();
    }

    protected virtual IEnumerable<Cell> GetProhibitedForUsingCells(Field field) {
        return null;
    }
}