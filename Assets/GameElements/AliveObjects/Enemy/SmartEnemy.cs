using System;
using UnityEngine;

public class SmartEnemy : Enemy {
    SmartMap map;

    public SmartEnemy(String nickname, Int32 points, SmartMap map) 
        : base(nickname, points) {
        this.map = map;
    }

    public override void InitializeSettings(GameObject currentObject) {
        var enemySettings = currentObject.AddComponent<SmartEnemySettings>();
        enemySettings.InitializeMovingSettings(MovementSpeed, RotationSpeed, Wallpass);
        enemySettings.Initialize(Nickname, Points);
        enemySettings.gameMap = map;
    }
}
