using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Graph {
    public List<Cell> path;

    public void BuildARoute(Cell source, Cell destination) {
        return;
    }

    public Boolean ExistPath {
        get { return !path.IsEmpty(); }
    }

    public Cell GetNextCell() {
        return path[0];
    }

    public Boolean NeedRotate() {
        return true;
    }
}