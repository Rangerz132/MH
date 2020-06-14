using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{

    private CinemachineFreeLook cinemachineCam;
    private float shakeTimer;

    public static CameraShake Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        cinemachineCam = GetComponent<CinemachineFreeLook>();
    }


    private void Update()
    {
        
        if (shakeTimer > 0f) {
            shakeTimer -= Time.deltaTime;

            if (shakeTimer <= 0f) {

                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineCam.GetComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;

            }
        }       
    }



    public void ShakeCamera( float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineCam.GetComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;


    }
}
