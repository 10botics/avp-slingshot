using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

namespace Input
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private InputActionReference touchState;
        [SerializeField] private InputActionReference touchPhase;
        
        private SpatialPointerState TouchState => touchState.action.ReadValue<SpatialPointerState>();
        private TouchPhase TouchPhase => touchPhase.action.ReadValue<TouchPhase>();
        
        private void Awake()
        {
            EnhancedTouchSupport.Enable();
            touchState.action.Enable();
            touchPhase.action.Enable();
        }

        private void Update()
        {
            switch (TouchPhase)
            {
                case TouchPhase.Began:
                    OnSpatialPointerDown();
                    break;
                case TouchPhase.Moved:
                    OnSpatialPointerMove();
                    break;
                case TouchPhase.Ended:
                    OnSpatialPointerUp();
                    break;
            }
        }

        private void OnSpatialPointerDown()
        {
            TouchState.targetObject?.GetComponent<ISpatialPointerDownListener>()?.OnSpatialPointerDown(TouchState);
        }
        
        private void OnSpatialPointerMove()
        {
            TouchState.targetObject?.GetComponent<ISpatialPointerMoveListener>()?.OnSpatialPointerMove(TouchState);
        }
        
        private void OnSpatialPointerUp()
        {
            TouchState.targetObject?.GetComponent<ISpatialPointerUpListener>()?.OnSpatialPointerUp(TouchState);
        }

        private void OnDestroy()
        {
            touchState.action.Disable();
            touchPhase.action.Disable();
            EnhancedTouchSupport.Disable();
        }
    }
}