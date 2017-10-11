using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover {


    public override void Init(float speed, Vector3 pos, Vector3 vScale, Quaternion rot, MoverType type)
    {
        base.Init(speed, pos, vScale, rot, type);

        m_stSpriteResource = GetComponent<SpriteRenderer>();

        if (!m_cInputController)
        {
           m_cInputController = gameObject.AddComponent<InputController>();
        }
       
        m_cInputController.Init(this);
    }

    private void Update()
    {
        if (m_isCanActive)
        {
            m_cInputController.MoveUpdate();
          
        }
    }

    private IEnumerator CheckCollision()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);

            PlayerMGR.Instance.CheckCollisionCheck();
        }
    }

    // ====================================================================
    //    이벤트 진행 함수이다. 이 함수가 끝나면 공격을 시작하십다. 좀더 보완
    // ===================================================================
    public void StartEvent()
    {
        StartCoroutine(CheckCollision());
        PatternSetting(BOSS.NONE);
        PatternStart();
    }

}
