using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoParaTuto_Corutines : MonoBehaviour
{

    [HideInInspector]
    public int publica = 10;

    [SerializeField]
    private int privada = 10;

    SpriteRenderer renderer;
    Rigidbody2D physics;

    private float segundos;

    private bool finishRainbow;

    private enum Estado
    {
        muerto = 4,
        cansado = 72,
        stuneado = 123,
        herido = 23
    }

    private Estado estado;


    private void Awake()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        physics = gameObject.GetComponent<Rigidbody2D>();
        GameLogic.singleton.platformQueue += ReceiveForce;
    }//closes Awake 


    void Start()
    {

        finishRainbow = true;
        StartCoroutine(AnimateKirby());
    }//closes Start 



    #region Coroutine

    private void Update()
    {

        if (Input.GetKeyDown("space") && finishRainbow)
        {
            finishRainbow = false;
            StopCoroutine(AnimateKirby());
        }
        else if (Input.GetKeyDown("space") && !finishRainbow)
        {
            finishRainbow = true;
            StartCoroutine(AnimateKirby());
        }

    }//closes update 


    IEnumerator AnimateKirby()
    {

        while (finishRainbow)
        {

            renderer.color = Color.red;
            yield return new WaitForSecondsRealtime(0.1f);
            renderer.color = Color.green;
            yield return new WaitForSecondsRealtime(0.1f);
            renderer.color = Color.blue;
            yield return new WaitForSecondsRealtime(0.1f);
        }


    }//closes AnimateKirby coroutine
    #endregion


    #region Evento subscrito a Gamelogic

    public void ReceiveForce(float verticalForce)
    {
        Vector2 force = new Vector2(0, verticalForce);
        physics.AddForce(force);
    }

    #endregion



}//close TutoparaTutoClass
