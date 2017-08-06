using System.Collections.Generic;
using System.Linq;

public class BonusesRandomPlacement : RandomPlacement {
    protected override IEnumerable<CellOnField> GetNeededCells(Field field) {
        return field.FindAll(typeof(BreakCube)).Where(cell => cell.DynamicGameObjects.Count == 1);
    }
}
