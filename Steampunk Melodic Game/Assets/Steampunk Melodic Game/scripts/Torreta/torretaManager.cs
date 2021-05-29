using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torretaManager : MonoBehaviour
{
    public GameObject apuntador;
    public GameObject proyectilPrefav;
    public bool activated;
    public float fuerza;

    [SerializeField]
    private LayerMask layerDetection;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        SphereCast();
        
    }
    
    public void SphereCast()
    {       
        Vector2 point = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, 5f, layerDetection);

        if (colliders.Length > 0)
        {
            AimToPlayer(colliders[0].transform);
            if (activated == false)
            {
                Shoot();
                activated = true;
            }
           
            Debug.Log(colliders.Length);
        }
        else
        {
            activated = false;
            CancelInvoke();
            Debug.Log("No near players");
        }
        
    }

    void AimToPlayer(Transform playerTrans)
    {
        Vector3 torretToPLayer = playerTrans.position - apuntador.transform.position;
        float angle = Mathf.Atan2(torretToPLayer.y, torretToPLayer.x) * Mathf.Rad2Deg;
        apuntador.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    void Shoot()
    {
        GameObject proyectil = Instantiate(proyectilPrefav);
        proyectil.transform.position = apuntador.transform.position;
        proyectil.GetComponent<Rigidbody2D>().AddForce(apuntador.transform.right * fuerza,ForceMode2D.Impulse);
        Invoke("Shoot", 2f);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, 5);
    }
}
