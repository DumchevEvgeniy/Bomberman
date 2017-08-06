using System;
using System.Linq;
using System.Collections.Generic;

public abstract class RandomPlacement : SelectivePlacement {
    protected override IEnumerable<CellOnField> GetPlacements(IEnumerable<CellOnField> availableCells, Int32 elementsCount) {
        var result = new List<CellOnField>();
        var listAvailableCells = availableCells.ToList();
        while(result.Count != elementsCount && !listAvailableCells.IsEmpty()) {
            var indexCell = UnityEngine.Random.Range(0, listAvailableCells.Count);
            result.Add(listAvailableCells[indexCell]);
            listAvailableCells.RemoveAt(indexCell);
        }
        return result;
    }
}