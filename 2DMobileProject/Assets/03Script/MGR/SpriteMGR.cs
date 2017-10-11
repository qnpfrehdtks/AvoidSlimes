


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMGR : SingleMGR<SpriteMGR> {

    public Dictionary<string, Sprite> m_mImageDic;
    public Dictionary<BULLET_IMAGE, Sprite> m_mSpriteDic;
  
    Sprite[] m_SpriteArray;

    protected override bool Init()
    {
        m_mImageDic = new Dictionary<string, Sprite>();
        m_mSpriteDic = new Dictionary<BULLET_IMAGE, Sprite>();

        m_SpriteArray = Resources.LoadAll<Sprite>("02Sprite/Bullet");
     

        for (int i=0; i < m_SpriteArray.Length; i++)
        {
            m_mSpriteDic.Add((BULLET_IMAGE)i, m_SpriteArray[i]);
        }

        m_SpriteArray = Resources.LoadAll<Sprite>("02Sprite");

        for (int i = 0; i < m_SpriteArray.Length; i++)
        {
            m_mImageDic.Add(m_SpriteArray[i].name , m_SpriteArray[i]);
        }

        return true;
    }


    public Sprite GetSprite(BULLET_IMAGE bulletType)
    {
        return m_mSpriteDic[bulletType];

    }

    public Sprite GetSprite(string imageStr)
    {
        if (m_mImageDic.ContainsKey(imageStr))
        {
            return m_mImageDic[imageStr];
        }
        return null;

    }
}
