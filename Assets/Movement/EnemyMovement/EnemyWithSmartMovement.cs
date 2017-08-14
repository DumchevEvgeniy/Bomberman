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
            return GetRotationAngle() == 0 ? true : false;
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
        return (provider == null || !provider.ExistRoute) ? base.NeededRotateAfterMoving(gameObject) : false;
    }

    protected virtual IRoute<CellOnField> RouteSeacher {
        get {
            var barrierTypes = new List<Type>();
            barrierTypes.Add(typeof(ConcreteCube));
            barrierTypes.Add(typeof(Bomb));
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
        return provider.ExistRoute;
    }
    private Single GetAngle(DirectedNode first, DirectedNode second) {
        var mainDirection = first.Direction;
        var neededDirection = second.GetRelativeDirection(first);
        if(mainDirection == neededDirection)
            return 0;
        if(mainDirection == -neededDirection)
            return random.Next(0, 2) == 0 ? -180 : 180;
        if(mainDirection == Vector3.right)
            return neededDirection == Vector3.forward ? -90 : 90;
        if(mainDirection == Vector3.left)
            return neededDirection == Vector3.back ? -90 : 90;
        if(mainDirection == Vector3.back)
            return neededDirection == Vector3.right ? -90 : 90;
        return neededDirection == Vector3.left ? -90 : 90;
    }

    private CellOnField GetCellOnField(Vector3 position) {
        var cell = position.ToCell();
        return field.GetCell(cell.IndexRow, cell.IndexColumn);
    }
}