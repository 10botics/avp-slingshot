using Input;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

namespace Objects
{
    public class DummyBoulder : MonoBehaviour, ISpatialPointerDownListener, ISpatialPointerMoveListener, ISpatialPointerUpListener
    {
        [SerializeField] private Transform shade;
        [SerializeField] private Rigidbody boulder;

        private Transform shadeInstance;
        private Vector3 dragBeginPosition = Vector3.zero;
        
        public void OnSpatialPointerDown(SpatialPointerState state)
        {
            dragBeginPosition = state.inputDevicePosition;
            shadeInstance = Instantiate(shade, state.inputDevicePosition, Quaternion.identity, transform);
        }

        public void OnSpatialPointerMove(SpatialPointerState state)
        {
            transform.position = state.inputDevicePosition;
            shadeInstance.position = dragBeginPosition;
        }

        public void OnSpatialPointerUp(SpatialPointerState state)
        {
            Instantiate(boulder, transform.position, Quaternion.identity, transform.parent)
                .AddForce((dragBeginPosition - transform.position) * 3.5f, ForceMode.Impulse);
            
            Destroy(gameObject);
        }
    }
}