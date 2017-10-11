using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MoveType
{
    ROTATE1,
    NO_MOVE,
    ToZero,
    ToZero2,
    ToZero3,
    THREE_KING1
   
}

public struct MoverStat
{
    public MoveType m_eMoveType;

    public float m_Time;
    public iTween.LoopType m_LoopType;
    public iTween.EaseType m_EaseType;
    public string m_PathName1;
    public string m_PathName2;
    public string m_PathName3;
    public float m_delay;

    public float m_x;
    public float m_y;
 

}


public abstract class MoverMove : MonoBehaviour {

    public MoverStat m_sStat;
    private Vector2 m_StartPos;
    public Mover m_mover;

    public void Init(Mover mover, MoverStat stat)
    {
        m_mover = mover;
        m_sStat = stat;
    }

    public abstract void Play();
    public virtual void Stop()
    {
        iTween.Stop(m_mover.gameObject);
    }


}


public class ToPos : MoverMove
{
    public override void Play()
    {
        iTween.MoveTo(m_mover.gameObject, iTween.Hash("position", new Vector3(m_sStat.m_x,m_sStat.m_y),
                                              "easeType", m_sStat.m_EaseType,
                                              "time", m_sStat.m_Time,
                                              "delay", m_sStat.m_delay));
    }
}


public class Rotate : MoverMove
{
    public override void Play()
    {
        iTween.MoveTo(m_mover.gameObject, iTween.Hash("path", iTweenPath.GetPath(m_sStat.m_PathName1),
                                              "easeType", m_sStat.m_EaseType,
                                              "time", m_sStat.m_Time,
                                              "delay", m_sStat.m_delay,
                                              "loopType", m_sStat.m_LoopType));
    }
}


public class NoMove : MoverMove
{
    public override void Play()
    {
      
    }
}

public class ThreeKing : MoverMove
{
    public override void Play()
    {
        if(m_mover != null)
            StartCoroutine(coPlay());
    }

    public override void Stop()
    {
        StopAllCoroutines();
        base.Stop();
    }

    private IEnumerator coPlay()
    {
        while (true)
        {

            iTween.MoveTo(m_mover.gameObject, iTween.Hash("path", iTweenPath.GetPath(m_sStat.m_PathName1),
                                                 "easeType", m_sStat.m_EaseType,
                                                 "time", m_sStat.m_Time,
                                                 "delay", m_sStat.m_delay,
                                                 "loopType", m_sStat.m_LoopType));

            yield return new WaitForSeconds(m_sStat.m_Time + m_sStat.m_delay);

            iTween.MoveTo(m_mover.gameObject, iTween.Hash("path", iTweenPath.GetPath(m_sStat.m_PathName2),
                                         "easeType", m_sStat.m_EaseType,
                                         "time", m_sStat.m_Time,
                                         "delay", m_sStat.m_delay,
                                         "loopType", m_sStat.m_LoopType));

            yield return new WaitForSeconds(m_sStat.m_Time + m_sStat.m_delay);

            iTween.MoveTo(m_mover.gameObject, iTween.Hash("path", iTweenPath.GetPath(m_sStat.m_PathName3),
                                 "easeType", m_sStat.m_EaseType,
                                 "time", m_sStat.m_Time,
                                 "delay", m_sStat.m_delay,
                                 "loopType", m_sStat.m_LoopType));

            yield return new WaitForSeconds(m_sStat.m_Time + m_sStat.m_delay);
        }
    }




}

