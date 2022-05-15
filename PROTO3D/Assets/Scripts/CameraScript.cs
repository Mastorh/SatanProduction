using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject playerObject;
    public float zoomingStepsize;
    public float zoomingMax;
    public float zoomingMin;
    Vector3 positionOffset;

    private void Start()
    {
        
        positionOffset = new Vector3(transform.position.x - playerObject.transform.position.x, transform.position.y - playerObject.transform.position.y, transform.position.z - playerObject.transform.position.z);
    }
    void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel")!=0)
            {
            positionOffset.y = Mathf.Clamp(positionOffset.y - Input.GetAxisRaw("Mouse ScrollWheel") * 10 * zoomingStepsize, zoomingMin, zoomingMax);
            Debug.Log(Input.GetAxisRaw("Mouse ScrollWheel"));
            }
        transform.position = (playerObject.transform.position + positionOffset);
        transform.LookAt(playerObject.transform);
    }
}
