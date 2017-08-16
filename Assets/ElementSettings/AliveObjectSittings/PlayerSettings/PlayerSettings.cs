using System;
using UnityEngine;

public class PlayerSettings : WallpassPlayerSettings {
    public Int32 numberOfLives = 3;
    public Int32 gamePoints = 0;
    
    public void Initialize(Int32 numberOfLives, Int32 gamePoints) {
        this.numberOfLives = numberOfLives;
        this.gamePoints = gamePoints;        
    }

    public override void Die() {
        base.Die();
        numberOfLives--;
        var character = GetComponent<CharacterController>();
        if(character != null)
            character.enabled = false;
    }
}
