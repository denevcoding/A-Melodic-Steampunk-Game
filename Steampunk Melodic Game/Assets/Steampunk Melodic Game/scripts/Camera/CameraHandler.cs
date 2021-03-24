using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    CinemachineVirtualCamera levelCamera;
    CinemachineBasicMultiChannelPerlin CBMCP;

    [Header("Move Settings")]
    public float verticalSeped;

    [Header("Shake Settings")]
    public Transform camera;
    private float shakeTimer = 0;
    private float shakeTimerTotal;
    private float startingIntensity;


    private void Awake()
    {
        levelCamera = GetComponent<CinemachineVirtualCamera>();
    }


    // Start is called before the first frame update
    void Start()
    {
        //CameraShake(1.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();

        if (shakeTimer > 0)
        {
            CameraShaking();
        }
    }


    public void MoveCamera()
    {
        Vector3 cameraPosition = this.transform.position;
        cameraPosition.y += verticalSeped * Time.deltaTime;
        transform.position = cameraPosition;
    }


    public void CameraShake(float intensity, float duration)
    {
        CinemachineBasicMultiChannelPerlin CBMCP = levelCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        CBMCP.m_AmplitudeGain = intensity;
        shakeTimer = duration;
        shakeTimerTotal = duration;
        startingIntensity = intensity;
    }

    public void CameraShaking()
    {
        shakeTimer -= Time.deltaTime;
        if (shakeTimer >= 0f)
        {
            CinemachineBasicMultiChannelPerlin CBMCP = levelCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            CBMCP.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer / shakeTimerTotal));
        }
    }

}
