using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasherShotgunPattern : WasherShotgunRRPattern {

    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.WASHER_SHOTGUN;
    }

    protected override float CalculAngle(int idx)
    {
        return m_sPStat.m_fAngle + m_sPStat.m_fAngleRate * ((float)idx / (m_sPStat.m_iFireCount - 1) - 0.5f);
    }
}
