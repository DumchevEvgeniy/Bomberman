using System.Collections.Generic;
using System.Linq;

public class RandomPlacementMethodWithConsideringPlayerDistance : RandomPlacementMethod {
    protected override IEnumerable<CellOnField> GetProhibitedForUsingCells(Field field) {
        var cellsWithHero = field.FindAll(typeof(Player));
        if(cellsWithHero == null || cellsWithHero.IsEmpty())
            return null;
        var cellWithHero = cellsWithHero.First();
        return new List<CellOnField>() {
            field.GetCell(cellWithHero.IndexRow - 1, cellWithHero.IndexColumn),
            field.GetCell(cellWithHero.IndexRow + 1, cellWithHero.IndexColumn),
            field.GetCell(cellWithHero.IndexRow, cellWithHero.IndexColumn - 1),
            field.GetCell(cellWithHero.IndexRow, cellWithHero.IndexColumn + 1),
        };
    }
}
