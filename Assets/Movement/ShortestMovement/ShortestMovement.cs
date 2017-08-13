using System;
using System.Collections.Generic;
using System.Linq;

public class ShortestMovement {
    protected PonderableNode<Int32> source;
    protected PonderableNode<Int32> destination;
    protected IRoute<CellOnField> routeSeacher;
    protected IPonderable<PonderableNode<Int32>, Int32> weightCalculator;
    protected ShortestMovementEnumerator collection;
    public Boolean ExistRoute { get { return Route == null; } }
    public List<CellOnField> Route { get; private set; }

    public ShortestMovement(PonderableNode<Int32> source, PonderableNode<Int32> destination, 
        IRoute<CellOnField> routeSeacher, IPonderable<PonderableNode<Int32>, Int32> weightCalculator) {
        this.source = source;
        this.destination = destination;
        this.routeSeacher = routeSeacher;
        this.weightCalculator = weightCalculator;
        collection = new ShortestMovementEnumerator();
    }
    protected ShortestMovement() : this(null, null, null, null) { }

    public virtual void BuildARoute() {
        collection.Add(source);
        foreach(var item in collection) {
            if(item.Equals(destination)) {
                RouteInitialize(item);
                return;
            }
            FindPossibleRoutes(item);
        }
    }

    private void FindPossibleRoutes(PonderableNode<Int32> sourceNode) {
        foreach(var optimalCell in routeSeacher.GetOptimalRoutes(sourceNode)) {
            if(collection.WasVisited(optimalCell))
                continue;
            if(new Route(sourceNode, optimalCell).Contains(destination))
                collection.Add(CreatePonderableNode(destination, sourceNode));
            var node = collection.Find(optimalCell);
            if(node != null)
                RecalculateParameters(sourceNode, node);
            else
                collection.Add(CreatePonderableNode(optimalCell, sourceNode));
        }
    }
    private PonderableNode<Int32> CreatePonderableNode(CellOnField node, PonderableNode<Int32> previous = null) {
        var newNode = new PonderableNode<Int32>(node, weightCalculator);
        if(previous != null) {
            newNode.PreviousNode = previous;
            newNode.Direction = newNode.GetRelativeDirection(previous);
            newNode.Weight = previous.CalculateWeight(newNode, destination);
        }
        return newNode;
    }
    private void RecalculateParameters(PonderableNode<Int32> from, PonderableNode<Int32> to) {
        var weight = from.CalculateWeight(to, destination);
        if(to.CompareTo(weight) < 0) {
            to.Weight = weight;
            to.PreviousNode = from;
            to.Direction = to.GetRelativeDirection(from);
        }
    }
    private void RouteInitialize(PonderableNode<Int32> last) {
        Route = new List<CellOnField>();
        Route.Add(last);
        var current = last;
        while(current.PreviousNode != null)
            Route.Add(current.PreviousNode as PonderableNode<Int32>);
        Route.Reverse();
    }
}
