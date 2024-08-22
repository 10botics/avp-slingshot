using UnityEngine.InputSystem.LowLevel;

namespace Input
{
    public interface ISpatialPointerDownListener
    {
        public void OnSpatialPointerDown(SpatialPointerState state);
    }
}