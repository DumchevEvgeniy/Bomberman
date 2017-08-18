using System;

public class SmartMap : GameMap {
    public SmartMap(Int32 length, Int32 width, DynamicGameObject gameMapTemplate, 
        DynamicGameObject concreteCubeTemplate) 
        : base(length, width, gameMapTemplate, concreteCubeTemplate) {
    }

    public void AddElements<T>(GameElements<T> collection) where T : BasePlacement, new() {
        var cells = collection.GetPlacements(Field);
        foreach(var cell in cells)
            Field.GetCell(cell.IndexRow, cell.IndexColumn).AddGameObject(collection.Element);
    }
    public void AddElements<T>(DynamicGameObject element, Int32 elementsCount) where T : BasePlacement, new() {
        AddElements(new GameElements<T>(element, elementsCount));
    }
}
