using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if(_collision.gameObject.CompareTag("Player") && rb.velocity.magnitude > 10)
        {
            float force = Vector3.Magnitude(rb.velocity);
            Vector3 dir = Vector3.Normalize(rb.velocity);

            Rigidbody player = _collision.gameObject.GetComponentInChildren<Rigidbody>();
            player.AddForce(dir * force * rb.mass);
        }
    }
}
