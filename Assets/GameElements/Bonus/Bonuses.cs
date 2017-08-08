using UnityEngine;

public static class Bonuses {
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
