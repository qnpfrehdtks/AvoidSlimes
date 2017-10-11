using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMGR : MonoBehaviour {

    public void Awake()
    {

        Screen.SetResolution(720, 1280, false);
        this.gameObject.name = "[System]GameManager";
        DontDestroyOnLoad(this.gameObject);

        Init();

    }

    public void Init()
    {
        GameSceneMGR.createManager();
        AndroidMGR.createManager();
        SoundMGR.createManager();
        SpriteMGR.createManager();
        PatternMGR.createManager();
        MoveMGR.createManager();
        PlayerMGR.createManager();
        EnemyMGR.createManager();
        StatMGR.createManager();
        BulletMGR.createManager();
        PlayerBulletMGR.createManager();


    }
}
