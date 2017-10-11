using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss9PatternFactory : PatternFactory
{

    public Boss9PatternFactory(BOSS boss) : base(boss)
    {

    }

    protected override void createPatternAxis()
    {
        m_PhaseAxis[0] = 0.7f;
        m_PhaseAxis[1] = 0.5f;
        m_PhaseAxis[2] = 0.1f;
    }

    protected override void createMovePattern()
    {
        m_moveList = new List<MoverStat>();
        SetMoverStat(MoveType.NO_MOVE, 0.1f, 5.0f, iTween.LoopType.pingPong, iTween.EaseType.linear, "One");
        SetMoverStat(MoveType.ROTATE1, 0.1f, 5.0f, iTween.LoopType.pingPong, iTween.EaseType.linear, "One");
        SetMoverStat(MoveType.ToZero, 0.1f, 5.0f, iTween.LoopType.pingPong, iTween.EaseType.linear, "","","",0.0f,2.0f);
        SetMoverStat(MoveType.ROTATE1, 0.1f, 3.0f, iTween.LoopType.pingPong, iTween.EaseType.linear, "Squre");
    }


    protected override void createPattern()
    {
        PatternPackage newPs = null;

        PatternState newPattern;

        for (int i = 0; i < 3; i++)
        {
            newPattern = new PatternState();

            newPattern.setPattern
                (
                true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
                PATTERN_NAME.ROTATE_CIRCULAR,     //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
                0.5f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
                0.5f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
                4.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
                0.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
                0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
                10.0f,                        //    float  ||    AngleRate     || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
                1.5f,                        //    float   ||    Interval      || 탄환 사이의 간격 (시간)
                0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
                30.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
                32,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
                0.1f,                         //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
                0.0f,                        //    float   ||  RotateAngle       || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
                0.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
                0.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
                0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
                BULLET_TYPE.STOP_AND_PLAY,          //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
                BULLET_IMAGE.BASE_BULLET3_2, //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
                0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
                false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
                0.05f + (i * 0.05f),                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
                0.8f + (i * 0.2f));                       //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)

            newPs = new PatternPackage(newPattern, "B_KSky", "E_3", "E_3", "M_8", m_moveList[1]);
            m_curPatternList.Add(newPs);
        }

        newPattern = new PatternState();
        newPattern.setPattern
          (
          false,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
          PATTERN_NAME.SPIRAL_ONE,       //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
          0.5f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
          0.5f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
          0.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
          0.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
          0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
          20.0f,                       //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
          0.1f,                        //    float  ||    Interval      || 탄환 사이의 간격 (시간)
          2.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
          0.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
          3,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
          0.1f,                         //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
          0.0f,                         //    float  ||  RotateAngle   || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
          0.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
          60.0f,                        //    float  ||    MaxAngle        || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
          0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
          BULLET_TYPE.BASE,            //    enum      ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
          BULLET_IMAGE.BASE_BULLET3_1, //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
          0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
          false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
          0.0f,                        //    float   ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
          0.0f                           //    float   ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)
          );

        newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_8", m_moveList[1]);
        m_curPatternList.Add(newPs);

        ///////////////////////////////////////////////////////////////////////
        //                               페이즈 2
        ////////////////////////////////////////////////////////////////////////

        newPattern = new PatternState();
        newPattern.setPattern
          (
          true,                                      //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
          PATTERN_NAME.ROTATE_CIRCULAR,              //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
          0.4f,                                      //    float   ||      XScale      ||  X Scale 값 조정.    
          0.4f,                                      //    flaot   ||      YScale      ||  Y Scale 값 조정.    
          6.5f,                                      //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
          0.0f,                                      //    float    ||      Angle       || 탄환 첫 발사 각도
          0.0f,                                      //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
          20.0f,                                     //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
          0.3f,                                      //    float   ||    Interval      || 탄환 사이의 간격 (시간)
          -2.0f,                                     //    float   ||  BulletSpeedRate || 탄환이 가속도  
          32.0f,                                     //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
          18,                                        //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
          0.0f,                                      //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
          0.0f,                                      //    float  ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
          -2.00f,                                     //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
          0.0f,                                      //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
          0,                                         //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
          BULLET_TYPE.BASE,                          //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
          BULLET_IMAGE.BASE_BULLET3_1,               //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
          0.0f,                                      //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
          false                                      //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
          );

        newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[2]);
        m_curPatternList.Add(newPs);

         newPattern = new PatternState();
        newPattern.setPattern
          (
          false,                                      //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
          PATTERN_NAME.ROTATE_CIRCULAR,              //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
          0.4f,                                      //    float   ||      XScale      ||  X Scale 값 조정.    
          0.4f,                                      //    flaot   ||      YScale      ||  Y Scale 값 조정.    
          6.5f,                                      //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
          10.0f,                                     //    float    ||      Angle       || 탄환 첫 발사 각도
          0.0f,                                      //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
          20.0f,                                     //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
          0.3f,                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
          -2.0f,                                    //    float   ||  BulletSpeedRate || 탄환이 가속도  
          32.0f,                                    //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
          18,                                         //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
          0.0f,                                      //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
          0.0f,                                      //    float  ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
          2.00f,                                     //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
          0.0f,                                      //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
          0,                                         //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
          BULLET_TYPE.BASE,                           //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
          BULLET_IMAGE.BASE_BULLET3_2,               //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
          0.0f,                                      //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
          false                                     //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
          );

        newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[2]);
        newPs.m_PPDelay = 0.15f;
        m_curPatternList.Add(newPs);


        //newPattern = new PatternState();
        //newPattern.setPattern
        //  (
        //  false,                                      //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
        //  PATTERN_NAME.AIMING_RANDOM_SHOTGUN,                      //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
        //  0.3f,                                      //    float   ||      XScale      ||  X Scale 값 조정.    
        //  0.3f,                                      //    flaot   ||      YScale      ||  Y Scale 값 조정.    
        //  0.0f,                                      //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
        //  0.0f,                                     //    float    ||      Angle       || 탄환 첫 발사 각도
        //  0.0f,                                      //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
        //  12.0f,                                     //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
        //  5.0f,                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
        //  1.5f,                                      //    float   ||  BulletSpeedRate || 탄환이 가속도  
        //  0.0f,                                      //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
        //  4,                                         //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
        //  0.05f,                                      //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
        //  0.0f,                                      //    float  ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
        //  1.00f,                                     //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
        //  0.0f,                                      //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
        //  3,                                         //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
        //  BULLET_TYPE.BASE,                           //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
        //  BULLET_IMAGE.BASE_BULLET3_2,               //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
        //  0.0f,                                      //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
        //  false                                     //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
        //  );

        //newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[2]);
        //m_curPatternList.Add(newPs);


        ///////////////////////////////////////////////////////////////////////
        //                               페이즈 3
        ////////////////////////////////////////////////////////////////////////


        for (int i = 0; i < 12; i++)
        {
            newPattern = new PatternState();
            newPattern.setPattern
              (
              true,                                     //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
              PATTERN_NAME.DIRECT,       //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
              0.6f,                                     //    float   ||      XScale      ||  X Scale 값 조정.    
              0.6f,                                     //    flaot   ||      YScale      ||  Y Scale 값 조정.    
              4.0f,                                     //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
              180.0f,                                    //    float    ||      Angle       || 탄환 첫 발사 각도
              0.0f,                                    //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
              0.0f,                                    //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
              0.5f,                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
              0.0f,                                     //    float   ||  BulletSpeedRate || 탄환이 가속도  
              0.0f,                                     //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
              3,                                        //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
              0.1f,                                     //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
              0.0f,                                     //    float  ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
              0.00f,                                    //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
              0.0f,                                     //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
              0,                                        //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
              BULLET_TYPE.BASE,                //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
              BULLET_IMAGE.BASE_BULLET3_2,              //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
              0.0f,                                     //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
              false,                                    //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
              0.0f,
              0.0f,
              false,
              3.0f,
              -4.8f + (0.9f * i)
              );

            newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[2]);
             newPs.m_PPDelay += 0.1f * i;
            m_curPatternList.Add(newPs);
        }



        for (int i = 0; i < 7; i++)
        {
            newPattern = new PatternState();
            newPattern.setPattern
              (
              true,                                     //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
              PATTERN_NAME.DIRECT,       //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
              0.6f,                                     //    float   ||      XScale      ||  X Scale 값 조정.    
              0.6f,                                     //    flaot   ||      YScale      ||  Y Scale 값 조정.    
              4.0f,                                     //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
              270.0f,                                    //    float    ||      Angle       || 탄환 첫 발사 각도
              0.0f,                                    //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
              0.0f,                                    //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
              0.5f,                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
              0.0f,                                     //    float   ||  BulletSpeedRate || 탄환이 가속도  
              0.0f,                                     //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
              4,                                        //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
              0.1f,                                     //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
              0.0f,                                     //    float  ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
              0.00f,                                    //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
              0.0f,                                     //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
              0,                                        //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
              BULLET_TYPE.BASE,                //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
              BULLET_IMAGE.BASE_BULLET3_1,              //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
              0.0f,                                     //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
              false,                                    //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
              0.0f,
              0.0f,
              false,
              -3.0f + (0.9f * i),
              4.5f
              );

            newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[2]);
            newPs.m_PPDelay += 0.1f * i;
            m_curPatternList.Add(newPs);

        }

        for (int i = 0; i < 2; i++)
        {
            newPattern = new PatternState();
            newPattern.setPattern
              (
              true,                                     //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
              PATTERN_NAME.AIMING_X,                    //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
              1.1f,                                     //    float   ||      XScale      ||  X Scale 값 조정.    
              1.1f,                                     //    flaot   ||      YScale      ||  Y Scale 값 조정.    
              2.0f,                                     //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
              180.0f * i,                                   //    float    ||      Angle       || 탄환 첫 발사 각도
              0.0f,                                     //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
              0.0f,                                    //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
              8.0f,                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
              0.0f,                                     //    float   ||  BulletSpeedRate || 탄환이 가속도  
              0.0f,                                     //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
              1,                                        //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
              0.0f,                                     //    float   ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
              0.0f,                                     //    float   ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
              0.0f,                                    //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
              0.0f,                                     //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
              0,                                        //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
              BULLET_TYPE.BASE,                          //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
              BULLET_IMAGE.BASE_BULLET3_3,              //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
              0.0f,                                     //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
              false,                                    //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
              0.0f,
              0.0f,
              false,
              -3.0f + (6.0f) * i,
              0.0f
              );

            newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[2]);
            newPs.m_PPDelay = 4.0f * i;
            m_curPatternList.Add(newPs);

        }


            newPattern = new PatternState();
            newPattern.setPattern
              (
              false,                                     //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
              PATTERN_NAME.AIMING_Y,                    //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
              1.1f,                                     //    float   ||      XScale      ||  X Scale 값 조정.    
              1.1f,                                     //    flaot   ||      YScale      ||  Y Scale 값 조정.    
              2.5f,                                     //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
              270.0f,                                   //    float    ||      Angle       || 탄환 첫 발사 각도
              0.0f,                                     //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
              0.0f,                                    //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
              10.0f,                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
              0.0f,                                     //    float   ||  BulletSpeedRate || 탄환이 가속도  
              0.0f,                                     //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
              1,                                        //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
              0.0f,                                     //    float   ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
              0.0f,                                     //    float   ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
              0.0f,                                    //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
              0.0f,                                     //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
              0,                                        //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
              BULLET_TYPE.BASE,                          //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
              BULLET_IMAGE.BASE_BULLET3_3,              //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
              0.0f,                                     //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
              false,                                    //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
              0.0f,
              0.0f,
              false,
              0.0f,
              4.9f
              );

            newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[2]);
            newPs.m_PPDelay =  5.0f;
            m_curPatternList.Add(newPs);


        ///////////////////////////////////////////////////////////////////////
        //                               페이즈 4
        ////////////////////////////////////////////////////////////////////////


        newPattern = new PatternState();
        newPattern.setPattern
          (
          true,                                     //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
          PATTERN_NAME.AIMING_SHOTGUN,       //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
          1.5f,                                     //    float   ||      XScale      ||  X Scale 값 조정.    
          1.5f,                                     //    flaot   ||      YScale      ||  Y Scale 값 조정.    
          4.0f,                                     //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
          0.0f,                                  //    float    ||      Angle       || 탄환 첫 발사 각도
          0.0f,                                    //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
          45.0f,                                    //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
          0.8f,                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
          0.0f,                                     //    float   ||  BulletSpeedRate || 탄환이 가속도  
          0.0f,                                     //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
          3,                                        //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
          0.0f,                                     //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
          0.0f,                                     //    float  ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
          0.00f,                                    //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
          0.0f,                                     //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
          1,                                        //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
          BULLET_TYPE.BASE,                //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
          BULLET_IMAGE.BASE_BULLET3_3,              //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
          0.0f,                                     //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
          false                                    //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
          );

        newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[3]);
        m_curPatternList.Add(newPs);


        newPattern = new PatternState();
        newPattern.setPattern
          (
          true,                                     //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
          PATTERN_NAME.AIMING_X,                    //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
          1.1f,                                     //    float   ||      XScale      ||  X Scale 값 조정.    
          1.1f,                                     //    flaot   ||      YScale      ||  Y Scale 값 조정.    
          2.0f,                                     //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
          0.0f,                                   //    float    ||      Angle       || 탄환 첫 발사 각도
          0.0f,                                     //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
          0.0f,                                    //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
          10.0f,                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
          0.0f,                                     //    float   ||  BulletSpeedRate || 탄환이 가속도  
          0.0f,                                     //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
          1,                                        //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
          0.0f,                                     //    float   ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
          0.0f,                                     //    float   ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
          0.0f,                                    //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
          0.0f,                                     //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
          0,                                        //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
          BULLET_TYPE.BASE,                          //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
          BULLET_IMAGE.BASE_BULLET3_3,              //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
          0.0f,                                     //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
          false,                                    //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
          0.0f,
          0.0f,
          false,
          -3.0f,
          0.0f
          );

        newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[2]);
        m_curPatternList.Add(newPs);

        newPattern = new PatternState();
        newPattern.setPattern
          (
          false,                                     //    bool   ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
          PATTERN_NAME.AIMING_Y,                    //    enum      ||     PatternName  || 무슨 패턴을 쓸건지?
          1.1f,                                     //    float   ||      XScale      ||  X Scale 값 조정.    
          1.1f,                                     //    flaot   ||      YScale      ||  Y Scale 값 조정.    
          2.0f,                                     //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
          270.0f,                                   //    float    ||      Angle       || 탄환 첫 발사 각도
          0.0f,                                     //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
          0.0f,                                    //    float   ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
          10.0f,                                     //    float   ||    Interval      || 탄환 사이의 간격 (시간)
          0.0f,                                     //    float   ||  BulletSpeedRate || 탄환이 가속도  
          0.0f,                                     //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
          1,                                        //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
          0.0f,                                     //    float   ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
          0.0f,                                     //    float   ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
          0.0f,                                    //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
          0.0f,                                     //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
          0,                                        //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
          BULLET_TYPE.BASE,                          //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
          BULLET_IMAGE.BASE_BULLET3_3,              //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
          0.0f,                                     //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
          false,                                    //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
          0.0f,
          0.0f,
          false,
          0.0f,
          5.2f
          );

        newPs = new PatternPackage(newPattern, "B_SBrown", "E_6", "E_6", "M_5", m_moveList[2]);
        m_curPatternList.Add(newPs);



    }
}
