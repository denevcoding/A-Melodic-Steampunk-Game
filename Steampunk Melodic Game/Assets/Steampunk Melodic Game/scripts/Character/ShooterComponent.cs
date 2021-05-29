using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterComponent : MonoBehaviour
{
    public GameObject apuntador;
    public GameObject knaiPrefab;

    private float mouseX, mouseY;


    // Start is called before the first frame update
    void Start()
    {
        mouseX = 0f;
        mouseY = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(apuntador.transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        apuntador.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject knai = Instantiate(knaiPrefab);           
            knai.transform.position = apuntador.transform.position;
            knai.transform.rotation = Quaternion.AngleAxis(angle + 270, Vector3.forward);
            knai.GetComponent<Rigidbody2D>().AddForce(apuntador.transform.right * 20f, ForceMode2D.Impulse);

            Debug.Log("Disparando");

        }

        Invoke("Shoot", 2f);
    }

    public void Shoot()
    {

    }
}
