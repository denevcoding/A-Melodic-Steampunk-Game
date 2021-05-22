using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCharacter : MonoBehaviour
{
    private AudioSource ninjaSource;

    // Start is called before the first frame update
    public void Start()
    {
        ninjaSource = GetComponent<AudioSource>();

        ninjaSource.volume = 1f;
        ninjaSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayDialog(AudioClip clip)
    {
        ninjaSource.clip = clip;
        ninjaSource.Play();
    }

    public void PlayDialog(AudioClip clip, float volumen)
    {
        ninjaSource.clip = clip;
        ninjaSource.volume = volumen;
        ninjaSource.Play();

    }


    public void PlaySFX(AudioClip clip)
    {
        ninjaSource.PlayOneShot(clip);
    }
    
}
