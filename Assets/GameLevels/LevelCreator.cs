using System;
using UnityEngine;

public class LevelCreator : MonoBehaviour {
    public Int32 length = 21;
    public Int32 width = 13;
    public Int32 sandCubesCount = 54;
    public Int32 bonusBombsCount = 0;
    public Int32 bonusFlamesCount = 0;
    public Int32 bonusSpeedCount = 0;
    public Int32 bonusWallpassCount = 0;
    public Int32 bonusDetonatorCount = 0;

    private void Start() {
        var gameMap = new GameMapWithComponents(length, width, new MapFloor(), new ConcreteCube());
        gameMap.AddElements(new GameElements<RandomPlacementOnEmptyPosition>(new Player(1, 2, false), 1));
        gameMap.AddElements(new GameElements<RandomPlacementWithPlayerDistance>(new BreakCube(), sandCubesCount));
        gameMap.AddElements(new GameElements<RandomPlacementWithPlayerDistance>(new Enemy("Enemy", 100, 1, 2, false), 6));
        gameMap.AddElements(new GameElements<BonusesRandomPlacement>(new Bonus("Bombs", 200), bonusBombsCount));
        gameMap.AddElements(new GameElements<BonusesRandomPlacement>(new Bonus("Flames", 200), bonusFlamesCount));
        gameMap.AddElements(new GameElements<BonusesRandomPlacement>(new Bonus("Speed", 200), bonusSpeedCount));
        gameMap.AddElements(new GameElements<BonusesRandomPlacement>(new Bonus("Wallpass", 200), bonusWallpassCount));
        gameMap.AddElements(new GameElements<BonusesRandomPlacement>(new Bonus("Detonator", 200), bonusDetonatorCount));
        gameMap.CreateAll();
    }
}
