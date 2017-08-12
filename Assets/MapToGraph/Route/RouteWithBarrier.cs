using System;
using System.Collections.Generic;

public class RouteWithBarrier : Route {
    private List<Type> barrierTypes = new List<Type>();
    public List<Type> BarrierTypes {
        get { return barrierTypes; }
    }

    public RouteWithBarrier(CellOnField firstCell, CellOnField secondCell)
        : base(firstCell, secondCell) {
    }

    public Boolean ExistBarrier() {
        foreach(var cell in this) {
            if(cell.IsEmpty())
                continue;
            if(cell.DynamicGameObjects.Exists(el => barrierTypes.Exists(t => el.IsDerived(t))))
                return true;
        }
        return false;
    }
}