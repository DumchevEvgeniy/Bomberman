using System;
using UnityEngine;

public class Player : MovementObject {
    public const String tag = "Player";
    public String PrefabName { get; set; }
    public Int32 StartGamePoints { get; set; }
    public Int32 StartNumberOfLives { get; set; }
    
    public override void InitializeSettings(GameObject currentObject) {
        var playerSettings = currentObject.AddComponent<PlayerSettings>();
        playerSettings.InitializeMovingSettings(MovementSpeed, RotationSpeed, Wallpass);
        playerSettings.Initialize(StartNumberOfLives, StartGamePoints);
    }

    protected override String GetPrefabName() {
        return "Prefabs/Players/" + PrefabName;
    }
}
