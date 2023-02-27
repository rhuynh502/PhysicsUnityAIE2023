using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public List<GameObject> objectPool;
    public GameObject ballPrefab;
    public float timer;
    public float hitForce = 100;
    public float shootTimer = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= shootTimer)
        {
            GameObject ball = ShootCannon();
            ball.SetActive(true);
            ball.transform.position = transform.position + transform.forward;
            ball.GetComponent<Rigidbody>().AddForce(transform.forward * hitForce);

            timer = 0;
        }


        timer += Time.deltaTime;
    }

    private GameObject ShootCannon()
    {
        if(objectPool.Count > 0)
        {
            for(int i = 0; i < objectPool.Count; i++)
            {
                if (!objectPool[i].activeInHierarchy)
                {
                    return objectPool[i];
                }
            }
        }

        return Instantiate(ballPrefab);
    }
}
