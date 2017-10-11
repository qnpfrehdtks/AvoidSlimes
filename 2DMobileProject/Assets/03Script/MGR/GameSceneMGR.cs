using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SCENE
{
    LOAD,
    MAIN,
    SELECT,
    BATTLE1,
    BATTLE2
}



public class GameSceneMGR : SingleMGR<GameSceneMGR> {

    SceneCtrl m_cSceneCtrl;
    Image m_cLoadSlide;
    AsyncOperation m_cAsyncOP;

    public SCENE m_currentScene { get; private set; }
    public SCENE m_NextScene { get; private set; }
    public BOSS m_BOSSScene { get; private set; }

    private bool m_bisReady;

    public void SetSlider(Image slider)
    {
        m_cLoadSlide = slider;
        slider.fillAmount = 0.0f;
    }

    protected override bool Init()
    {
        m_currentScene = SCENE.MAIN;

        return true;
    }


    public void SceneChange(SCENE state, BOSS boss = BOSS.NONE)
    {
        m_NextScene = state;
        m_currentScene = SCENE.LOAD;
        m_BOSSScene = boss;

        m_cAsyncOP = SceneManager.LoadSceneAsync("Loading");
        m_cAsyncOP.allowSceneActivation = true;
    }


    public void LoadingScene()
    {
        if (m_cSceneCtrl != null)
        {
            m_cSceneCtrl.SceneRelease();
            m_cSceneCtrl = null;
        }

        switch (m_NextScene)
        {
            case SCENE.MAIN:
                StartCoroutine(coLoadScene("Main"));
                break;
            case SCENE.SELECT:
                StartCoroutine(coLoadScene("Select"));
                break;
            case SCENE.BATTLE1:
                m_cSceneCtrl = new BattleSceneCtrl();
                m_cSceneCtrl.SceneInit(m_BOSSScene);
                StartCoroutine(coLoadScene("Battle"));
                break;
        }
    }

    private IEnumerator coLoadScene(string sceneName)
    {
        m_cAsyncOP = SceneManager.LoadSceneAsync(sceneName);
        m_cAsyncOP.allowSceneActivation = false;

        while (!m_cAsyncOP.isDone)
            {
                m_cLoadSlide.fillAmount = m_cAsyncOP.progress;

            if (m_cAsyncOP.progress >= 0.9f)
            {
                m_currentScene = m_NextScene;

                m_cAsyncOP.allowSceneActivation = true;

                if (m_cSceneCtrl != null)
                {
                    m_cSceneCtrl.SceneInit();
                }
            }
               // m_cAsyncOP.allowSceneActivation = true;
                yield return null;
        }
    }

}
