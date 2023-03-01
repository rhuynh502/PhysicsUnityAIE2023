using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 2;
    public float distFromCamera = 5;
    public float currentDistance;
    public float relaxSpeed = 10;
    public float zoomSpeed = 10;
    public float minZoom = 2;
    public float maxZoom = 10;
    public float heightOffset = 1.5f;

    public GameObject cameraTarget;
    // Start is called before the first frame update
    void Start()
    {
        currentDistance = distFromCamera;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angles = transform.eulerAngles;
        float dx = Input.GetAxis("Mouse Y");
        float dy = Input.GetAxis("Mouse X");

        angles.x = Mathf.Clamp(angles.x - dx * cameraSpeed * Time.deltaTime, 0, 70);

        angles.y += dy * cameraSpeed * Time.deltaTime;
        transform.eulerAngles = angles;

        distFromCamera = Mathf.Clamp(distFromCamera - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, minZoom, maxZoom);

        //RaycastHit hit;
        /*if (Physics.Raycast(GetTargetPosition() + -transform.forward, -transform.forward, out hit, distFromCamera))
            currentDistance = hit.distance;
        else*/
        currentDistance = Mathf.MoveTowards(currentDistance, distFromCamera, Time.deltaTime * relaxSpeed);

        transform.position = GetTargetPosition() - currentDistance * transform.forward;
    }


    private Vector3 GetTargetPosition()
    {
        return cameraTarget.transform.position + heightOffset * Vector3.up;
    }
}
