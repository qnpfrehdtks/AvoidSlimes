using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletFactory : MonoBehaviour {

    public BOSS m_Bosstype;
    protected Vector3 m_BaseScale;

     public abstract List<GameObject> createBullet();
     public abstract void Init(BOSS bossType);

    public List<GameObject> makeBullet(BOSS bossType)
    {
        List<GameObject> bullet = createBullet();

        return bullet;
    }







}
