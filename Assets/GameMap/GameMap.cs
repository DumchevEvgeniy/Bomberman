using System;

public class GameMap : EmptyMap {
    public GameMap(Int32 length, Int32 width, DynamicGameObject gameMapTemplate, DynamicGameObject concreteCubeTemplate) 
        : base(length, width, gameMapTemplate) {
        InitializeConcreteCubes(concreteCubeTemplate);
    }

    private void InitializeConcreteCubes(DynamicGameObject concreteCubeTemplate) {
        foreach(var cell in Field)
            if(IsCellForConcreteCube(cell))
                cell.AddGameObject(concreteCubeTemplate);
    }

    private Boolean IsCellForConcreteCube(CellOnField cell) {
        return OnLeftOrRightBorder(cell.IndexColumn) ||
                OnTopOrBottomBorder(cell.IndexRow) ||
                OnNeededPosition(cell.IndexRow, cell.IndexColumn);
    }
    private Boolean OnLeftOrRightBorder(Int32 indexColumn) {
        return indexColumn == 0 || indexColumn == Length - 1;
    }
    private Boolean OnTopOrBottomBorder(Int32 indexRow) {
        return indexRow == 0 || indexRow == Width - 1;
    }
    private Boolean OnNeededPosition(Int32 indexRow, Int32 indexColumn) {
        return indexRow % 2 == 0 && indexColumn % 2 == 0;
    }
}
