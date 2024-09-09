using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SelfDestructController))]
    public class HitTarget : MonoBehaviour
    {
        public delegate void DestroyHandler();
        public static event DestroyHandler Destroyed;

        private void OnDestroy()
        {
            Destroyed?.Invoke();
        }
    }
}