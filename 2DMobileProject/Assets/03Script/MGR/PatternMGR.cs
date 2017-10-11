using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PATTERN_NAME
{
    AIMING_SHOT,
    AIMING_X,
    AIMING_Y,

    DIRECT,  // 직선샷
    AIMING_DIRECT, // 조준 직선샷
    RANDOM_DIRECT, // 다이렉트가 각도 랜덤샷

    SPIRAL_ONE,  // 회전
    WASHER_SPIRAL,  // 회전의 방향이 갑자기 반대로 바뀌고 안 바뀌고 하는 패턴
    WASHER_FAN,// 부채꼴 모양의 패턴의 방향이 갑자기 반대로 바뀌고 안 바뀌고 하는 패턴
    WASHER_RR_SHOTGUN,
    WASHER_SHOTGUN,

    CIRCULAR,   // 원형으로 크게 뿌리는 패턴
    RANDOM_CIRCULAR, // 원형으로 크게 뿌리지만 랜덤인 패턴
    FAN,   // 부채꼴 모양 
    RANDOM_FAN,  // 부채꼴인데 좀 랜덤 적인 요소를 담아서

    AIMING_FAN,  // 플레이어를 향해 뿌리는 부채꼴
    AIMING_RANDOM_FAN,  // 플레이어를 향해 뿌리지만 랜덤인 부채꼴
    
    ROTATE_RANDOM_SHOTGUN, // 샷건을 돌리면서 쏘지만 랜덤이다.
    ROTATE_SHOTGUN,  // 샷건을 돌리면서 쏜다.
    ROTATE_CIRCULAR,  // 원형 패턴이 회전을 한다
    ROTATE_FAN,  // 부채꼴 패턴이 회전을 한다

    SHOTGUN,   // 부체꼴 패턴과는 다르게 한번 탄환이 전방위로 퍼져나간다는 것
    SHOTGUN_RANDOM,  // 부채꼴이 랜덤 꼴로 나감.
    AIMING_SHOTGUN,   // 샷건 조준샷 
    AIMING_RANDOM_SHOTGUN,   // 샷건 래덤 조준샷 ,
    PLAYER
}

public class PatternMGR : SingleMGR<PatternMGR> {

  //  GameObject m_Base;
    Dictionary<PATTERN_NAME, List<GameObject>> m_dPatternTable;


    protected override bool Init()
    {
        m_dPatternTable = new Dictionary<PATTERN_NAME, List<GameObject>>();
        GameObject[] goes;

        goes = Resources.LoadAll<GameObject>("01Pattern");

        for (int i = 0; i < goes.Length; i++)
        {
            List<GameObject> Temp = new List<GameObject>();

            goes[i].GetComponent<BasePattern>().init();


            int idx;

            if (goes[i].GetComponent<BasePattern>().m_sPStat.m_ePattern == PATTERN_NAME.DIRECT)
            {
                idx = 30;
            }
            else
                idx = 15;


            for (int j = 0; j < idx; j++)
            {
                Temp.Add(CreateItem(goes[i]));
            }
            m_dPatternTable.Add(goes[i].GetComponent<BasePattern>().m_sPStat.m_ePattern, Temp);
        }

        return true;
    }

    public GameObject CreateItem(GameObject obj)
    {
        GameObject item = Instantiate(obj) as GameObject;
        item.SetActive(false);
        item.transform.SetParent(transform);
        return item;

    }

    public BasePattern GetPattern(PATTERN_NAME patternName)
    {
        GameObject go = popFromPool(patternName);
        go.SetActive(true);
        BasePattern bp = go.GetComponent<BasePattern>();
  
        return bp;

    }

    public BasePattern GetPattern( PatternState stat)
    {
        GameObject go = popFromPool(stat.m_ePattern);
        go.SetActive(true);

        BasePattern bp = go.GetComponent<BasePattern>();

        return bp;

    }

    public void RetrunPattern(GameObject go)
    {
         pushToPool(go.gameObject);
    }

    private GameObject popFromPool(PATTERN_NAME pattern)
    {
        List<GameObject> objList = m_dPatternTable[pattern];
        GameObject item;

        if (objList == null) return null;

        if (objList.Count > 1)
        {
            item = objList[0];
            objList.RemoveAt(0);

            return item;
        }

        item = objList[0];
        m_dPatternTable[pattern].Add(CreateItem(item));

        return item;

    }


    private bool pushToPool(GameObject item)
    {
        //   Debug.Log(objName);
        List<GameObject> objList = m_dPatternTable[item.GetComponent<BasePattern>().m_sPStat.m_ePattern];

        if (objList == null)
        {
            return false;
        }
        item.SetActive(false);
        objList.Add(item);

        return true;

    }


}
