using Entitas;
using UnityEngine;

namespace _Core_.Common.Components
{
    [Game]
    public sealed class TransformComponent : IComponent
    {
        public Transform value;
    }
}