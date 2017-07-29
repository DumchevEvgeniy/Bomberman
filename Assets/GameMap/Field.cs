using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class Field : IEnumerable<Cell> {
    private Cell[,] field;
    public Int32 Length { get; private set; }
    public Int32 Width { get; private set; }

    public Field(Int32 length, Int32 width) {
        Length = length;
        Width = width;
        field = new Cell[width, length];
        InitializeCells();
    }

    private void InitializeCells() {
        for(Int32 indexRow = 0; indexRow < Width; indexRow++)
            for(Int32 indexColumn = 0; indexColumn < Length; indexColumn++)
                field[indexRow, indexColumn] = new Cell(indexRow, indexColumn, this);
    }

    public Field AddElement(Int32 indexRow, Int32 indexColumn, DynamicGameObject element) {
        var cell = GetCell(indexRow, indexColumn);
        if(cell.IsEmpty())
            cell.DynamicGameObject = element;
        return this;
    }
    public DynamicGameObject GetDynamicGameObject(Int32 indexRow, Int32 indexColumn) {
        return GetCell(indexRow, indexColumn).DynamicGameObject;
    }
    public Cell GetCell(Int32 indexRow, Int32 indexColumn) {
        return field[indexRow, indexColumn];
    }

    public IEnumerable<Cell> FindAll(GameObject element) {
        return this.Where(cell => 
            !cell.IsEmpty() && cell.DynamicGameObject.ToGameObject().Equals(element));
    }
    public IEnumerable<Cell> FindAll(DynamicGameObject element) {
        return this.Where(cell =>
            !cell.IsEmpty() && cell.DynamicGameObject.Equals(element));
    }

    public IEnumerable<Cell> GetEmptyCells() {
        return this.Where(cell => cell.IsEmpty());
    }
    public Boolean OnField(Int32 indexRow, Int32 indexColumn) {
        return indexRow >= 0 && indexRow < Width &&
            indexColumn >= 0 && indexColumn < Length;
    }

    public IEnumerator<Cell> GetEnumerator() {
        for(Int32 indexRow = 0; indexRow < Width; indexRow++)
            for(Int32 indexColumn = 0; indexColumn < Length; indexColumn++)
                yield return GetCell(indexRow, indexColumn);
    }
    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}
