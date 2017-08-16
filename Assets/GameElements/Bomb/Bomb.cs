using System;
using UnityEngine;

public class Bomb : DynamicGameObject {
    public const String tag = "Bomb";
    private Cell cellForBomb;
    private Int32 distance;
    private Single bangLifeTime;
    private Single timeOfDeath;
    public Action ActionAfterDeath { get; set; }
    public BaseBangController BangController { get; set; }

    public Bomb(Cell cellForBomb, Int32 distance, Single timeOfDeath, Single bangLifeTime) {
        this.cellForBomb = cellForBomb;
        this.distance = distance;
        this.bangLifeTime = bangLifeTime;
        this.timeOfDeath = timeOfDeath;
    }

    protected override String GetPrefabName() {
        return "Prefabs/Bomb";
    }

    protected override GameObject CreateGameObject() {
        var bomb = base.CreateGameObject();
        bomb.transform.position = new Vector3(cellForBomb.IndexRow, bomb.transform.position.y, cellForBomb.IndexColumn);
        var bombSettings = bomb.AddComponent<BombSettings>();
        bombSettings.distance = distance;
        bombSettings.AddActionAfterDeath(ActionAfterDeath);
        bombSettings.bangController = BangController;
        bombSettings.bangLifeTime = bangLifeTime;
        bombSettings.timeOfDeath = timeOfDeath;
        return bomb;        
    }
}
