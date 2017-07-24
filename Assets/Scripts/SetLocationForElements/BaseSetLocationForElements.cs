using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSetLocationForElements : MonoBehaviour {
    public Int32 neededCountElements = 1;
    [SerializeField] private GameObject elementPrefab;

    public void InitializeElements() {
        var mapCreator = GetComponent<MapCreator>();
        if(mapCreator == null)
            return;
        if(elementPrefab == null)
            return;
        var field = mapCreator.Field;
        var neededCells = GetCellsForLocationElementPrefab(field, neededCountElements);
        AddGameObjects(field, neededCells);
    }

    protected abstract IEnumerable<Cell> GetCellsForLocationElementPrefab(Field field, Int32 neededCountElements);

    private void AddGameObjects(Field field, IEnumerable<Cell> cells) {
        foreach(var cell in cells)
            field.GetCell(cell.IndexRow, cell.IndexColumn).GameObject = elementPrefab;
    }
}