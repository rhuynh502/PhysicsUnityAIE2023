using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSelector : MonoBehaviour
{
    [SerializeField] List<Rigidbody> doors;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, doors.Count);
        doors[rand].isKinematic = false;
        doors[rand].useGravity = true;
        doors[rand].mass = Random.Range(10, 2001);
    }

}
