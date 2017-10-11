using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneCtrl  {

    public virtual void SceneInit() { }
    public virtual void SceneInit(BOSS boss) { }
    public abstract void SceneRelease();
    
}

public class MainSceneCtrl : SceneCtrl
{

    public override void SceneInit()
    {
     //   PlayerMGR.Instance.CreatePlayer();
    }

    public override void SceneRelease()
    {
       // PlayerMGR.Instance.releasePlayer();
    }

}

public class BattleSceneCtrl : SceneCtrl
{

    public override void SceneInit(BOSS boss)
    {
        PlayerMGR.Instance.CreatePlayer();
        EnemyMGR.Instance.CreateBoss(boss);
    }

    public override void SceneRelease()
    {
        MoveMGR.Instance.releaseMove();
        BulletMGR.Instance.AllReleaseBullet();
        EnemyMGR.Instance.releaseBoss();
        PlayerMGR.Instance.releasePlayer();
    }

}

public class SelectSceneCtrl : SceneCtrl
{

    public override void SceneInit()
    {
      //  PlayerMGR.Instance.CreatePlayer();
    }

    public override void SceneRelease()
    {
       // PlayerMGR.Instance.releasePlayer();
    }

}
