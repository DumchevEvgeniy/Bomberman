using System;
using System.Collections.Generic;

public class RouteSeacher : IRouteAvailable<CellOnField> {
    private IEnumerable<Type> barriers;

    public RouteSeacher(IEnumerable<Type> barriers) {
        this.barriers = barriers;
    }

    public IEnumerable<CellOnField> SelectAvailableCells(CellOnField current, params CellOnField[] cellForRoute) {
        foreach(var cell in cellForRoute) {
            var route = new RouteWithBarrier(current, cell);
            route.BarrierTypes.AddRange(barriers);
            if(!route.ExistBarrier())
                yield return cell;
        }
    }
}