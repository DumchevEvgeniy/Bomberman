using System;

public class GameMapWithComponents : GameMap {
    public GameMapWithComponents(Int32 length, Int32 width, DynamicGameObject gameMapTemplate, 
        DynamicGameObject concreteCubeTemplate) 
        : base(length, width, gameMapTemplate, concreteCubeTemplate) {
    }

    public void AddElements<T>(ElementCollection<T> collection) where T : BasePlacementMethod, new() {
        var cells = collection.GetPlacements(Field);
        foreach(var cell in cells)
            Field.GetCell(cell.IndexRow, cell.IndexColumn).PutGameObject(collection.Element);
    }
}
