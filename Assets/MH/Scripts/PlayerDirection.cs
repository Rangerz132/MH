using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{

    public float turnSpeed = 15f;
    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yAxisCamera = mainCam.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yAxisCamera, 0), turnSpeed * Time.deltaTime);
    }
}
