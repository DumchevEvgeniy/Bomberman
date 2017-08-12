using System;

public class EnemySettings : MovementObjectSettings {
    public String nickname;
    public Int32 points;

    public void Initialize(String nickname, Int32 points) {
        this.nickname = nickname;
        this.points = points;
    }
}
