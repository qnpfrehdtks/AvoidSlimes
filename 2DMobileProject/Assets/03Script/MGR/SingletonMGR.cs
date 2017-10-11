using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleMGR<T> : MonoBehaviour where T : SingleMGR<T>
{

    private static T instance = null;
    protected static bool isInitiated = false;


    protected abstract bool Init();

    public static T Instance
    {
        get
        {
            if (isInitiated)
            {
                return instance;
            }
            return null;
        }
    }




    public static bool createManager()
    {
        if (isInitiated)
        {
            return false;
        }
        else
        {
            instance = new GameObject("[Manager]" + typeof(T).ToString(), typeof(T)).GetComponent<T>();

            isInitiated = true;
            instance.Init();
            DontDestroyOnLoad(instance.gameObject);
        }
        return true;

    }




}
