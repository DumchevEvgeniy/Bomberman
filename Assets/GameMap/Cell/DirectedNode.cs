using System;
using UnityEngine;

public class DirectedNode : CellOnField {
    public Vector3 Direction { get; set; }

    public DirectedNode(Int32 indexRow, Int32 indexColumn, Field owner)
        : base(indexRow, indexColumn, owner) {
        Direction = Vector3.zero;
    }
    public DirectedNode(CellOnField cellOnField)
        : this(cellOnField.IndexRow, cellOnField.IndexColumn, cellOnField.Owner) { }

    public Vector3 GetRelativeDirection(Cell node) {
        var xDirection = (IndexRow - node.IndexRow).Normalize();
        var zDirection = (IndexColumn - node.IndexColumn).Normalize();
        return new Vector3(xDirection, 0, zDirection);
    }
}

