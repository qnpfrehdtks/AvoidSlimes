using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMGR : SingleMGR<PlayerBulletMGR> {

    AudioClip m_cChange;

    int idx;
    Sprite m_sGold;
    //BulletFactory m_BulletFactory;
    protected GameObject m_BaseBullet;

    //저장되어 있는 불릿들
    protected Queue<PlayerBullet> m_CurBulletList;
    //밖에 놀고 있는 불릿들
    protected Queue<PlayerBullet> m_FiredBulletList;

    protected override bool Init()
    {
        m_BaseBullet = GameObject.Find("Bullet");

      //  m_BaseBullet 
        m_CurBulletList = new Queue<PlayerBullet>();
        m_FiredBulletList = new Queue<PlayerBullet>();
        m_cChange = SoundMGR.Instance.GetAudioClip(SOUND.SOUND_CHANGE);

        MakeBullet();

        return true;
    }

    protected virtual void MakeBullet()
    {
        // List<GameObject> newList = new List<GameObject>();

        for (int j = 0; j < 100; j++)
        {
            CreateandPushBullet(m_BaseBullet);
        }
    }


    public Bullet PopBullet()
    {
        PlayerBullet bullet;

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


    public bool PushBullet(PlayerBullet bullet)
    {
        m_CurBulletList.Enqueue(bullet);
       // m_FiredBulletList.Remove(bullet);

        bullet.gameObject.SetActive(false);
      
  
        return true;
    }

    protected virtual PlayerBullet CreateandPushBullet(GameObject bullet)
    {

        GameObject obj = Instantiate(bullet, Vector3.zero, Quaternion.identity) as GameObject;
        obj.tag = "PlayerBullet";
        obj.layer = 11;
        obj.transform.parent = gameObject.transform;
        
        PlayerBullet newBullet = obj.AddComponent<PlayerBullet>();

        newBullet.Init();

        obj.SetActive(false);

        m_CurBulletList.Enqueue(newBullet);

        return newBullet;

    }


    public void AllReleaseBullet()
    {
        PlayerBullet[] bullets = GetComponentsInChildren<PlayerBullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            if (bullets[i].gameObject.activeSelf)
                PushBullet(bullets[i]);
        }

    }



}
