using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SteampunkComponent : MonoBehaviour
{
    public PlayerCharacter playerCharacter;

    // Start is called before the first frame update
    public virtual void Start(){ }

    // Update is called once per frame
    public virtual void Update() {  }

    public virtual void StartAction() { }



    public virtual bool CheckPreconditions() {

        if (playerCharacter.GetPlayerState() == CharacterStates.dead)
            return false;

        if (playerCharacter.GetPlayerState() == CharacterStates.stunned)
            return false;

        return true;
    
    }
}
