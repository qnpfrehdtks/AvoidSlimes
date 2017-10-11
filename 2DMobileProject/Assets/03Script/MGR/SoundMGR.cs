using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SOUND
{
    NONE,
    BGM_MAIN,
    BGM_BATTLE1,
    BGM_BATTLE2,
    SOUND_OK,
    SOUND_SLIME1,
    SOUND_SLIME2,
    SOUND_CHANGE,
    SOUND_COUNT,
    SOUND_DAMAGED,
    SOUND_FIRE,
    SOUND_FIRE2
    

}


public class SoundMGR : SingleMGR<SoundMGR> {

    SOUND m_CurPlayBGM;
    AudioSource m_AudioSource;

    Dictionary<SOUND, AudioClip> m_mAudio;

    protected override bool Init()
    {
        m_mAudio = new Dictionary<SOUND, AudioClip>();
        AudioClip[] arry = Resources.LoadAll<AudioClip>("03Sound");

        if(m_AudioSource == null)
        {
            m_AudioSource = gameObject.AddComponent<AudioSource>();
        }

        for (SOUND i = SOUND.BGM_MAIN; i <= (SOUND)arry.Length; i++)
        {
          
            m_mAudio.Add(i, arry[(int)i-1]);
        }





        return true;
    }

    public void PlayBGM(SOUND sound)
    {
        if(m_CurPlayBGM == sound)
        {
            return;
        }

        if (m_AudioSource.isPlaying)
        {
            m_AudioSource.Stop();
        }

        m_CurPlayBGM = sound;
        m_AudioSource.clip = m_mAudio[sound];
        m_AudioSource.Play();
        m_AudioSource.loop = true;

    }

    public AudioClip GetAudioClip(SOUND sound)
    {
       return m_mAudio[sound];
    }

    public void PlayOneShot(SOUND sound)
    {
        m_AudioSource.PlayOneShot(m_mAudio[sound]);

    }

    public void PlayOneShot(AudioClip sound)
    {
        m_AudioSource.PlayOneShot(sound);

    }

}
