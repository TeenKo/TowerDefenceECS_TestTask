using UnityEngine;

namespace _Core_.DetectionArea
{
    public sealed class DetectionArea : MonoBehaviour
    {
        [SerializeField] private Vector3 size;

        public Vector3 Center => transform.position;
        public Vector3 Size => size;

        public Bounds Bounds => new Bounds(Center, size);

#if UNITY_EDITOR
        [SerializeField] private Color frameColor = new Color(0f, 1f, 0f, 1f);
        [SerializeField] private Color fillColor = new Color(0f, 1f, 0f, 0.2f);
        private void OnDrawGizmos()
        {
            Gizmos.color = fillColor;
            Gizmos.DrawCube(Center, Size);
            Gizmos.color = frameColor;
            Gizmos.DrawWireCube(Center, Size);
        }
#endif
    }
}