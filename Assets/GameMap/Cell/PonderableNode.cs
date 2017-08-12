using System;

public class PonderableNode : CellOnField {
    public Int32 Weight { get; set; }
    private IPonderable<PonderableNode> weightCalculator;

    public PonderableNode(Int32 indexRow, Int32 indexColumn, Field owner, IPonderable<PonderableNode> weightCalculator)
        : base(indexRow, indexColumn, owner) {
        Weight = Int32.MaxValue;
        this.weightCalculator = weightCalculator;
    }
    public PonderableNode(CellOnField cell, IPonderable<PonderableNode> weightCalculator)
        : this(cell.IndexRow, cell.IndexColumn, cell.Owner, weightCalculator) {
    }

    public Int32 CalculateWeight(PonderableNode next, PonderableNode destination) {
        return weightCalculator.GetWeight(this, next, destination);
    }
}