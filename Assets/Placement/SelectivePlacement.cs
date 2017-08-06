using System;
using System.Collections.Generic;
using System.Linq;

public abstract class SelectivePlacement : BasePlacement {
    public override IEnumerable<CellOnField> GetPlacements(Field field, Int32 elementsCount) {
        var result = new List<CellOnField>();
        var availableCells = GetAvailableCells(GetNeededCells(field), GetProhibitedForUsingCells(field));
        if(availableCells == null)
            return result;
        return GetPlacements(availableCells, elementsCount) ?? result;
    }

    protected abstract IEnumerable<CellOnField> GetPlacements(IEnumerable<CellOnField> possibleCells, Int32 elementsCount);
    protected abstract IEnumerable<CellOnField> GetNeededCells(Field field);
    protected virtual IEnumerable<CellOnField> GetProhibitedForUsingCells(Field field) {
        return null;
    }

    private IEnumerable<T> GetAvailableCells<T>(IEnumerable<T> neededCells, IEnumerable<T> prohibitedCells) 
        where T : Cell {
        if(prohibitedCells == null && neededCells == null)
            return null;
        if(prohibitedCells == null)
            return neededCells;
        return neededCells.Except(prohibitedCells);
    }
}