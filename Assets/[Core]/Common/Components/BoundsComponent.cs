using Entitas;
using UnityEngine;

namespace _Core_.Common.Components
{
    [Game]
    public sealed class BoundsComponent : IComponent
    {
        public Bounds value;
    }
}