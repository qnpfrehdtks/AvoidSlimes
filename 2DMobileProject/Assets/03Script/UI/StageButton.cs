using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageButton : MonoBehaviour {

    BOSS m_Boss;
    int m_iStageNum;
    bool m_isCanClick;

    public Image m_Button;
    public GameObject m_NoImage;
    public GameObject m_Crown;
    public Text m_StageTXT;

    public StageButton init(BOSS boss, int stageNum, bool isActive = false)
    {
        SetActive(isActive);

        m_Boss = boss;
        m_iStageNum = stageNum;

        if (boss != BOSS.BOSS7)
            m_StageTXT.text = stageNum.ToString();
        else
        {
            m_Crown.SetActive(true);
            m_StageTXT.text = "KING";
        }

        if (boss == BOSS.BOSS3 || boss == BOSS.BOSS4)
        m_Button.sprite = SpriteMGR.Instance.GetSprite("B_SPerple");
        else if (boss == BOSS.BOSS5 || boss == BOSS.BOSS6 )
            m_Button.sprite = SpriteMGR.Instance.GetSprite("B_SBrown");
        else if (boss == BOSS.BOSS7)
            m_Button.sprite = SpriteMGR.Instance.GetSprite("B_SSky");


        return this;
       
    }

    public void SetActive(bool isBool)
    {
        m_isCanClick = isBool;
        m_NoImage.SetActive(!isBool);
    }

    public void ClickButton()
    {
        if(m_isCanClick)
        {
            SoundMGR.Instance.PlayOneShot(SOUND.SOUND_OK);
            GameSceneMGR.Instance.SceneChange(SCENE.BATTLE1, m_Boss);
        }

    }



}
