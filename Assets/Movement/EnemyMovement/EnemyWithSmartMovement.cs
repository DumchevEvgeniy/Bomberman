using System;
using UnityEngine;

public class EnemyWithSmartMovement : EnemyWithSmoothMovement {
    protected Graph graph;

    protected override void OnStart() {
        base.OnStart();
        var smartEnemySettings = GetComponent<SmartEnemySettings>();
        //gameMap = smartEnemySettings.gameMap;
        //gameMap = smartEnemySettings.gameMap.ToGraph();
    }

    protected override Boolean CanMove() {
        var enemyPosition = gameObject.GetIntegerPosition().ToCell();
        var playerPositon = gameObject.scene.FindPlayer().GetIntegerPosition().ToCell();
        graph.BuildARoute(enemyPosition, playerPositon);
        if(graph.ExistPath) {
            return true; // если уже повернут туда
            // в противном случае вызовется GetRotationAngle - там определить нужный угол поворота
        }
        return base.CanMove();
    }

    protected override Single GetRotationAngle() {
        
        return base.GetRotationAngle();
    }

    protected override Boolean NeededRotateAfterMoving(GameObject gameObject) {
        return graph.ExistPath ? false : base.NeededRotateAfterMoving(gameObject);
    }
}