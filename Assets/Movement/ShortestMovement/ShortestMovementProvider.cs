using System;
using System.Collections.Generic;
using UnityEngine;

public class ShortestMovementProvider : ShortestMovement {
    private Vector3 direction;
    private CellOnField sourceCell;
    private CellOnField destinationCell;
    public IPonderable<PonderableNode<Int32>, Int32> WeightCalculator {
        get { return weightCalculator; }
        set { weightCalculator = value; }
    }
    public IRoute<CellOnField> RouteSeacher {
        get { return routeSeacher; }
        set { routeSeacher = value; }
    }

    public ShortestMovementProvider(Vector3 direction, CellOnField source, CellOnField destination) : base() {
        this.direction = direction;
        sourceCell = source;
        destinationCell = destination;
    }

    public override void BuildARoute() {
        weightCalculator = WeightCalculator ?? DefaultWeightCalculator;
        routeSeacher = RouteSeacher ?? DefaultRouteSeacher;
        source = new PonderableNode<Int32>(sourceCell, weightCalculator);
        destination = new PonderableNode<Int32>(destinationCell, weightCalculator);
        base.BuildARoute();
    }

    private IPonderable<PonderableNode<Int32>, Int32> DefaultWeightCalculator {
        get { return new NodeWeightCalculator<PonderableNode<Int32>>(
            new CellMovementSolver<PonderableNode<Int32>>()); }
    }
    private IRoute<CellOnField> DefaultRouteSeacher {
        get {
            var barrierTypes = new List<Type> { typeof(ConcreteCube) };
            var routeSeacher = new RouteSeacher<CellOnField>(barrierTypes);
            return new RouteFromCell<CellOnField>(routeSeacher);
        }
    }
}

//public class ShortestMovement {
//    private List<PonderableNode<Int32>> openList;
//    private List<PonderableNode<Int32>> closeList;
//    private PonderableNode<Int32> source;
//    private PonderableNode<Int32> destination;
//    private NodeWeightCalculator<PonderableNode<Int32>> nodeWeightCalculator;
//    private IRoute<CellOnField> routeSeacher;

//    public ShortestMovement(Vector3 direction, CellOnField source, CellOnField destination, 
//        NodeWeightCalculator<PonderableNode<Int32>> nodeWeightCalculator) {
//        this.source = new PonderableNode<Int32>(source, nodeWeightCalculator) { Direction = direction };
//        this.destination = new PonderableNode<Int32>(destination, nodeWeightCalculator);
//        this.nodeWeightCalculator = nodeWeightCalculator;
//        openList = new List<PonderableNode<Int32>>() { this.source };
//        closeList = new List<PonderableNode<Int32>>();
//    }

//    public void Go() {
//        while(true) {
//            if(openList.IsEmpty()) {
//                //сказать что нет пути
//                return;
//            }
//            var cellWithMinWeight = openList.First(c => c.Weight == openList.Min(el => el.Weight));
//            openList.Remove(cellWithMinWeight);
//            closeList.Add(cellWithMinWeight);

//            foreach(var possibleCell in routeSeacher.GetOptimalRoutes(cellWithMinWeight)) {
//                if(possibleCell.Equals(destination) || new Route(cellWithMinWeight, possibleCell).Contains(destination)) {
//                    openList.Add(destination);
//                }
//                if(closeList.Exists(el => el.Equals(possibleCell)))
//                    continue;

//                var next = openList.FirstOrDefault(el => el.Equals(possibleCell));

//                if(next != null) {
//                    var weight = cellWithMinWeight.CalculateWeight(next, destination);
//                    if(next.CompareTo(weight) < 0) {
//                        next.Weight = weight;
//                        next.PreviousNode = cellWithMinWeight;
//                        next.Direction = next.GetRelativeDirection(cellWithMinWeight);
//                    }
//                }
//                else {
//                    var newNode = new PonderableNode<Int32>(possibleCell, nodeWeightCalculator);
//                    newNode.PreviousNode = cellWithMinWeight;
//                    newNode.Direction = newNode.GetRelativeDirection(cellWithMinWeight);
//                    newNode.Weight = cellWithMinWeight.CalculateWeight(next, destination);
//                    openList.Add(newNode);
//                }
//            }
//        }
//    }
//}