using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    public float hitForce = 1000;
    private void OnTriggerEnter(Collider _other)
    {
        Ragdoll player = _other.gameObject.GetComponentInParent<Ragdoll>();
        if (player != null)
        {
            Rigidbody rb = player.gameObject.GetComponentInParent<Rigidbody>();

            player.ragdollOn = true;

            if (rb != null)
                rb.AddForce(Vector3.Normalize(rb.transform.position - transform.position)  * hitForce);
        }
    }
}
