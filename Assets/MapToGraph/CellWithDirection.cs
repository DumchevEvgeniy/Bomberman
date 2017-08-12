using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IPonderable<T> where T : class {
    Int32 GetWeight(T source, T next, T destinition);
}

public class NodeWeightCalculator<T> : IPonderable<T> where T : Cell {
    private IPonderableByMovement<T> movementSolver;

    public NodeWeightCalculator(IPonderableByMovement<T> movementSolver) {
        this.movementSolver = movementSolver;
    }

    public Int32 GetWeight(T source, T next, T destination) {
        return movementSolver.GetDistance(source, next) +
            movementSolver.GetDistanceToDestinition(source, destination) +
            movementSolver.GetTimeToRotate(source, next);
    }
}

public interface IPonderableByMovement<T> where T : class {
    Int32 GetDistanceToDestinition(T source, T destinition);
    Int32 GetDistance(T source, T next);
    Int32 GetTimeToRotate(T source, T next);
}

public class CellMovementSolver : IPonderableByMovement<DirectiveNode> {
    public Int32 GetDistance(DirectiveNode source, DirectiveNode next) {
        var distanceByX = Math.Abs(source.IndexRow - next.IndexRow);
        var distanceByZ = Math.Abs(source.IndexColumn - next.IndexColumn);
        return distanceByX + distanceByZ;
    }

    public Int32 GetDistanceToDestinition(DirectiveNode source, DirectiveNode destinition) {
        return GetDistance(source, destinition);
    }

    public Int32 GetTimeToRotate(DirectiveNode source, DirectiveNode next) {
        Vector3 angle = source.Direction - source.GetRelativeDirection(next);
        Int32 positiveX = Math.Abs((Int32)angle.x);
        Int32 positiveZ = Math.Abs((Int32)angle.z);
        return Math.Max(positiveX, positiveZ);
    }
}

public class ShortestMovement {
    private List<DirectiveNode> openList;
    private List<DirectiveNode> closeList;
    private DirectiveNode source;
    private DirectiveNode destination;

    private NodeWeightCalculator<DirectiveNode> graphSolver;
    private RouteSeacher routeSeacher;


    public ShortestMovement(Vector3 direction, CellOnField source, CellOnField destination, 
        RouteSeacher routeSeacher, NodeWeightCalculator<DirectiveNode> graphSolver) {
        this.source = new DirectiveNode(source) { Direction = direction };
        this.destination = new DirectiveNode(destination);
        this.routeSeacher = routeSeacher;
        this.graphSolver = graphSolver;
        openList = new List<DirectiveNode>();
        closeList = new List<DirectiveNode>();
    }

    public void Go() {
        openList.Add(source);
        var routeFromCellOnField = new RouteFromCellOnField(source, routeSeacher);
        foreach(var possibleCell in routeFromCellOnField.GetPossibleRoutes()) {
            var cell = new DirectiveNode(possibleCell);
            if(openList.Exists(c => c.IndexRow == cell.IndexRow && c.IndexColumn == cell.IndexColumn)) {
                
            }
            else {
                var number = graphSolver.GetWeight(source, cell, destination);
            }
        }
        openList.Remove(source);
        closeList.Add(source);
    }

    private RouteSeacher GetRouteSeacher() {
        return new RouteSeacher(new List<Type>() {
            typeof(ConcreteCube),
            typeof(BreakCube)
        });
    }
}

public class Ha : IEnumerator<DirectiveNode> {
    public DirectiveNode Current {
        get {
            throw new NotImplementedException();
        }
    }

    System.Object IEnumerator.Current {
        get {
            throw new NotImplementedException();
        }
    }

    public void Dispose() {
        throw new NotImplementedException();
    }

    public Boolean MoveNext() {
        throw new NotImplementedException();
    }

    public void Reset() {
        throw new NotImplementedException();
    }
}