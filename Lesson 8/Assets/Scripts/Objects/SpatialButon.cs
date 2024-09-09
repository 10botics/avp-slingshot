using Input;
using Unity.PolySpatial;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.LowLevel;

namespace Objects
{
    [RequireComponent(typeof(VisionOSHoverEffect))]
    public class SpatialButton : MonoBehaviour, ISpatialPointerUpListener
    {
        [SerializeField] private UnityEvent onClick;

        public void OnSpatialPointerUp(SpatialPointerState state)
        {
            onClick?.Invoke();   
        }
    }
}