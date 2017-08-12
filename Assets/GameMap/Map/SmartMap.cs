using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SmartMap : GameMapWithComponents {
    public SmartMap(Int32 length, Int32 width, DynamicGameObject gameMapTemplate, DynamicGameObject concreteCubeTemplate) 
        : base(length, width, gameMapTemplate, concreteCubeTemplate) {
    }

}