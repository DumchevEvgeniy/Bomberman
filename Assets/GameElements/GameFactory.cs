using UnityEngine;

public static class GameFactory {
    public static Bomberman CreateBomberSnowman() {
        var bomberman = new Bomberman() {
            //PrefabName = "Snowman",
            PrefabName = "BomberAgent",
            Wallpass = false,
            PreDetonatePossible = false,
            BangDistance = 1,
            MaxCountBomb = 1,
            MovementSpeed = 2,
            RotationSpeed = 3,
            StartGamePoints = 0,
            StartNumberOfLives = 3
        };
        bomberman.AddScriptType(typeof(PlayerRotation));
        bomberman.AddScriptType(typeof(PlayerMovement));
        bomberman.AddScriptType(typeof(PlayerDeath));
        return bomberman;
    }

    public static Enemy CreateEasyEnemy() {
        var enemy = new Enemy("Enemy", 100) {
            MovementSpeed = 2f,
            RotationSpeed = 50,
            Wallpass = false
        };
        enemy.AddScriptType(typeof(EnemyWithSmoothMovement));
        return enemy;
    }

    public static Enemy CreateSmartEnemy(SmartMap map) {
        var enemy = new SmartEnemy("HardEnemy", 100, map) {
            MovementSpeed = 2,
            RotationSpeed = 70,
            Wallpass = false
        };
        enemy.AddScriptType(typeof(EnemyWithSmartMovement));
        return enemy;
    }

    public static Bonus CreateBonusBombs() {
        return new Bonus("Bombs", BonusTypes.Bombs, 600) {
            RotationSpeed = 5,
            RotationAngle = new Vector3(5, 10, 15)
        };
    }
    public static Bonus CreateBonusDetonator() {
        return new Bonus("Detonator", BonusTypes.Detonator, 10000) {
            RotationSpeed = 5,
            RotationAngle = new Vector3(10, 10, 3)
        };
    }
    public static Bonus CreateBonusFlames() {
        return new Bonus("Flames", BonusTypes.Flames, 400) {
            RotationSpeed = 6,
            RotationAngle = new Vector3(0, 0, Random.Range(5, 15))
        };
    }
    public static Bonus CreateBonusSpeed() {
        return new Bonus("Speed", BonusTypes.Speed, 1000) {
            RotationSpeed = 8,
            RotationAngle = new Vector3(0, Random.Range(5, 10), 0)
        };
    }
    public static Bonus CreateBonusWallpass() {
        return new Bonus("Wallpass", BonusTypes.Wallpass, 7000) {
            RotationSpeed = 7,
            RotationAngle = new Vector3(Random.Range(5, 15), Random.Range(5, 15), Random.Range(5, 15))
        };
    }
}
