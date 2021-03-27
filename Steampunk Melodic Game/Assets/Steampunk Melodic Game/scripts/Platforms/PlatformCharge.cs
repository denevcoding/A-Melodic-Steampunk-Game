using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCharge : MonoBehaviour
{
    [SerializeField]
    private float force;
    private float forceProgress;



    private void Update()
    {
        forceProgress += 1 * Time.deltaTime;


        if (forceProgress >= 10f)
        {
            forceProgress = 0;
            FreeCharge();
        }

    }//closes Update Methods



    private void FreeCharge()
    {
        GameLogic.singleton.ExecutePlatformJump(force);
    }//closes FreeCharge





}//closes Platform Charge
