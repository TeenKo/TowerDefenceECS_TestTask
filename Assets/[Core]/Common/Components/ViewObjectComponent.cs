using _Core_.Common.Interfaces;
using Entitas;

namespace _Core_.Common.Components
{
    [Game]
    public sealed class ViewObjectComponent : IComponent
    {
        public IViewObject value;
    }
}