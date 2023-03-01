using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float travelTime = 2;
    public Vector3 upPos;
    public Vector3 downPos;

    private Rigidbody rb;
    public bool moving { get; private set; }
    public bool lowerFloor = true;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player") && !moving)
        {
            StartCoroutine(UseLift());
        }
    }
    private void OnTriggerExit(Collider _other)
    {
        if (_other.CompareTag("Player") && !moving) 
        {
            StartCoroutine(UseLift());
        }
    }

    public IEnumerator UseLift()
    {
        float time = 0;

        Vector3 startPos;
        Vector3 endPos;
        // deterine start and end positions when entering elevator
        if(lowerFloor)
        {
            startPos = downPos;
            endPos = upPos;
        }
        else
        {
            startPos = upPos;
            endPos = downPos;
        }

        moving = !moving;
        lowerFloor = !lowerFloor;
        // lerp the position for a going up and down
        while (time < travelTime)
        {
            rb.MovePosition(Vector3.Lerp(startPos, endPos, time / travelTime));
            time += Time.deltaTime;
            yield return null;
        }
        moving = !moving;
    }
}
