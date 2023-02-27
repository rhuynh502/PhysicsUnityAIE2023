using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    private void OnTriggerEnter(Collider _other)
    {
        if(_other.CompareTag("CannonBall"))
            _other.gameObject.SetActive(false);
    }
}
