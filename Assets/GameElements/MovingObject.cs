using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class MovingObject : DynamicGameObject {
    public BaseMovingAbility AbilityMove { get; set; }
    public BaseRotatingAbility RotatingAbility { get; set; }
}