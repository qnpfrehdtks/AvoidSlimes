using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour {

   public GameObject m_Slider;

    private void Start()
    {
        GameSceneMGR.Instance.SetSlider(m_Slider.GetComponent<Image>());
        GameSceneMGR.Instance.LoadingScene();
    }
}
