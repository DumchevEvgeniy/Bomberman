﻿using System;
using System.Collections.Generic;

public class PonderableNode<T> : RelatedNode, IComparable<T> where T : IComparable<T> {
    private IPonderable<PonderableNode<T>, T> weightCalculator;
    public T Weight { get; set; }
    public IComparer<T> WeightComparer { get; set; }

    public PonderableNode(Int32 indexRow, Int32 indexColumn, Field owner, IPonderable<PonderableNode<T>, T> weightCalculator, IComparer<T> weightComparer)
        : base(indexRow, indexColumn, owner) {
        this.weightCalculator = weightCalculator;
        WeightComparer = weightComparer;
    }
    public PonderableNode(Int32 indexRow, Int32 indexColumn, Field owner, IPonderable<PonderableNode<T>, T> weightCalculator)
        : this(indexRow, indexColumn, owner, weightCalculator, null) { }
    public PonderableNode(CellOnField cell, IPonderable<PonderableNode<T>, T> weightCalculator, IComparer<T> weightComparer)
        : this(cell.IndexRow, cell.IndexColumn, cell.Owner, weightCalculator, weightComparer) {
    }
    public PonderableNode(CellOnField cell, IPonderable<PonderableNode<T>, T> weightCalculator)
        : this(cell, weightCalculator, null) { }

    public T CalculateWeight(PonderableNode<T> next, PonderableNode<T> destination) {
        return weightCalculator.GetWeight(this, next, destination);
    }

    public Int32 CompareTo(T otherWeight) {
        return WeightComparer == null ? Weight.CompareTo(otherWeight) : 
            WeightComparer.Compare(Weight, otherWeight);
    }
}