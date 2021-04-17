using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameLogic : MyGenericSingleton<GameLogic>
{

    public Action<float> platformQueue;


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
    }

}//closes GameLogic
