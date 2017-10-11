using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI<T> : MonoBehaviour where T : BaseUI<T>
{
    private static T uIInstance = null;
    public static bool m_bisInit = false;

    public static T UIInstance
    {
        get
        {
            if (m_bisInit)
            {
                return uIInstance;
            }
            else return null;
        }

    }
    void Awake()
    {
        m_bisInit = true;
        uIInstance = this as T;
        //   this.gameObject.name = this.GetType().ToString();
        //  this.gameObject.SetActive(false);
    }

}
