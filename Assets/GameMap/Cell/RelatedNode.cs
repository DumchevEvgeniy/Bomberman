using System;

public class RelatedNode : DirectedNode {
    public Cell PreviousNode { get; set; }

    public RelatedNode(Int32 indexRow, Int32 indexColumn, Field owner)
        : base(indexRow, indexColumn, owner) { }
    public RelatedNode(CellOnField cellOnField)
        : this(cellOnField.IndexRow, cellOnField.IndexColumn, cellOnField.Owner) { }
}