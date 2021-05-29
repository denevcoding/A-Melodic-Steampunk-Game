using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torretaManager : MonoBehaviour
{
    public GameObject apuntador;
    public GameObject proyectilPrefav;
    public bool cerca;
    public float fuerza;
    
    // Start is called before the first frame update
    void Start()
    {
        if (cerca == true)
        {
            Invoke("Shoot", 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SphereCast();
        
    }
    
    public void SphereCast()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(apuntador.transform.position,10f,8,10f,10f);
        
        
            Debug.Log(colliders.Length);
        
        
    }
    void OnDrawGizmos() { 
        Gizmos.color = Color.yellow; Gizmos.DrawSphere(apuntador.transform.position, 5);
    }


    void Shoot()
    {
        GameObject proyectil = Instantiate(proyectilPrefav);
        proyectil.transform.position = apuntador.transform.position;
        proyectil.GetComponent<Rigidbody2D>().AddForce(apuntador.transform.right * fuerza,ForceMode2D.Impulse);
        Invoke("Shoot", 2f);
    }
}
