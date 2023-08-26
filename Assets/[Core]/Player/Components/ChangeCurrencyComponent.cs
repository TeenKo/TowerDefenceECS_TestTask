using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _Core_.Player.Components
{
    [Game]
    public class ChangeCurrencyComponent : IComponent
    {
        public int currency;
        public int creationIndex;
    }
}