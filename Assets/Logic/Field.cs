using System;
using System.Collections.Generic;
using UnityEngine;

public class Field {
    private Cell[,] field;

    public Field(Int32 width, Int32 length) {
        field = new Cell[width, length];
        InitializeCells();
    }

    private void InitializeCells() {
        for(Int32 indexRow = 0; indexRow < Width; indexRow++)
            for(Int32 indexColumn = 0; indexColumn < Length; indexColumn++)
                field[indexRow, indexColumn] = new Cell(indexRow, indexColumn);
    }

    public Field AddElement(Int32 indexRow, Int32 indexColumn, GameObject element) {
        var cell = GetCell(indexRow, indexColumn);
        if(cell.IsEmpty())
            cell.GameObject = element;
        return this;
    }
    public GameObject GetGameObject(Int32 indexRow, Int32 indexColumn) {
        return GetCell(indexRow, indexColumn).GameObject;
    }
    public Cell GetCell(Int32 indexRow, Int32 indexColumn) {
        return field[indexRow, indexColumn];
    }

    public List<Cell> FindAll(GameObject hero) {
        var result = new List<Cell>();
        ForEach(cell => {
            if(!cell.IsEmpty() && cell.GameObject.Equals(hero))
                result.Add(cell);
        });
        return result;
    }

    public Boolean OnField(Int32 indexRow, Int32 indexColumn) {
        return indexRow >= 0 && indexRow < Width &&
            indexColumn >= 0 && indexColumn < Length;
    }

    public List<Cell> GetAllEmptyCells() {
        List<Cell> result = new List<Cell>();
        ForEach(cell => {
            if(cell.IsEmpty())
                result.Add(cell);
        });
        return result;
    }
    public void ForEach(Action<Cell> action) {
        for(Int32 indexRow = 0; indexRow < Width; indexRow++)
            for(Int32 indexColumn = 0; indexColumn < Length; indexColumn++)
                action(GetCell(indexRow, indexColumn));
    }

    public Int32 Length {
        get { return field.GetLength(1); }
    }
    public Int32 Width {
        get { return field.GetLength(0); }
    }
}
