using System.Collections.Generic;

namespace _Core_.States
{
    public enum StateObjectType
    {
        Enemy,
        Player,
        Tower
    }
    
    public interface IGameContextState
    {
        List<StateObjectType> SetSateObjectType();
    }
}
