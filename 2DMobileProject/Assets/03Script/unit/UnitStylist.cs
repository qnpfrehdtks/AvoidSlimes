using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStylist : MonoBehaviour {

    public GameObject m_Body;
    public GameObject m_LEye;
    public GameObject m_REye;
    public GameObject m_Mouth;

    public void init(GameObject body, GameObject Leye, GameObject Reye, GameObject Mouth)
    {
        m_Body = body;
        m_LEye = Leye;
        m_REye = Reye;
        m_Mouth = Mouth;
    }

    public void SetAllPart(string body, string Leye, string Reye, string Mouth)
    {
        SetMouth(Mouth);
        SetLeftEye(Leye);
        SetBody(body);
        SetRightEye(Reye);
    }

    public void SetAllPart(Sprite body, Sprite Leye, Sprite Reye, Sprite Mouth)
    {
        SetMouth(Mouth);
        SetLeftEye(Leye);
        SetBody(body);
        SetRightEye(Reye);
    }

    public void SetRightEye(string imageStr)
    {
        m_REye.GetComponent<SpriteRenderer>().sprite = SpriteMGR.Instance.GetSprite(imageStr);
    }

    public void SetLeftEye(string imageStr)
    {
        m_LEye.GetComponent<SpriteRenderer>().sprite = SpriteMGR.Instance.GetSprite(imageStr);
    }

    public void SetMouth(string imageStr)
    {
        m_Mouth.GetComponent<SpriteRenderer>().sprite = SpriteMGR.Instance.GetSprite(imageStr);
    }

    public void SetBody(string imageStr)
    {
        m_Body.GetComponent<SpriteRenderer>().sprite = SpriteMGR.Instance.GetSprite(imageStr);
    }

    public void SetRightEye(Sprite image)
    {
        m_REye.GetComponent<SpriteRenderer>().sprite = image;
    }

    public void SetLeftEye(Sprite image)
    {
        m_LEye.GetComponent<SpriteRenderer>().sprite = image;
    }

    public void SetMouth(Sprite image)
    {
        m_Mouth.GetComponent<SpriteRenderer>().sprite = image;
    }

    public void SetBody(Sprite image)
    {
        m_Body.GetComponent<SpriteRenderer>().sprite = image;
    }

}
