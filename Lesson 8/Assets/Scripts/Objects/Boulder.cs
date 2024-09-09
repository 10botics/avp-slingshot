using System.Collections;
using System.Collections.Generic;
using Objects;
using UnityEngine;

[RequireComponent(typeof(SelfDestructController))]
public class Boulder : MonoBehaviour
{
    [SerializeField] private GameObject respawnObject;

    public delegate void BoulderDestroyedHandler();
    public static event BoulderDestroyedHandler BoulderDestroyed;

    private void OnDestroy()
    {
        BoulderDestroyed?.Invoke();
        Instantiate(respawnObject, Vector3.zero, Quaternion.identity, transform.parent);
    }
}
