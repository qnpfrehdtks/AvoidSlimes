using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUI : BaseUI<SelectUI> {

    public GameObject StageButton;

    public List<GameObject> m_StageList;

    private void Start()
    {
        GameObject grid = GameObject.Find("Grid");
        m_StageList = new List<GameObject>();

        for (int i = (int)BOSS.BOSS1; i <= (int)BOSS.BOSS7; i++)
        {
            GameObject NewGO = Instantiate(StageButton, grid.transform);
             NewGO.GetComponent<StageButton>().init( (BOSS)i, i-1, true);      
        }
    }
}
