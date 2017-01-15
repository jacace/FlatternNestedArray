
using System.Collections.Generic;
/// <summary>
/// This namespace simply lists other approchaes
/// </summary>
namespace FlatternNestedArray
{
    /// <summary>
    /// This class contains three fields to use one at at time without too much casting between types
    /// </summary>
    class ArrayElement
    {
        public int Num { get; set; }
        public int[] ArrNum { get; set; }
        public ArrayElement[] Elements { get; set; }
    }


    /// <summary>
    /// This class does flatter the list but it does excesive boxing/unboxing
    /// </summary>
    class PoorNestedArray
    {

        private int[] Flattern(object[] arr)
        {
            List<int> list = new List<int>();
            if (arr != null)
            {
                Stack<object> stack = new Stack<object>();
                stack.Push(arr);

                while (stack.Count > 0)
                {
                    object obj = stack.Pop();
                    if (obj != null)
                    {
                        if (obj.GetType() == typeof(int))
                        {
                            list.Add((int)obj); // unboxing
                        }
                        else
                        {
                            if (obj.GetType() == typeof(object[]))
                            {
                                object[] nestedArr = (object[])obj;
                                foreach (object objNested in nestedArr)
                                {
                                    stack.Push(objNested);
                                }
                            }
                            else
                            {
                                if (obj.GetType() == typeof(int[]))
                                {
                                    list.AddRange((int[])obj);
                                }
                            }
                        }
                    }
                }
            }

            list.Reverse();
            return list.ToArray();
        }
    }
}
