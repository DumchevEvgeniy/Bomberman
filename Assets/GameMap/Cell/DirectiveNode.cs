﻿using System;
using UnityEngine;

public class DirectiveNode : CellOnField {
    public Vector3 Direction { get; set; }

    public DirectiveNode(Int32 indexRow, Int32 indexColumn, Field owner)
        : base(indexRow, indexColumn, owner) {
        Direction = Vector3.zero;
    }
    public DirectiveNode(CellOnField cellOnField)
        : this(cellOnField.IndexRow, cellOnField.IndexColumn, cellOnField.Owner) { }

    public Vector3 GetRelativeDirection(Cell destination) {
        var xDirection = (IndexRow - destination.IndexRow).Normalize();
        var yDirection = (IndexColumn - destination.IndexColumn).Normalize();
        var zDirection = (IndexColumn - destination.IndexColumn).Normalize();
        return new Vector3(xDirection, yDirection, zDirection);
    }
}

