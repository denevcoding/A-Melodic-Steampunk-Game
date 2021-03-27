using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BeatPlatform : MonoBehaviour
{

    private List<GameObject> objectsTouching = new List<GameObject>();

    private enum BeatFrequency
    {
        Low, Middle, High
    }


    private SpriteRenderer spriteRenderer;
    private bool isAnimating = false;
    private int bands;
    private bool pushTrigger;

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
        if (!isAnimating)
        {
            StartCoroutine(IlluminatePlatform(platformColor));
        }


    }//closes DetectBeat method

    private IEnumerator IlluminatePlatform(Color color)
    {
        float ElapsedTime = 0;
        float TotalTime = animationDuration / 2;
        isAnimating = true;
        pushTrigger = true;

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

        pushTrigger = false;
        isAnimating = false;
    }//closes IlluminatePlatform method

    //private void TransferForce()
    //{
    //    foreach (GameObject obj in objectsTouching.ToList())
    //    {
    //        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
    //        if (rb == null) continue;
    //        PushObject(rb, );
    //    }
    //}//closes TransferForce method

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (!objectsTouching.Contains(collision.gameObject)) objectsTouching.Add(collision.gameObject);
    //}//closes OnCollisionEnter2D event

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (objectsTouching.Contains(collision.gameObject)) objectsTouching.Remove(collision.gameObject);
    //}//closes OnCollisionExit2D event

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (pushTrigger)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb == null) return;
            PushObject(rb, collision.contacts[0].normal, 1600);
        }
    }//closes OnCollisionExit2D event


    private void PushObject(Rigidbody2D objectToPush, Vector2 forceDirection, float force)
    {
        forceDirection.y *= -1;

        objectToPush.AddForce(forceDirection * force);
    }//closes OnCollisionExit2D event

}//closes BeatPlatform class
