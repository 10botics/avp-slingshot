using Unity.VisualScripting;
using UnityEngine;

namespace Objects
{
    public class SelfDestructController : MonoBehaviour
    {
        private void Update()
        {
            if (gameObject.IsDestroyed() || !(transform.position.y < -3f)) return;
            
            Destroy(gameObject);
        }
    }
}