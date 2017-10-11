using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class BattleUI : BaseUI<BattleUI> {

    private int m_accumulatedScore;
    
    public GameObject m_BG;
    string m_BGStr;

    public Text m_BonusScore;

    public Text m_Score;
    public Text m_Life;
    public Text m_Mp;
    public Image m_BossLifeBar;

    private void Start()
    {
        switch ( GameSceneMGR.Instance.m_BOSSScene)
        {
            case BOSS.BOSS1 :
            case BOSS.BOSS3 :
            case BOSS.BOSS5 :
                m_BGStr = "Stage1";
                SoundMGR.Instance.PlayBGM(SOUND.BGM_BATTLE1);
                break;
            case BOSS.BOSS2 :
            case BOSS.BOSS4 :
            case BOSS.BOSS6 :
            case BOSS.BOSS7:
                m_BGStr = "Stage2";
                SoundMGR.Instance.PlayBGM(SOUND.BGM_BATTLE2);
                break;

        }

        m_BonusScore.gameObject.SetActive(false);

        ScoreUpdate();
        LifeUpdate();
        MpUpdate();

        m_BG.GetComponent<SpriteRenderer>().sprite = SpriteMGR.Instance.GetSprite(m_BGStr);
        CountDownUI.UIInstance.StartTimer(3);
    } 

    public void ScoreUpdate(int score = 0)
    {
        m_Score.text = PlayerMGR.Instance.m_CurScore.ToString();
    }

    public void LifeUpdate()
    {
        m_Life.text = PlayerMGR.Instance.m_Player.m_sStat.m_iCurHp.ToString();
    }
    public void MpUpdate()
    {
        m_Mp.text = PlayerMGR.Instance.m_Player.m_sStat.m_iCurMp.ToString();
    }

    public void BossLifeUpdate()
    {
        m_BossLifeBar.fillAmount = EnemyMGR.Instance.m_CurBoss.m_sStat.GetHPRate();
        EnemyMGR.Instance.m_PhaseController.CheckNextPattern(m_BossLifeBar.fillAmount);
    }


    public void accumulatedScore(int score)
    {
        m_accumulatedScore += score; 
    }

    public void ExposeBonusScore()
    {
        m_BonusScore.gameObject.SetActive(true);
        m_BonusScore.text =  "BONUS +" + m_accumulatedScore.ToString();
        m_accumulatedScore = 0;
        iTween.ScaleFrom(m_BonusScore.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.7f);

        StartCoroutine(ScoreInvisible(1.5f));
    }


    IEnumerator ScoreInvisible(float time)
    {  
        yield return new WaitForSeconds(time);

        m_BonusScore.gameObject.SetActive(false);

    }


}
