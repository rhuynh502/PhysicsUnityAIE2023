using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumPositino : MonoBehaviour
{

    public Rigidbody cylinderRB;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        transform.SetPositionAndRotation(new Vector3(4, cylinderRB.position.y, 0), Quaternion.Euler(0, 0, 90));
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            rb.isKinematic = false;
        }
    }
}
