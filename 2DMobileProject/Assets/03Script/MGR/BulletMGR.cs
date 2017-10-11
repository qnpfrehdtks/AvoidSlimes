using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//===========================================================================================================
//       이 클래스는 탄막 오브젝트 풀링 함수임. 탄막만을 관리함.
//===========================================================================================================
public class BulletMGR : SingleMGR<BulletMGR> {

    AudioClip m_cChange;
    PatternState m_cItemPattern;
    PatternState m_cHealPattern;

    Sprite m_sGold;
    //BulletFactory m_BulletFactory;
    protected GameObject m_BaseBullet;

    //저장되어 있는 불릿들
   protected Queue<Bullet> m_CurBulletList;
    //밖에 놀고 있는 불릿들
   protected Queue<Bullet> m_FiredBulletList;

    protected override bool Init()
    {
        m_cItemPattern = new PatternState();
        m_cItemPattern.setPattern(false, PATTERN_NAME.AIMING_DIRECT, 0.3f, 0.3f, 0.0f, 0.0f, 0.0f, 0.0f,10.0f, 0.5f, 0.0f, 1, 0, 0, 0, 0, 0, BULLET_TYPE.STOP_AND_PLAY, BULLET_IMAGE.GOLD,1.0f, true,0.0f, 0.5f);

        m_cHealPattern = new PatternState();
        m_cHealPattern.setPattern(false, PATTERN_NAME.AIMING_DIRECT, 0.3f, 0.3f, 0.0f, 0.0f, 0.0f, 0.0f, 10.0f, 0.5f, 0.0f, 1, 0, 0, 0, 0, 0, BULLET_TYPE.STOP_AND_PLAY, BULLET_IMAGE.HEAL, 1.0f, true, 0.0f, 0.5f);

        m_BaseBullet = GameObject.Find("Bullet");
        m_CurBulletList = new Queue<Bullet>();
        m_FiredBulletList = new Queue<Bullet>();
        m_cChange = SoundMGR.Instance.GetAudioClip(SOUND.SOUND_CHANGE);


       

        MakeBullet();

        return true;
    }

    protected virtual void MakeBullet()
    {
     // List<GameObject> newList = new List<GameObject>();

       for (int j = 0; j < 2000; j++)
        {
          CreateandPushBullet(m_BaseBullet);
        }
     }


    public Bullet PopBullet()
    {
        Bullet bullet;

        if (m_CurBulletList.Count <= 1)
        {
            bullet = CreateandPushBullet(m_BaseBullet);
        }
        else
           bullet = m_CurBulletList.Dequeue();
 
        bullet.gameObject.SetActive(true);
      //  m_FiredBulletList.Enqueue(bullet);

        return bullet;
    }


    public bool PushBullet(Bullet bullet)
    {
      //  m_FiredBulletList.(bullet);
        m_CurBulletList.Enqueue(bullet);

      //  bullet.gameObject.layer = 8;
        bullet.gameObject.SetActive(false);
       
        return true;
    }

    protected virtual Bullet CreateandPushBullet(GameObject bullet)
    {
        GameObject obj = Instantiate(bullet, Vector3.zero, Quaternion.identity) as GameObject;
        obj.transform.parent = gameObject.transform;
        Bullet newBullet = obj.AddComponent<Bullet>();

        newBullet.Init();

        obj.SetActive(false);

        m_CurBulletList.Enqueue(newBullet);

        return newBullet;

    }

    public void AllReleaseBullet()
    {
        Bullet[] bullets =  GetComponentsInChildren<Bullet>();

        for(int i=0; i< bullets.Length; i++)
        {
            if(bullets[i].gameObject.activeSelf)
               PushBullet(bullets[i]);
        }

    }


    public void AllBulletPatternStop()
    {
        Bullet[] bullets = GetComponentsInChildren<Bullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            if (bullets[i].gameObject.activeSelf)
                bullets[i].PatternAllClear();
        }
    }


    //public void AllBulletToGold()
    //{
    //    StartCoroutine(coAllBulletToGold());
    //}


    //private IEnumerator coAllBulletToGold()
    //{
    //    yield return new  WaitForSeconds(0.3f);

    //    SoundMGR.Instance.PlayOneShot(m_cChange);
    //    iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.2f, "y", 0.2f, "time", 1.0f));

    //    for (int i = 0; i < m_FiredBulletList.Count; i++)
    //    {
    //        int ran = Random.Range(1, 50);

    //        if (ran > 1 )
    //        {
    //            StartCoroutine(ToGold(m_FiredBulletList[i]));
    //        }
    //        else 
    //            StartCoroutine(ToHeal(m_FiredBulletList[i]));

    //    }
    //}




    private IEnumerator ToGold(Bullet bullet)
    {
        yield return new WaitForSeconds(Random.Range(0.0f, 0.20f));

        bullet.tag = "Gold";
        bullet.FireBullet(bullet.transform.position,0.0f, 10.0f, m_cItemPattern);
    }


    private IEnumerator ToHeal(Bullet bullet)
    {
        yield return new WaitForSeconds(Random.Range(0.0f, 0.20f));

        bullet.tag = "Heal";
        bullet.FireBullet(bullet.transform.position, 0.0f, 10.0f, m_cHealPattern);
    }

}
