using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMGR : SingleMGR<MoveMGR> {

    MoverMove m_CurMM;
    Dictionary<MoveType, GameObject> m_mMoveTable;
    
    protected override bool Init()
    {
        m_mMoveTable = new Dictionary<MoveType, GameObject>();

        GameObject go;
        go = new GameObject("[MovePattern]" + typeof(Rotate).ToString(), typeof(Rotate));
        go.GetComponent<MoverMove>().m_sStat.m_eMoveType = MoveType.ROTATE1;
        m_mMoveTable.Add(go.GetComponent<MoverMove>().m_sStat.m_eMoveType, go);
        go.transform.parent = gameObject.transform;
        go.SetActive(false);

        go = new GameObject("[MovePattern]" + typeof(ThreeKing).ToString(), typeof(ThreeKing));
        go.GetComponent<MoverMove>().m_sStat.m_eMoveType = MoveType.THREE_KING1;
        m_mMoveTable.Add(go.GetComponent<MoverMove>().m_sStat.m_eMoveType, go);
        go.transform.parent = gameObject.transform;
        go.SetActive(false);

        go = new GameObject("[MovePattern]" + typeof(NoMove).ToString(), typeof(NoMove));
        go.GetComponent<MoverMove>().m_sStat.m_eMoveType = MoveType.NO_MOVE;
        m_mMoveTable.Add(go.GetComponent<MoverMove>().m_sStat.m_eMoveType, go);
        go.transform.parent = gameObject.transform;
        go.SetActive(false);


        go = new GameObject("[MovePattern]" + typeof(ToPos).ToString(), typeof(ToPos));
        go.GetComponent<MoverMove>().m_sStat.m_eMoveType = MoveType.ToZero;
        m_mMoveTable.Add(go.GetComponent<MoverMove>().m_sStat.m_eMoveType, go);
        go.transform.parent = gameObject.transform;
        go.SetActive(false);

        go = new GameObject("[MovePattern]" + typeof(ToPos).ToString(), typeof(ToPos));
        go.GetComponent<MoverMove>().m_sStat.m_eMoveType = MoveType.ToZero2;
        m_mMoveTable.Add(go.GetComponent<MoverMove>().m_sStat.m_eMoveType, go);
        go.transform.parent = gameObject.transform;
        go.SetActive(false);


        go = new GameObject("[MovePattern]" + typeof(ToPos).ToString(), typeof(ToPos));
        go.GetComponent<MoverMove>().m_sStat.m_eMoveType = MoveType.ToZero3;
        m_mMoveTable.Add(go.GetComponent<MoverMove>().m_sStat.m_eMoveType, go);
        go.transform.parent = gameObject.transform;
        go.SetActive(false);


        return true;
    }

    public void StartMovePattern(Mover mover, MoverStat stat)
    {
        if(!mover)
        {
            return;
        }

        if (!m_CurMM)
        {
            m_CurMM = m_mMoveTable[stat.m_eMoveType].GetComponent<MoverMove>();
            m_CurMM.gameObject.SetActive(true);

            m_CurMM.Init(mover, stat);
            m_CurMM.Play();
        }
       else if (m_CurMM)
        {
            m_CurMM.Stop();
          
            if (stat.m_eMoveType != m_CurMM.m_sStat.m_eMoveType)
            {
                m_CurMM.gameObject.SetActive(false);
                m_CurMM = m_mMoveTable[stat.m_eMoveType].GetComponent<MoverMove>();
                m_CurMM.gameObject.SetActive(true);
            }

            m_CurMM.Init(mover, stat);
            m_CurMM.Play();
        }

    }

    public void StopMove()
    {
        if (m_CurMM)
        {
            m_CurMM.Stop();
        }
    }

    public void releaseMove()
    {
        if (m_CurMM)
        {
            m_CurMM.Stop();
            m_CurMM.gameObject.SetActive(false);
            m_CurMM = null;
        }
    }

}
