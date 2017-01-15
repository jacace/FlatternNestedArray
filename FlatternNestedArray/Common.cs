using System;
using System.Collections.Generic;

/// <summary>
/// Namespace to store the common clases and base interface to flattern an array using OOP
/// </summary>
namespace FlatternNestedArray
{
    /// <summary>
    /// Contract to return an array of integers
    /// </summary>
    public interface IArrayElement
    {
        int[] GetElements();
    }

    /// <summary>
    /// Class to store a simple integer
    /// </summary>
    public class IntElement : IArrayElement
    {
        private int num;
        public IntElement(int num)
        {
            this.num = num;
        }

        public int[] GetElements()
        {
            return new int[] { this.num };
        }
    }

    /// <summary>
    /// Class to store an array of integers
    /// </summary>
    public class ArrIntElement : IArrayElement
    {
        private int[] nums;
        public ArrIntElement(int[] nums)
        {
            this.nums = nums;
        }

        public int[] GetElements()
        {
            return this.nums;
        }
    }

    /// <summary>
    /// Class to store an array of "unknowns"
    /// Each unkown is either an integer, an array of integers of another unknown
    /// </summary>
    public class ArrElement : IArrayElement
    {
        private IArrayElement[] arrNums = null;

        public ArrElement(params IArrayElement[] arrNums)
        {
            this.arrNums = arrNums;
        }

        /// <summary>
        /// Function to check each variable of "unknown" data type
        /// </summary>
        /// <returns>Array of integers</returns>
        /// <remarks>
        /// This function uses a stack to keep track of the elements of unknown data type
        /// </remarks>
        public int[] GetElements()
        {
            if (this.arrNums == null) return null;

            Stack<IArrayElement> stack = new Stack<IArrayElement>();
            foreach (IArrayElement objElement in this.arrNums) stack.Push(objElement);
            List<int> numList = new List<int>();

            while (stack.Count > 0)
            {
                IArrayElement objElement = stack.Pop();
                Type oElementType = objElement.GetType();
                if (oElementType == typeof(ArrElement))
                {
                    foreach (IArrayElement nestedElement in ((ArrElement)objElement).arrNums)
                    {
                        stack.Push(nestedElement);
                    }
                }
                else
                {
                    numList.AddRange(objElement.GetElements());
                }
            }

            numList.Reverse();
            return numList.ToArray();
        }
    }

    /// <summary>
    /// Class to expose the functionality
    /// </summary>
    public class NestedArray
    {
        public static int[] Flattern(IArrayElement[] nestedArr)
        {
            List<int> flatternArr = new List<int>();
            if (nestedArr != null)
            {
                foreach (IArrayElement tmpElement in nestedArr)
                {
                    flatternArr.AddRange(tmpElement.GetElements());
                }
            }

            return flatternArr.ToArray();
        }
    }

}
