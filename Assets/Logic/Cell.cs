using System;
using UnityEngine;

public class Cell {
    private Int32 indexRow;
    private Int32 indexColumn;
    private GameObject gameObject;

    public Cell(Int32 indexRow, Int32 indexColumn) {
        this.indexRow = indexRow;
        this.indexColumn = indexColumn;
    }

    public Boolean IsEmpty() {
        return gameObject == null;
    }

    public GameObject GameObject {
        get { return gameObject; }
        set { gameObject = value; }
    }
    public Int32 IndexRow {
        get { return indexRow; }
    }
    public Int32 IndexColumn {
        get { return indexColumn; }
    }
}
