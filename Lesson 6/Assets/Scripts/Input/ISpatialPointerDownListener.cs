using UnityEngine.InputSystem.LowLevel;

namespace Input
{
    public interface ISpatialPointerDownListener
    {
        void OnSpatialPointerDown(SpatialPointerState state);
    }
}