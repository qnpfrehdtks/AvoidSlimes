using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPattern : DirectPattern
{
    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.PLAYER;
    }


    protected override IEnumerator PlayPattern()
    {
        while (true)
        {

          FireBullet(0);
         
         yield return new WaitForSeconds(m_sPStat.m_fFireInterval);

        }
    }
}
