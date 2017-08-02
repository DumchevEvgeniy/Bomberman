using System;
using UnityEngine;

public class PlayerSettings : MovingObjectSettings {
    public Int32 numberOfLives;
    public Int32 gamePoints;

    public void Initialize(Int32 numberOfLives, Int32 gamePoints) {
        this.numberOfLives = numberOfLives;
        this.gamePoints = gamePoints;        
    }

    public override void Die() {
        base.Die();
        numberOfLives--;
    }
}
