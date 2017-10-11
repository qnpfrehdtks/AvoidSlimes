using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownUI : BaseUI<CountDownUI> {


    AudioClip m_clip;
    Text m_CountDownText;
    int m_StartTime;

    public void StartTimer(int StartTime)
    {
        PlayerMGR.Instance.setControllActive(true);
        m_clip = SoundMGR.Instance.GetAudioClip(SOUND.SOUND_COUNT);
        m_CountDownText = GetComponent<Text>();
        m_CountDownText.gameObject.SetActive(true);
        m_StartTime = StartTime;
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while (m_StartTime > -1)
        {
            if (m_StartTime == 0)
            {
                m_CountDownText.text = "AVOID!" + "\n" +
                    "Slimes!";
            }
            else
            {
                SoundMGR.Instance.PlayOneShot(m_clip);
                m_CountDownText.text = m_StartTime.ToString();
            }

            yield return new WaitForSeconds(1.0f);
            m_StartTime--;
        }

        m_CountDownText.gameObject.SetActive(false);
        PlayerMGR.Instance.PatternStart();
        PlayerMGR.Instance.setControllActive(true);
        EnemyMGR.Instance.StartPattern(1.0f);
    }


}
