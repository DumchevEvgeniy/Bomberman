using System;
using System.Collections.Generic;

public class RandomSetLocationForElements : BaseSetLocationForElements {
    protected override IEnumerable<Cell> GetCellsForLocationElementPrefab(Field field, Int32 neededCountElements) {
        var result = new List<Cell>();
        var emptyCells = field.GetAllEmptyCells();
        emptyCells = SelectionPossibleCells(emptyCells, field);
        while(result.Count != neededCountElements && !emptyCells.IsEmpty()) {
            var indexCell = UnityEngine.Random.Range(0, emptyCells.Count);
            result.Add(emptyCells[indexCell]);
            emptyCells.RemoveAt(indexCell);
        }
        return result;
    }

    private List<Cell> SelectionPossibleCells(List<Cell> emptyCells, Field field) {
        var prohibitedForUsingCells = GetProhibitedForUsingCells(field);
        if(prohibitedForUsingCells == null)
            return emptyCells;
        foreach(var prohibitedForUsingCell in prohibitedForUsingCells)
            if(emptyCells.Contains(prohibitedForUsingCell))
                emptyCells.Remove(prohibitedForUsingCell);
        return emptyCells;
    }

    protected virtual IEnumerable<Cell> GetProhibitedForUsingCells(Field field) {
        return null;
    }
}