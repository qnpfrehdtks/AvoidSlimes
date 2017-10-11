using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : BaseUI<MainUI> {

    public Button m_StartButton;
    public GameObject m_Eye1;
    public GameObject m_Eye2;


    private void Start()
    {
        SoundMGR.Instance.PlayBGM(SOUND.BGM_MAIN);
        iTween.MoveBy(m_Eye1, iTween.Hash("x", Random.Range(-50,50), "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .5));
        iTween.MoveBy(m_Eye2, iTween.Hash("x", Random.Range(-50, 50), "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .5));
    }


    public void ClickButton()
    {
        SoundMGR.Instance.PlayOneShot(SOUND.SOUND_OK);
        GameSceneMGR.Instance.SceneChange(SCENE.SELECT);
    }

    public void ClickGoogleAchButton()
    {
        AndroidMGR.Instance.ShowAchievementUI();
    }

    public void ClickLeaderBoard()
    {
        AndroidMGR.Instance.ShowLeaderboardUI();
    }

}
