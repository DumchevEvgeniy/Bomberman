using System;
using UnityEngine;

public class Bomberman : Player {
    public Boolean PreDetonatePossible { get; set; }
    public Int32 MaxCountBomb { get; set; }
    public Int32 BangDistance { get; set; }

    public override void InitializeSettings(GameObject currentObject) {
        var bombermanSettings = currentObject.AddComponent<CunningBombermanSettings>();
        bombermanSettings.InitializeMovingSettings(MovementSpeed, RotationSpeed, Wallpass);
        bombermanSettings.Initialize(StartNumberOfLives, StartGamePoints);
        bombermanSettings.preDetonatePossible = PreDetonatePossible;
        bombermanSettings.maxCountBomb = MaxCountBomb;
        bombermanSettings.bangDistance = BangDistance;
    }
}
