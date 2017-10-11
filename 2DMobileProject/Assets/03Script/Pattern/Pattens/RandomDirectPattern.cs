using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirectPattern : DirectPattern
{

    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.RANDOM_DIRECT;
    }

    protected override float CalculAngle(int idx)
    {
        m_sPStat.m_fAngle = Random.Range(m_sPStat.m_fAngle, m_sPStat.m_fAngleRate);
        return m_sPStat.m_fAngle;
    }


    protected override IEnumerator PlayPattern()
    {

        while (true)
        {
          

            for (int i = 0; i < m_sPStat.m_iFireCount; i++)
            {
                FireBullet(i);

                yield return new WaitForSeconds(m_sPStat.m_fMiniFireInterval);
            }
          

            yield return new WaitForSeconds(m_sPStat.m_fFireInterval);
        }
    }

}
