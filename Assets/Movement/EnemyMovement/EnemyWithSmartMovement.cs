using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyWithSmartMovement : EnemyWithSmoothMovement {
    protected ShortestMovementProvider provider;
    protected SmartEnemySettings smartEnemySettings;
    protected Field field;

    protected override void OnStart() {
        base.OnStart();
        smartEnemySettings = GetComponent<SmartEnemySettings>();
        field = smartEnemySettings.gameMap.Field;
    }

    protected override Boolean CanMove() {
        if(CanSmartMove())
            return true; 
        provider = null;
        return base.CanMove();
    }
    protected override Single GetRotationAngle() {
        if(provider == null || !provider.ExistRoute || provider.Route.IsEmpty())
            return base.GetRotationAngle();
        var first = provider.First();
        var second = provider.Route.Count == 1 ? first : provider.ElementAt(1);
        return GetAngle(first, second);
    }
    protected override Boolean NeededRotateAfterMoving(GameObject gameObject) {
        return provider.ExistRoute ? false : base.NeededRotateAfterMoving(gameObject);
    }

    protected virtual IRoute<CellOnField> RouteSeacher {
        get {
            var barrierTypes = new List<Type>();
            barrierTypes.Add(typeof(ConcreteCube));
            barrierTypes.Add(typeof(Bonus));
            if(!smartEnemySettings.wallpass)
                barrierTypes.Add(typeof(BreakCube));
            var routeSeacher = new RouteSeacher<CellOnField>(barrierTypes);
            return new RouteFromCell<CellOnField>(routeSeacher);
        }
    }

    private Boolean CanSmartMove() {
        if(smartEnemySettings == null || field == null)
            return false;
        var enemyPosition = GetCellOnField(gameObject.GetIntegerPosition());
        var player = gameObject.scene.FindPlayer();
        if(player == null)
            return false;
        var playerPositon = GetCellOnField(player.GetIntegerPosition());
        provider = new ShortestMovementProvider(gameObject.transform.forward, enemyPosition, playerPositon);
        provider.RouteSeacher = RouteSeacher;
        provider.BuildARoute();
        if(!provider.ExistRoute)
            return false;
        return GetRotationAngle() == 0 ? true : false;
    }
    private Single GetAngle(DirectedNode first, DirectedNode second) {
        var rotation = -first.GetRelativeDirection(second);
        return Vector3.Angle(first.Direction, rotation);
    }
    private CellOnField GetCellOnField(Vector3 position) {
        var cell = position.ToCell();
        return field.GetCell(cell.IndexRow, cell.IndexColumn);
    }
}