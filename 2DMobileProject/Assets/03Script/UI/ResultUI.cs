using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : BaseUI<ResultUI> {

    public Text m_ResultTXT;
    public Text m_ScoreTxt;
    public Text m_BossPercent;


    public void ResultOn(bool isVic)
    {
        if(isVic)
        {
            m_ResultTXT.text = "VICTORY!";
        }
        else
        {
            m_ResultTXT.text = "FAIL!!";
        }


        SetBossPercent();
        SetScore();

        Vector2 pos = transform.position;
        pos.y = 640;

        iTween.MoveTo(gameObject, pos, 1.0f);

    }
    
    private void SetBossPercent()
    {
      float Percent = 
            (float)EnemyMGR.Instance.m_CurBoss.m_sStat.m_iCurHp / EnemyMGR.Instance.m_CurBoss.m_sStat.m_iHP;

        Percent *= 100;
        Percent = (100.0f) - Percent;

        m_BossPercent.text  = Percent.ToString() + "%";
    }

    private void SetScore()
    {
        int score = PlayerMGR.Instance.m_CurScore;

        m_ScoreTxt.text = score.ToString();
    }

    public void ClickBack()
    {
        SoundMGR.Instance.PlayOneShot(SOUND.SOUND_OK);
        GameSceneMGR.Instance.SceneChange(SCENE.MAIN);
    }


}
