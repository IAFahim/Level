﻿using Class.GameSystem.Goal;

namespace Class.GameSystem.Mission
{
    public interface IMission
    {
        
        bool IsComplete { get; }
        void Check();
    }
}