using System;

public class Bonus : DynamicGameObject {
    public String Name { get; private set; }
    public Int32 Points { get; private set; }
    public const String Tag = "Bonus";

    public Bonus(String name, Int32 points) {
        Name = name;
        Points = points;
    }

    protected override String GetPrefabName() {
        return "Prefabs/Bonuses/" + Name; 
    }
}
