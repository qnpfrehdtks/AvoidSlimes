using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternPackage {


    public float m_PPDelay = 0.0f;

    public PatternState m_Pattern;
    public PatternState m_BulletPattern;

    public Sprite m_Body;
    public Sprite m_REye;
    public Sprite m_LEye;
    public Sprite m_Mouth;

    public MoverStat m_MoveStat;

    float m_MinShakePos;
    float m_MaxShakePos;


    public PatternPackage(PatternState ps)
    {
        m_Pattern = ps;

        m_Body = null;
        m_REye = null;
        m_LEye = null;
        m_Mouth = null;

    }

    public PatternPackage(PatternState ps, string body, string reye, string leye, string mouth, MoverStat mm )
    {
        m_Pattern = ps;
        m_Body = SpriteMGR.Instance.GetSprite(body);
        m_REye = SpriteMGR.Instance.GetSprite(reye);
        m_LEye = SpriteMGR.Instance.GetSprite(leye);
        m_Mouth = SpriteMGR.Instance.GetSprite(mouth);

        m_MoveStat = mm;
    }




    public PatternPackage(PatternPackage pk)
    {
      //  this = pk;
    }




}
