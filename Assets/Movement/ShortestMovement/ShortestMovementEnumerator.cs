using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ShortestMovementEnumerator : IEnumerable<PonderableNode<Int32>> {
    private ShortestMovementIterator iterator;

    public ShortestMovementEnumerator() {
        iterator = new ShortestMovementIterator();
    }

    public void Add(PonderableNode<Int32> item) {
        iterator.OpenList.Add(item);
    }
    public Boolean WasVisited(CellOnField node) {
        return iterator.CloseList.Exists(el => el.Equals(node));
    }
    public PonderableNode<Int32> Find(CellOnField node) {
        return iterator.OpenList.FirstOrDefault(el => el.Equals(node));
    }

    public IEnumerator<PonderableNode<Int32>> GetEnumerator() {
        while(iterator.MoveNext())
            yield return iterator.Current;
    }
    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}