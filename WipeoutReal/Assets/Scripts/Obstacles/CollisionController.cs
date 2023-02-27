using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public float hitForce = 300;
    void OnCollisionEnter(Collision _collision)
    {
        Ragdoll player = _collision.gameObject.GetComponentInParent<Ragdoll>();
        if(player != null)
        {
            Rigidbody rb = player.gameObject.GetComponentInParent<Rigidbody>();

            if(rb!= null)
                rb.AddForce(transform.forward * hitForce);
            player.ragdollOn = true;
        }
    }
}
