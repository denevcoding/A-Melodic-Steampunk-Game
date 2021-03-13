using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BeatPlatform : MonoBehaviour
{


    private enum BeatFrequency
    {
        Low, Middle, High
    }


    private SpriteRenderer spriteRenderer;
    private bool isAnimating = false;



    [SerializeField]
    private float animationDuration;
    [SerializeField]
    private BeatFrequency frequency;
    [SerializeField]
    private Color platformColor;



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }//closes Awake method

    private void Start()
    {

        switch (frequency)
        {
            case BeatFrequency.Low:
                BeatManager.singleton.OnBassBeat += DetectBeat;
                break;

            case BeatFrequency.Middle:
                BeatManager.singleton.OnMiddleBeat += DetectBeat;
                break;

            case BeatFrequency.High:
                BeatManager.singleton.OnHighBeat += DetectBeat;
                break;

        }

    }//closes method Start


    private void DetectBeat(float volume)
    {
        if (!isAnimating) StartCoroutine(IlluminatePlatform(platformColor));
    }//closes DetectBeat method

    private IEnumerator IlluminatePlatform(Color color)
    {
        float ElapsedTime = 0;
        float TotalTime = animationDuration / 2;
        isAnimating = true;

        //paints color
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(Color.white, color, (ElapsedTime / TotalTime));
            yield return null;
        }

        ElapsedTime = 0;
        TotalTime = animationDuration / 2;

        //removes color
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(color, Color.white, (ElapsedTime / TotalTime));
            yield return null;
        }


        isAnimating = false;
    }//closes IlluminatePlatform method

}//closes BeatPlatform class
