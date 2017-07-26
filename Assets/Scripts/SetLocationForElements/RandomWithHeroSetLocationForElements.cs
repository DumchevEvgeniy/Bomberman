using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomWithHeroSetLocationForElements : RandomSetLocationForElements {
    protected override IEnumerable<Cell> GetProhibitedForUsingCells(Field field) {
        var hero = Resources.Load<GameObject>("Prefabs/Player");
        if(hero == null)
            return null;
        var cellsWithHero = field.FindAll(hero);
        if(cellsWithHero == null || cellsWithHero.IsEmpty())
            return null;
        var cellWithHero = cellsWithHero.First();
        var result = new List<Cell>();
        result.Add(field.GetCell(cellWithHero.IndexRow - 1, cellWithHero.IndexColumn));
        result.Add(field.GetCell(cellWithHero.IndexRow + 1, cellWithHero.IndexColumn));
        result.Add(field.GetCell(cellWithHero.IndexRow, cellWithHero.IndexColumn - 1));
        result.Add(field.GetCell(cellWithHero.IndexRow, cellWithHero.IndexColumn + 1));
        return result;
    }
}
