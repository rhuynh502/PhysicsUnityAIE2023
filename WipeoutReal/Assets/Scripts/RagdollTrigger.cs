using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider _other)
    {
        Ragdoll ragDoll = _other.GetComponentInParent<Ragdoll>();
        if(ragDoll != null)
        {
            ragDoll.ragdollOn = true;
        }
    }
}
