using System.Collections;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SelfDestructController))]
    public class Boulder : MonoBehaviour
    {
        private IEnumerator autoDestroy;
        
        private void Awake()
        {
            autoDestroy = AutoDestroy();
            StartCoroutine(autoDestroy);
        }

        private IEnumerator AutoDestroy()
        {
            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            StopCoroutine(autoDestroy);
        }
    }
}