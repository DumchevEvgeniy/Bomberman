using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MovingObject {
    public Single Speed { get; set; }

    public Player() {
        Speed = 1;
    }

    protected override String GetPrefabName() {
        return "Prefabs/Snowman";
    }
}

public class Enemy : MovingObject {
    private String name;
    private Single speed;
    private Boolean wallpass;
    private Int32 costGamePoints;

    public Enemy(/*String name, Single speed*/) {
        //this.name = name;
        //this.speed = speed;
    }

    protected override String GetPrefabName() {
        return "Prefabs/Enemy";
    }
}

public class BreakCube : DynamicGameObject {
    protected override String GetPrefabName() {
        return "Cubic";
    }
}

