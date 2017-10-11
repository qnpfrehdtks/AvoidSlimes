using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet {

    public override void Homing()
    {
        if (m_cStat.m_isHoming)
        {
            float CalculedAngle = EnemyMGR.Instance.CalculMoverAngle(transform.position.x, transform.position.y);

            m_fAngle = CalculedAngle;
        }
    }

    protected override void BulletPushToPool()
    {
        if (gameObject.activeSelf)
        {
            PlayerBulletMGR.Instance.PushBullet(this);
        }
    }

    void OnBecameInvisible()
    {
        m_isFire = false;
        BulletPushToPool();
    }

    void OnDisable()
    {
        if (m_PatternContorller)
        {
            m_PatternContorller.ClearAllPattern();
        }
        m_isFire = false;
    }


}
