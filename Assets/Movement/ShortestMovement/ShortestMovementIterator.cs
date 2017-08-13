using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ShortestMovementIterator : IEnumerator<PonderableNode<Int32>> {
    private List<PonderableNode<Int32>> openList;
    private List<PonderableNode<Int32>> closeList;
    private PonderableNode<Int32> current;

    public ShortestMovementIterator() {
        Reset();
    }

    public Boolean MoveNext() {
        if(openList.IsEmpty())
            return false;
        current = openList.First(c => c.Weight == openList.Min(el => el.Weight));
        openList.Remove(current);
        closeList.Add(current);
        return true;
    }
    public void Dispose() { }
    public void Reset() {
        openList = new List<PonderableNode<Int32>>();
        closeList = new List<PonderableNode<Int32>>();
        current = null;
    }

    public PonderableNode<Int32> Current { get { return current; } }
    System.Object IEnumerator.Current { get { return Current; } }
    public List<PonderableNode<Int32>> OpenList {
        get { return openList; }
    }
    public List<PonderableNode<Int32>> CloseList {
        get { return closeList; }
    }
}