using System;
using UnityEngine;

public class Player : MovingObject {
    private readonly Int32 startGamePoints = 0;
    private readonly Int32 startNumberOfLives = 3;
    public const String Tag = "Player";

    public Player(Single movingSpeed, Single rotatingSpeed, Boolean wallpass = false) 
        : base(movingSpeed, rotatingSpeed, wallpass) {
    }

    public override GameObject CreateGameObject() {
        var player = base.CreateGameObject();
        var playerSettings = player.AddComponent<PlayerSettings>();
        playerSettings.InitializeMovingSettings(MovingSpeed, RotatedSpeed, Wallpass);
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
