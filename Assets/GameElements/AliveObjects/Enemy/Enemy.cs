using System;
using UnityEngine;

public class Enemy : MovementObject {
    public const String tag = "Enemy";
    public String Nickname { get; private set; }
    public Int32 Points { get; private set; }
    
    public Enemy(String nickname, Int32 points) {
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
