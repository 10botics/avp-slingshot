using UnityEngine;

namespace Objects
{
    public class SelfDestructController : MonoBehaviour
    {
        private void Update()
        {
            if (transform.position.y < -3)
            {
                Destroy(gameObject);
            }
        }
    }
}
