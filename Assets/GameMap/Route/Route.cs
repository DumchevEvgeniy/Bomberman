using System;
using System.Collections;
using System.Collections.Generic;

public class Route : IEnumerable<CellOnField> {
    public CellOnField FirstCell { get; protected set; }
    public CellOnField SecondCell { get; protected set; }

    public Route(CellOnField firstCell, CellOnField secondCell) {
        FirstCell = firstCell;
        SecondCell = secondCell;
    }

    public Boolean IsHorizontal() {
        return FirstCell.IndexRow == SecondCell.IndexRow;
    }
    public Boolean IsVertical() {
        return FirstCell.IndexColumn == SecondCell.IndexColumn;
    }

    public IEnumerator<CellOnField> GetEnumerator() {
        var field = FirstCell.Owner;
        if(IsHorizontal()) {
            var from = Math.Min(FirstCell.IndexRow, SecondCell.IndexRow);
            var to = Math.Max(FirstCell.IndexRow, SecondCell.IndexRow);
            for(Int32 indexRow = from; indexRow <= to; indexRow++)
                yield return field.GetCell(indexRow, FirstCell.IndexColumn);
        }
        else {
            var from = Math.Min(FirstCell.IndexColumn, SecondCell.IndexColumn);
            var to = Math.Max(FirstCell.IndexColumn, SecondCell.IndexColumn);
            for(Int32 indexColumn = from; indexColumn <= to; indexColumn++)
                yield return field.GetCell(FirstCell.IndexRow, indexColumn);
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}
