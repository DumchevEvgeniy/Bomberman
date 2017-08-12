using System;
using System.Collections.Generic;

public class RouteFromCellOnField : IRoute<CellOnField> {
    private RouteSeacher routeSeacher;
    public CellOnField Cell { get; private set; }

    public RouteFromCellOnField(CellOnField cell, RouteSeacher routeSeacher) {
        Cell = cell;
        this.routeSeacher = routeSeacher;
    }

    public IEnumerable<CellOnField> GetPossibleRoutes() {
        List<CellOnField> possibleCells = new List<CellOnField>();
        if(BetweenHorizontalConcreteCubes()) {
            TryAddCell(possibleCells, IndexRow - 1, IndexColumn);
            TryAddCell(possibleCells, IndexRow + 1, IndexColumn);
        }
        if(BetweenVerticalConcreteCubes()) {
            TryAddCell(possibleCells, IndexRow, IndexColumn - 1);
            TryAddCell(possibleCells, IndexRow, IndexColumn + 1);
        }
        else {
            TryAddCell(possibleCells, IndexRow, IndexColumn - 2);
            TryAddCell(possibleCells, IndexRow, IndexColumn + 2);
            TryAddCell(possibleCells, IndexRow - 2, IndexColumn);
            TryAddCell(possibleCells, IndexRow + 2, IndexColumn);
        }
        return routeSeacher.SelectAvailableCells(Cell, possibleCells.ToArray());
    }

    private Boolean TryAddCell(List<CellOnField> list, Int32 indexRow, Int32 indexColumn) {
        if(!Cell.Owner.OnField(IndexRow - 1, IndexColumn))
            return false;
        list.Add(Cell.Owner.GetCell(IndexRow - 1, IndexColumn));
        return true;
    }
    private Boolean BetweenHorizontalConcreteCubes() {
        return IndexRow.IsEven() && IndexColumn.IsUneven();
    }
    private Boolean BetweenVerticalConcreteCubes() {
        return IndexRow.IsUneven() && IndexColumn.IsEven();
    }

    private Int32 IndexRow {
        get { return Cell.IndexRow; }
    }
    private Int32 IndexColumn {
        get { return Cell.IndexColumn; }
    }
}