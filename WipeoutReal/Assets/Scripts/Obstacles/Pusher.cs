using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    public float duration = 0.5f;
    private bool goingForward = true;
    private bool finishRoutine = true;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(finishRoutine)
        {
            finishRoutine = false;
            StartCoroutine(LerpPos());
        }
    }

    // Lerps pos of pusher
    IEnumerator LerpPos()
    {
        float time = 0;
        Vector3 startPos = transform.position;
        Vector3 endPos = transform.position + 4f * (goingForward ? transform.forward : -transform.forward);

        while (time < duration)
        {
            rb.MovePosition(Vector3.Lerp(startPos, endPos, time / duration));
            time += Time.deltaTime;
            yield return null;
        }
        startPos = endPos;
        finishRoutine = true;
        goingForward = !goingForward;
    }
}
