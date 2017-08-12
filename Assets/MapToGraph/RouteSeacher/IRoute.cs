using System.Collections.Generic;

public interface IRoute<T> where T : Cell {
    IEnumerable<T> GetPossibleRoutes();
}

