using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartCutscene : MonoBehaviour
{
    public Camera mainCamera;
    public CinemachineVirtualCamera cvc1;
    public CinemachineVirtualCamera cvc2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");
        if (collision.tag == "player")
        {
           
        }
    }
    public void Start()
    {
        
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("stay");
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        cvc1.gameObject.SetActive(false);
        cvc2.gameObject.SetActive(true);
        CameraHandler cvc2handler = cvc2.GetComponent<CameraHandler>();
        cvc2handler.AttachFollowTarget(GameLogic.singleton.ninjaPlayer.transform);
    }
}
