using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClassPriogram : MonoBehaviour
{// scope

    //int = ; // solo numeros enteros 
    //    float = // pueden tener decimales ;
    //    double;
    //    bool = false true;
    public int numero1;
    public int numero2;



    // Start is called before the first frame update
    void Start()
    {
        suma(numero1, numero2);       
    }

    // Update is called once per frame
    void Update()
    {

    }


    void suma(int num1, int num2)
    {
        Debug.Log(num1 + num2);
    }

}
