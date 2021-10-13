using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonInstance<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = (T)FindObjectOfType(typeof(T));
            OnInitialize();
        }

        else
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnInitialize() { }

    public static T GetInstance()
    {
        return instance;
    }
}