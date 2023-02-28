using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float lifetime;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        time = 0;
    }

    void Update()
    {
        if (time >= lifetime)
        {
            gameObject.SetActive(false);
            
        }

        time += Time.deltaTime;
    }

}
