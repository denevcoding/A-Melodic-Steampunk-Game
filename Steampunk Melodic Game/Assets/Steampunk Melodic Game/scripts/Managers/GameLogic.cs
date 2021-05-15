using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class GameLogic : MyGenericSingleton<GameLogic>
{
    

    public Action<float> platformQueue;

    public Camera mainCamera;
    public CinemachineVirtualCamera cvc1;
    public CinemachineVirtualCamera cvc2;

    public GameObject playerPrefab;
    public Transform playerSpawn;
    public GameObject ninjaPlayer;

    public void ExecutePlatformJump(float force)
    {
        platformQueue?.Invoke(force);
    }//cloese ExecutePlatformJump
    


    public void Start()
    {
       ninjaPlayer = Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity);         
       ninjaPlayer.GetComponent<PlayerCharacter>().InitPlayer(playerSpawn.position);
        cvc1.gameObject.SetActive(false);
        cvc2.gameObject.SetActive(true);
        CameraHandler cvc2handler = cvc2.GetComponent<CameraHandler>();
        cvc2handler.AttachFollowTarget(GameLogic.singleton.ninjaPlayer.transform);
    }

}//closes GameLogic
