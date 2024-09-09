using System.Collections;
using System.Collections.Generic;
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
                    TouchState.targetObject?.GetComponent<ISpatialPointerDownListener>()?.OnSpatialPointerDown(TouchState);
                    break;
                case TouchPhase.Moved:
                    TouchState.targetObject?.GetComponent<ISpatialPointerMoveListener>()?.OnSpatialPointerMove(TouchState);
                    break;
                case TouchPhase.Ended:
                    TouchState.targetObject?.GetComponent<ISpatialPointerUpListener>()?.OnSpatialPointerUp(TouchState);
                    break;
            }
        }

        private void OnDestroy()
        {
            EnhancedTouchSupport.Disable();
            touchState.action.Disable();
            touchPhase.action.Disable();
        }
    }
}
