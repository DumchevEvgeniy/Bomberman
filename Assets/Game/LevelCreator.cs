using System;
using UnityEngine;

public class LevelCreator : MonoBehaviour {
    public Int32 length = 21;
    public Int32 width = 13;
    public Int32 sandCubesCount = 54;
    public Int32 enemiesCount = 6;
    public Int32 bonusBombsCount = 0;
    public Int32 bonusFlamesCount = 0;
    public Int32 bonusSpeedCount = 0;
    public Int32 bonusWallpassCount = 0;
    public Int32 bonusDetonatorCount = 0;

    private void Start() {
        var gameMap = new GameMapWithComponents(length, width, new MapFloor(), new ConcreteCube());
        gameMap.AddElements(new GameElements<RandomPlacementOnEmptyPosition>(GameFactory.CreateBomberSnowman(), 1));
        gameMap.AddElements(new GameElements<RandomPlacementWithPlayerDistance>(new BreakCube(), sandCubesCount));
        gameMap.AddElements(new GameElements<RandomPlacementWithPlayerDistance>(GameFactory.CreateEasyEnemy(), enemiesCount));
        gameMap.AddElements(new GameElements<BonusesRandomPlacement>(GameFactory.CreateBonusBombs(), bonusBombsCount));
        gameMap.AddElements(new GameElements<BonusesRandomPlacement>(GameFactory.CreateBonusFlames(), bonusFlamesCount));
        gameMap.AddElements(new GameElements<BonusesRandomPlacement>(GameFactory.CreateBonusSpeed(), bonusSpeedCount));
        gameMap.AddElements(new GameElements<BonusesRandomPlacement>(GameFactory.CreateBonusWallpass(), bonusWallpassCount));
        gameMap.AddElements(new GameElements<BonusesRandomPlacement>(GameFactory.CreateBonusDetonator(), bonusDetonatorCount));
        gameMap.CreateAll();
    }
}
