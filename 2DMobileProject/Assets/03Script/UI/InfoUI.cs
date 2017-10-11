using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoUI : BaseUI<InfoUI>
{
    public GameObject m_UI;
    private Vector2 m_OriginalPos;
    private Vector2 m_DesPos;


    private void Start()
    {
        m_DesPos = new Vector2(360, 640 );
        m_OriginalPos = m_UI.transform.position;
    }

    public void ClickInfoButton()
    {
        SoundMGR.Instance.PlayOneShot(SOUND.SOUND_OK);
        iTween.MoveTo(m_UI, m_DesPos, 0.2f);
    }

    public void ClickOKButton()
    {
        SoundMGR.Instance.PlayOneShot(SOUND.SOUND_OK);
        iTween.MoveTo(m_UI, m_OriginalPos, 0.2f);
        //iTween.MoveTo(m_UI, m_DesPos, 0.2f);
    }


}
