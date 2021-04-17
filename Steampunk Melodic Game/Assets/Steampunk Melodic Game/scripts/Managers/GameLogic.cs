using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameLogic : MyGenericSingleton<GameLogic>
{

    public Action<float> platformQueue;


    public GameObject playerPrefab;
    public Transform playerSpawn;


    public void ExecutePlatformJump(float force)
    {
        platformQueue?.Invoke(force);
    }//cloese ExecutePlatformJump
    


    public void Start()
    {
       GameObject playerChar = Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity);         
       playerChar.GetComponent<PlayerCharacter>().InitPlayer(playerSpawn.position);  
    }

}//closes GameLogic
