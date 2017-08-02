using System;
using UnityEngine;

public class EnemySettings : MovingObjectSettings {
    public String nickname;
    public Int32 points;

    public void Initialize(String nickname, Int32 points) {
        this.nickname = nickname;
        this.points = points;
    }
}
