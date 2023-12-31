﻿using System.Collections.Generic;

namespace Class.Selection
{
    public interface IUniqueSelectable<T> 
    {
        List<T> List { get; set; }
        int Index { get; set; }
        T Current { get; }
        void SetCurrent(T target);
        void SetCurrent(int index);
        T GetCurrent();
    }
}