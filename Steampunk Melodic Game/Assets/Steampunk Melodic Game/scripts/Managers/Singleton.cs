using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGenericSingleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public bool persistant;
    public static T singleton
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject gameObj = new GameObject();
                    gameObj.name = typeof(T).Name;
                    instance = gameObj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            if (persistant)
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
