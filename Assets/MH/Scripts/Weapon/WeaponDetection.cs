﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy") {
           // CameraShake.Instance.ShakeCamera(3f, 1f);
            Debug.Log("ouch");
        }
    }
}
