using System;
using UnityEngine;

public class EmptyMap : BaseMap {
    GameObject gameMap;

    public EmptyMap(Int32 length, Int32 width, DynamicGameObject gameMapTemplate) 
        : base(length, width) {
        InitializeMap(gameMapTemplate);
    }

    private void InitializeMap(DynamicGameObject gameMapTemplate) {
        gameMap = gameMapTemplate.CreateGameObject();
        Single offsetByX = (Int32)(Width / 2.0);
        Single offsetByZ = (Int32)(Length / 2.0);
        gameMap.transform.position = new Vector3(offsetByX, 0, offsetByZ);
        gameMap.transform.localScale = new Vector3(Width, gameMap.transform.localScale.y, Length);
        gameMap.transform.rotation = new Quaternion();
    }

    public void CreateAll() {
        foreach(var cell in Field) {
            foreach(var dynamicGameObject in cell.DynamicGameObjects) {
                var element = dynamicGameObject.CreateGameObject();
                element.transform.position = new Vector3(cell.IndexRow, element.transform.position.y, cell.IndexColumn);
            }
        }
    }
}
