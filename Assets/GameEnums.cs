using System;

public enum Coordinate {
    X,
    Y,
    Z
}

public enum EnemySpeed : Int32 {
    Slowest = 1,
    Slow = 3,
    Normal = 5,
    Fast = 10
}

public enum BonusTypes {
    Bombs,
    Flames,
    Speed,
    Wallpass,
    Detonator,
    Bombpass,
    Flamepass,
    Mystery
}