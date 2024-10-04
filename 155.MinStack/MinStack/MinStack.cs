using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


public class MinStack
{
    private List<int> list;

    public MinStack()
    {
        list = new List<int>();
    }
    private int currentIdx = -1;
    private int currentVal = int.MinValue;
    private int min = int.MaxValue;

    public void Push(int val)
    {
        currentVal = val;

        if (currentIdx ==-1 ||  val < list.First())
            min = val;
        
        list.Add(val);
        currentIdx++;

    }

    public void Pop()
    {
        if (list.Count == 0)
            return;

        list.RemoveAt(currentIdx);
        currentIdx--;

        if (currentVal == min && list.Count>0)
            min = list.Min();

        
        if (currentIdx == -1)
            currentVal = int.MinValue;
        else
            currentVal = list[currentIdx];
    }

    public int Top()
    {
        return currentVal;
    }

    public int GetMin()
    {
        return min;

    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
