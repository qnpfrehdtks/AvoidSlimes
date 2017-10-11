using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss7PatternFactory : PatternFactory
{

    public Boss7PatternFactory(BOSS boss) : base(boss)
    {

    }

    protected override void createPatternAxis()
    {
        m_PhaseAxis[0] = 0.8f;
        m_PhaseAxis[1] = 0.4f;
    }

    protected override void createMovePattern()
    {
        m_moveList = new List<MoverStat>();

        SetMoverStat(MoveType.ROTATE1, 1.0f, 4.0f, iTween.LoopType.pingPong, iTween.EaseType.linear, "Rotate");
        SetMoverStat(MoveType.THREE_KING1, 1.0f, 5.0f, iTween.LoopType.pingPong, iTween.EaseType.linear, "Three1", "Three2", "Three3");
        SetMoverStat(MoveType.NO_MOVE, 1.0f, 0.0f, iTween.LoopType.pingPong, iTween.EaseType.linear, "One");
        SetMoverStat(MoveType.ToZero, 0.0f, 1.0f, iTween.LoopType.none, iTween.EaseType.linear, "", "", "", 0.0f, 0.00f);
        SetMoverStat(MoveType.ToZero2, 0.0f, 1.0f, iTween.LoopType.none, iTween.EaseType.linear, "", "", "", 0.0f, 3.80f);
    }


    protected override void createPattern()
    {
        PatternPackage newPs = null;

        PatternState newPattern;

            newPattern = new PatternState();

            newPattern.setPattern
                (
                true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
                PATTERN_NAME.CIRCULAR,  //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
                0.9f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
                0.9f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
                3.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
                0.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
                0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
                0.0f,                        //    float   ||    AngleRate     || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
                1.5f,                      //    float     ||    Interval      || 탄환 사이의 간격 (시간)
                0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
                10.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
                8,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정. ShotGun은 한개 넘게
                0.0f,                        //    float  ||  MinInterval      || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
                0.0f,                        //    float   ||  RotateAngle       || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
                0.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
                0.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
                0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
                BULLET_TYPE.STOP_AND_PLAY,            //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
                BULLET_IMAGE.BASE_BULLET4_1,   //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
                0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
                false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
                0.25f,                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
                1.2f                         //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)
                );
            newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[3]);

            m_curPatternList.Add(newPs);

        newPattern = new PatternState();

        newPattern.setPattern
            (
            true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
            PATTERN_NAME.CIRCULAR,  //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
            0.9f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
            0.9f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
            3.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
            18.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
            0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
            0.0f,                        //    float   ||    AngleRate     || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
            1.6f,                      //    float     ||    Interval      || 탄환 사이의 간격 (시간)
            0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
            10.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
            8,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정. ShotGun은 한개 넘게
            0.0f,                        //    float  ||  MinInterval      || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
            0.0f,                        //    float   ||  RotateAngle       || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
            0.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
            0.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
            0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
            BULLET_TYPE.STOP_AND_PLAY,            //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
            BULLET_IMAGE.BASE_BULLET4_1,   //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
            0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
            false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
            0.35f,                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
            1.1f                         //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)
            );
        newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[3]);

        m_curPatternList.Add(newPs);



        newPattern = new PatternState();
        newPattern.setPattern
          (
          false,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
          PATTERN_NAME.ROTATE_CIRCULAR,       //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
          0.5f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
          0.5f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
          0.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
          0.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
          0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
          20.0f,                       //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
          0.08f,                       //    float  ||    Interval      || 탄환 사이의 간격 (시간)
          3.5f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
          0.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
          6,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
          0.1f,                         //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
          0.0f,                         //    float  ||  RotateAngle   || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
          2.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
          0.0f,                        //    float  ||    MaxAngle        || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
          0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
          BULLET_TYPE.BASE,            //    enum      ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
          BULLET_IMAGE.BASE_BULLET4_3, //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
          0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
          false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
          0.0f,                        //    float   ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
          0.0f                           //    float   ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)
          );

        newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[3]);
        m_curPatternList.Add(newPs);



        ///////////////////////////////////////////////////////////////////////
        //                               페이즈 2
        ////////////////////////////////////////////////////////////////////////
        for (int i = 0; i < 3; i++)
        {
            newPattern = new PatternState();
            newPattern.setPattern
              (
              true,                                     //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
              PATTERN_NAME.AIMING_DIRECT,               //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
              2.5f,                                     //    float   ||      XScale      ||  X Scale 값 조정.    
              2.5f,                                     //    flaot   ||      YScale      ||  Y Scale 값 조정.    
              3.5f,                                     //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
              0.0f,                                    //    float    ||      Angle       || 탄환 첫 발사 각도
              00.0f,                                    //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
              0.0f,                                    //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
              3.0f,                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
              0.0f,                                     //    float   ||  BulletSpeedRate || 탄환이 가속도  
              0.0f,                                     //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
              1,                                        //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
              0.0f,                                     //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
              0.0f,                                     //    float  ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
              0.00f,                                    //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
              0.0f,                                     //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
              0,                                        //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
              BULLET_TYPE.BASE,                          //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
              BULLET_IMAGE.BASE_BULLET4_3,              //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
              0.0f,                                     //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
              false                                    //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
              );

            newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[2]);
            newPs.m_PPDelay = 1.2f * i;
            m_curPatternList.Add(newPs);
        }

        for (int i = 0; i < 3; i++)
        {
            newPattern = new PatternState();
            newPattern.setPattern
              (
              true,                                     //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
              PATTERN_NAME.AIMING_DIRECT,               //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
              3.2f,                                     //    float   ||      XScale      ||  X Scale 값 조정.    
              3.2f,                                     //    flaot   ||      YScale      ||  Y Scale 값 조정.    
              3f,                                     //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
              0.0f,                                    //    float    ||      Angle       || 탄환 첫 발사 각도
              00.0f,                                    //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
              0.0f,                                    //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
              3.0f,                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
              0.0f,                                     //    float   ||  BulletSpeedRate || 탄환이 가속도  
              0.0f,                                     //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
              1,                                        //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
              0.0f,                                     //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
              0.0f,                                     //    float  ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
              0.00f,                                    //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
              0.0f,                                     //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
              0,                                        //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
              BULLET_TYPE.BASE,                          //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
              BULLET_IMAGE.BASE_BULLET4_3,              //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
              0.0f,                                     //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
              false                                    //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
              );

            newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[2]);
            newPs.m_PPDelay = 0.7f * i;
            m_curPatternList.Add(newPs);
        }

        newPattern = new PatternState();
        newPattern.setPattern
          (
          false,                                     //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
          PATTERN_NAME.AIMING_DIRECT,               //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
          4.2f,                                     //    float   ||      XScale      ||  X Scale 값 조정.    
          4.2f,                                     //    flaot   ||      YScale      ||  Y Scale 값 조정.    
          1.8f,                                     //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
          0.0f,                                    //    float    ||      Angle       || 탄환 첫 발사 각도
          00.0f,                                    //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
          0.0f,                                    //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
          2.1f,                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
          0.0f,                                     //    float   ||  BulletSpeedRate || 탄환이 가속도  
          0.0f,                                     //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
          1,                                        //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
          0.0f,                                     //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
          0.0f,                                     //    float  ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
          0.00f,                                    //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
          0.0f,                                     //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
          0,                                        //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
          BULLET_TYPE.BASE,                          //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
          BULLET_IMAGE.BASE_BULLET4_3,              //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
          0.0f,                                     //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
          false                                    //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
          );

        newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[2]);
        newPs.m_PPDelay = 2.1f;
        m_curPatternList.Add(newPs);



        ///////////////////////////////////////////////////////////////////////
        //                               페이즈 3
        ////////////////////////////////////////////////////////////////////////


        for (int i = 0; i < 10; i++)
        {
            newPattern = new PatternState();
            newPattern.setPattern
              (
              true,                                     //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
              PATTERN_NAME.AIMING_DIRECT,               //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
              0.6f,                                     //    float   ||      XScale      ||  X Scale 값 조정.    
              0.6f,                                     //    flaot   ||      YScale      ||  Y Scale 값 조정.    
              2.0f,                                     //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
              0.0f,                                    //    float    ||      Angle       || 탄환 첫 발사 각도
              00.0f,                                    //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
              0.0f,                                    //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
              4.0f,                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
              0.0f,                                     //    float   ||  BulletSpeedRate || 탄환이 가속도  
              0.0f,                                     //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
              1,                                        //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
              0.0f,                                     //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
              0.0f,                                     //    float  ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
              0.00f,                                    //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
              0.0f,                                     //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
              0,                                        //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
              BULLET_TYPE.STOP_AND_PLAY,                          //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
              BULLET_IMAGE.BASE_BULLET4_3,              //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
              0.0f,                                     //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
              false,                                    //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
              0.0f,
              2.0f,
              true,
              0.0f + Mathf.Cos( (36.0f * i) * Mathf.Deg2Rad) * 0.8f,
              0.0f + Mathf.Sin((36.0f * i) * Mathf.Deg2Rad) * 0.8f
              );

            newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[4]);
            m_curPatternList.Add(newPs);
        }


        for (int i = 0; i < 11; i++)
        {
            newPattern = new PatternState();
            newPattern.setPattern
              (
              true,                                     //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
              PATTERN_NAME.DIRECT,       //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
              0.6f,                                     //    float   ||      XScale      ||  X Scale 값 조정.    
              0.6f,                                     //    flaot   ||      YScale      ||  Y Scale 값 조정.    
              2.0f,                                     //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
              0.0f,                                    //    float    ||      Angle       || 탄환 첫 발사 각도
              00.0f,                                    //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
              0.0f,                                    //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
              Random.Range(0.9f, 1.0f),                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
              0.0f,                                     //    float   ||  BulletSpeedRate || 탄환이 가속도  
              0.0f,                                     //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
              1,                                        //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
              0.0f,                                     //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
              0.0f,                                     //    float  ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
              0.00f,                                    //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
              0.0f,                                     //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
              3,                                        //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
              BULLET_TYPE.BASE,                          //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
              BULLET_IMAGE.BASE_BULLET4_2,              //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
              0.0f,                                     //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
              false,                                    //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
              0.0f,
              0.0f,
              false,
              -3.0f,
              -4.70f + (0.9f * i)
              );

            newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[4]);
            m_curPatternList.Add(newPs);
        }


        for (int i = 0; i < 11; i++)
        {
            newPattern = new PatternState();
            newPattern.setPattern
              (
              true,                                     //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
              PATTERN_NAME.DIRECT,       //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
              0.7f,                                     //    float   ||      XScale      ||  X Scale 값 조정.    
              0.7f,                                     //    flaot   ||      YScale      ||  Y Scale 값 조정.    
              1.0f,                                     //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
              180.0f,                                    //    float    ||      Angle       || 탄환 첫 발사 각도
              00.0f,                                    //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
              0.0f,                                    //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
             Random.Range(1.2f, 1.3f),                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
              0.0f,                                     //    float   ||  BulletSpeedRate || 탄환이 가속도  
              0.0f,                                     //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
              1,                                        //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
              0.3f,                                     //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
              0.0f,                                     //    float  ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
              0.00f,                                    //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
              0.0f,                                     //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
              3,                                        //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
              BULLET_TYPE.STOP_AND_PLAY,                //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
              BULLET_IMAGE.BASE_BULLET4_1,              //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
              0.0f,                                     //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
              false,                                    //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
              0.0f,
              0.0f,
              false,
              3.0f,
              -4.2f + (0.9f * i)
              );

            newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[4]);
            m_curPatternList.Add(newPs);
        }


    }
}
