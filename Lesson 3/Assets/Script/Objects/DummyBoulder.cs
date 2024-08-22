using Input;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

namespace Objects
{
    public class DummyBoulder : MonoBehaviour, ISpatialPointerDownListener, ISpatialPointerMoveListener, ISpatialPointerUpListener
    {
        [SerializeField] private Rigidbody boulder;
        private Vector3 dragBeginPosition = Vector3.zero;
        
        public void OnSpatialPointerDown(SpatialPointerState state)
        {
            dragBeginPosition = transform.position;
        }

        public void OnSpatialPointerMove(SpatialPointerState state)
        {
            transform.position += state.deltaInteractionPosition;
        }

        public void OnSpatialPointerUp(SpatialPointerState state)
        {
            Instantiate(boulder, transform.position, Quaternion.identity, transform.parent)
                .AddForce((dragBeginPosition - transform.position) * 3.5f, ForceMode.Impulse);
            
            Destroy(gameObject);
        }
    }
}