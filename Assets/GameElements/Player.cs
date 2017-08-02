using System;
using UnityEngine;

public class Player : MovementObject {
    private readonly Int32 startGamePoints = 0;
    private readonly Int32 startNumberOfLives = 3;
    public const String Tag = "Player";

    public Player(Single movementSpeed, Single rotationSpeed, Boolean wallpass = false) 
        : base(movementSpeed, rotationSpeed, wallpass) {
    }

    public override GameObject CreateGameObject() {
        var player = base.CreateGameObject();
        var playerSettings = player.AddComponent<PlayerSettings>();
        playerSettings.InitializeMovingSettings(MovementSpeed, RotationSpeed, Wallpass);
        playerSettings.Initialize(startNumberOfLives, startGamePoints);
        return player;
    }

    public PlayerSettings GetSetting(GameObject gameObject) {
        return gameObject.GetComponent<PlayerSettings>();
    }

    protected override String GetPrefabName() {
        return "Prefabs/Snowman";
    }
}
