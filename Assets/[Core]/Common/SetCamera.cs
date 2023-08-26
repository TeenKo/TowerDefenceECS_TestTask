using UnityEngine;

namespace _Core_.Common
{
    public class SetCamera : MonoBehaviour
    {
        [SerializeField] private bool rotateX;
        [SerializeField] private bool rotateY;
        [SerializeField] private bool rotateZ;
        [SerializeField] private Transform[] ignoreRotateElements;

        private Transform _mainCamera;

        private void Start()
        {
            if (TryGetComponent<Canvas>(out var component)) component.worldCamera = Camera.main;

            _mainCamera = Camera.main.transform;
            RotateUI();
        }

        private void Update()
        {
            if (!rotateX && !rotateY && !rotateZ) return;

            var cameraRotationEuler = _mainCamera.rotation.eulerAngles;
            var myRotation = transform.rotation.eulerAngles;

            if (rotateX) myRotation.x = cameraRotationEuler.x;
            if (rotateY) myRotation.y = cameraRotationEuler.y;
            if (rotateZ) myRotation.z = cameraRotationEuler.z;

            if (Quaternion.Euler(myRotation) != transform.rotation)
            {
                RotateUI();
            }
        }

        private void RotateUI()
        {
            var mainCameraRotation = _mainCamera.rotation.eulerAngles;

            foreach (var ignoreRotateElement in ignoreRotateElements)
            {
                ignoreRotateElement.localRotation = Quaternion.Euler(mainCameraRotation);
            }

            transform.rotation = Quaternion.Euler(mainCameraRotation);
        }
    }
}