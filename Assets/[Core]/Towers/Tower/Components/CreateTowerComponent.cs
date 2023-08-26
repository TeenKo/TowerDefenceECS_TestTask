using Entitas;
using UnityEngine;

namespace _Core_.Towers.Tower.Components
{
    [Game]
    public class CreateTowerComponent : IComponent
    {
        public Vector3 position;
        public int pointCreationIndex;
    }
}