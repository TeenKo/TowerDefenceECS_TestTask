using System;
using UnityEngine;

namespace _Core_.NavMesh.Interfaces
{
    public interface IPathfinderAgent
    {
        public void MoveToDestination(Transform target, Action onComplete);
        public void MoveToDestination(Transform target);
        public void MoveToDestination(Vector3 position);
        public void MoveToDestination(Vector3 position, Action onComplete);

        public void StopMovement();
        public void OffAgent();
        public void OnAgent();
        public void ResetAgent();
        public void ChangeSpeed(float value);
    }
}
