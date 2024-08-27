using UnityEngine.InputSystem.LowLevel;

namespace Input
{
    public interface ISpatialPointerMoveListener {
        void OnSpatialPointerMove(SpatialPointerState state);
    }
}