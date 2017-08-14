using System;
using System.Collections.Generic;

public class RouteFromCell<T> : IRoute<T> where T : CellOnField {
    private IRouteAvailable<T> routeSelector;

    public RouteFromCell(IRouteAvailable<T> routeSelector) {
        this.routeSelector = routeSelector;
    }

    public IEnumerable<T> GetOptimalRoutes(T source) {
        List<T> optimalCells = new List<T>();
        if(BetweenHorizontalConcreteCubes(source))
            TryAddTopAndBottomCell(optimalCells, source);
        else if(BetweenVerticalConcreteCubes(source))
            TryAddLeftAndRightCell(optimalCells, source);
        else {
            TryAddCell(optimalCells, source.Owner, source.IndexRow, source.IndexColumn - 2);
            TryAddCell(optimalCells, source.Owner, source.IndexRow, source.IndexColumn + 2);
            TryAddCell(optimalCells, source.Owner, source.IndexRow - 2, source.IndexColumn);
            TryAddCell(optimalCells, source.Owner, source.IndexRow + 2, source.IndexColumn);
        }
        return routeSelector.SelectAvailableCells(source, optimalCells.ToArray());
    }
    public IEnumerable<T> GetPossibleRoutes(T source) {
        List<T> possibleCells = new List<T>();
        if(BetweenHorizontalConcreteCubes(source))
            TryAddTopAndBottomCell(possibleCells, source);
        else if(BetweenVerticalConcreteCubes(source))
            TryAddLeftAndRightCell(possibleCells, source);
        else {
            TryAddTopAndBottomCell(possibleCells, source);
            TryAddLeftAndRightCell(possibleCells, source);
        }
        return routeSelector.SelectAvailableCells(source, possibleCells.ToArray());
    }

    private void TryAddTopAndBottomCell(List<T> list, T source) {
        TryAddCell(list, source.Owner, source.IndexRow - 1, source.IndexColumn);
        TryAddCell(list, source.Owner, source.IndexRow + 1, source.IndexColumn);
    }
    private void TryAddLeftAndRightCell(List<T> list, T source) {
        TryAddCell(list, source.Owner, source.IndexRow, source.IndexColumn - 1);
        TryAddCell(list, source.Owner, source.IndexRow, source.IndexColumn + 1);
    }

    private Boolean TryAddCell(List<T> list, Field gameField, Int32 indexRow, Int32 indexColumn) {
        if(!gameField.OnField(indexRow, indexColumn))
            return false;
        list.Add(gameField.GetCell(indexRow, indexColumn) as T);
        return true;
    }
    private Boolean BetweenHorizontalConcreteCubes(T cell) {
        return cell.IndexRow.IsEven() && cell.IndexColumn.IsUneven();
    }
    private Boolean BetweenVerticalConcreteCubes(T cell) {
        return cell.IndexRow.IsUneven() && cell.IndexColumn.IsEven();
    }
}