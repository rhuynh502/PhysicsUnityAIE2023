using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PhysicsObject : MonoBehaviour
{
    public Material awakeMat = null;
    public Material asleepMat = null;

    private Rigidbody rb = null;

    private bool isSleeping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.IsSleeping() && isSleeping && asleepMat != null)
        {
            isSleeping = false;
            GetComponent<MeshRenderer>().material = asleepMat;
        }

        if(!rb.IsSleeping() && !isSleeping && awakeMat != null)
        {
            isSleeping = true;
            GetComponent<MeshRenderer>().material = awakeMat;
        }
    }
}
