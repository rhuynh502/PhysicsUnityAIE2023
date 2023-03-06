using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    // Attaches the player to the object
    private void OnTriggerEnter(Collider _other)
    {
        _other.transform.rotation = transform.rotation;
        _other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider _other)
    {
        _other.transform.parent = null;
        _other.transform.rotation = Quaternion.Euler(0, _other.transform.rotation.y, 0);
    }
}
