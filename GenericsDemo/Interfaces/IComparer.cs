using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsDemo
{
    public interface IComparer<in T>
    {
        int Compare(T lhs, T rhs);
    }
}
