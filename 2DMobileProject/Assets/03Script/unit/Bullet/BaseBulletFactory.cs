using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1BulletFactory : BulletFactory {

  //  GameObject Bullet;
    GameObject NeedleBullet;
    GameObject BigBullet;



    public override void Init(BOSS bossType)
    {
        m_Bosstype = bossType;
     //   Bullet = GameObject.Find("Bullet");
      //  NeedleBullet = GameObject.Find("Needle");
    }


    public override List<GameObject> createBullet()
    {
       GameObject Bullet = GameObject.Find("Bullet");
       GameObject NeedleBullet = GameObject.Find("Needle");
   //    GameObject TrailBullet = GameObject.Find("Trail");

        List<GameObject> bossBulletArray = new List<GameObject>();

        GameObject obj = Instantiate(Bullet, new Vector2(50, 50), Quaternion.identity);
      //  obj.GetComponent<Bullet>().Init( );
        obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
      
        bossBulletArray.Add(obj);

        obj = Instantiate(Bullet, new Vector2(50,50), Quaternion.identity);
       // obj.GetComponent<Bullet>().Init(BULLET_TYPE.BASE2, BULLET_IMAGE.BASE_BULLET1);
        obj.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        bossBulletArray.Add(obj);

        obj = Instantiate(NeedleBullet, new Vector2(50, 50), Quaternion.identity);
      //  obj.GetComponent<Bullet>().Init(BULLET_TYPE.NEEDLE, BULLET_IMAGE.NEEDLE_BULLET1);
        obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

        bossBulletArray.Add(obj);

        return bossBulletArray;


    }



}
