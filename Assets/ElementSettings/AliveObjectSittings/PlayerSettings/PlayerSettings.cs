using System;
using System.Collections.Generic;

public class PlayerSettings : WallpassPlayerSettings {
    public Int32 numberOfLives;
    public Int32 gamePoints;
    public Int32 countBomb;
    private List<Cell> mortgagedBombs = new List<Cell>();

    public void Initialize(Int32 numberOfLives, Int32 gamePoints) {
        this.numberOfLives = numberOfLives;
        this.gamePoints = gamePoints;        
    }

    public override void Die() {
        base.Die();
        numberOfLives--;
    }

    public Boolean ExistBomb() {
        return countBomb > 0;
    }
    public Boolean BombStandsOnThePosition(Cell position) {
        return mortgagedBombs.Contains(position);
    }
    public void AddBomb(Cell position) {
        mortgagedBombs.Remove(position);
        countBomb++;
    }
    public void RemoveBomb(Cell position) {
        mortgagedBombs.Add(position);
        countBomb--;
    }
}