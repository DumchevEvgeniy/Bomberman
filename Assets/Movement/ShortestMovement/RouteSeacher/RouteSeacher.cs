using System;
using System.Collections.Generic;

public class RouteSeacher<T> : IRouteAvailable<T> where T : CellOnField {
    private IEnumerable<Type> barriers;

    public RouteSeacher(IEnumerable<Type> barriers) {
        this.barriers = barriers;
    }

    public IEnumerable<T> SelectAvailableCells(T current, params T[] cellForRoute) {
        foreach(var cell in cellForRoute) {
            var route = new RouteWithBarrier(current, cell);
            route.BarrierTypes.AddRange(barriers);
            if(!route.ExistBarrier())
                yield return cell;
        }
    }
}