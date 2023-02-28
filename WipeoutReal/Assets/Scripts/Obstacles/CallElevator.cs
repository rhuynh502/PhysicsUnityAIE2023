using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallElevator : MonoBehaviour
{
    public bool topFloor;
    [SerializeField] private Elevator elevator;
    // Start is called before the first frame update

    public void UseElevator()
    {
        if(!elevator.moving && topFloor == elevator.lowerFloor)
        {
            StartCoroutine(elevator.UseLift());
        }
    }
}
