using UnityEngine.InputSystem.LowLevel;

namespace Input
{
    public interface ISpatialPointerUpListener
    {
        void OnSpatialPointerUp(SpatialPointerState state);
    }
}