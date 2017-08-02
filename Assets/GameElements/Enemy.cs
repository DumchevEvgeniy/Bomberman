using System;
using UnityEngine;

public class Enemy : MovementObject {
    public String Nickname { get; private set; }
    public Int32 Points { get; private set; }
    public const String Tag = "Enemy";

    public Enemy(String nickname, Int32 points, Single movementSpeed, Single rotationSpeed, Boolean wallpass = false)
        : base(movementSpeed, rotationSpeed, wallpass) {
        Nickname = nickname;
        Points = points;
    }

    public override GameObject CreateGameObject() {
        var enemy =  base.CreateGameObject();
        var enemySettings = enemy.AddComponent<EnemySettings>();
        enemySettings.InitializeMovingSettings(MovementSpeed, RotationSpeed, Wallpass);
        enemySettings.Initialize(Nickname, Points);
        return enemy;
    }

    protected override String GetPrefabName() {
        return "Prefabs/" + Nickname;
    }
}
