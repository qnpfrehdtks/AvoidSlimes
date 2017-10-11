using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4PatternFactory : PatternFactory
{


    public Boss4PatternFactory(BOSS boss) : base(boss)
    {

    }

    protected override void createPatternAxis()
    {
        m_PhaseAxis[0] = 0.7f;
        m_PhaseAxis[1] = 0.4f;
    }

    protected override void createMovePattern()
    {
        m_moveList = new List<MoverStat>();

        SetMoverStat(MoveType.ROTATE1, 1.0f, 15.0f, iTween.LoopType.pingPong, iTween.EaseType.linear, "One");
        SetMoverStat(MoveType.THREE_KING1, 1.0f, 20.0f, iTween.LoopType.pingPong, iTween.EaseType.linear, "Three1", "Three2", "Three3");
        SetMoverStat(MoveType.NO_MOVE, 1.0f, 0.0f, iTween.LoopType.pingPong, iTween.EaseType.linear, "One");
    }


    protected override void createPattern()
    {
        PatternPackage newPs = null;

        PatternState newPattern = new PatternState();

        newPattern.setPattern
             (
             true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
             PATTERN_NAME.CIRCULAR,       //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
             0.3f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
             0.3f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
             2.5f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
             0.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
             0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
             20.0f,                       //    float  ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
             2.0f,                       //    float   ||    Interval      || 탄환 사이의 간격 (시간)
             0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
             0.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
             36,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
             0.1f,                         //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
             0.0f,                         //    float     ||  RotateAngle   || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
             0.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
             60.0f,                        //    float  ||    MaxAngle        || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
             0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
             BULLET_TYPE.BASE,            //    enum      ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
             BULLET_IMAGE.BASE_BULLET2_2, //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
             0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
             false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
             0.0f,                        //    float   ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
             0.0f,                           //    float   ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)
             false,
             4.8f,
             -3
             );

        newPs = new PatternPackage(newPattern, "B_Perple", "E_5", "E_5", "M_2", m_moveList[0]);
        m_curPatternList.Add(newPs);

        newPattern = new PatternState();

        newPattern.setPattern
           (
           true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
           PATTERN_NAME.CIRCULAR,       //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
           0.3f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
           0.3f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
           2.5f,                       //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
           0.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
           0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
           20.0f,                       //    float  ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
           2.0f,                       //    float   ||    Interval      || 탄환 사이의 간격 (시간)
           0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
           0.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
           36,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
           0.1f,                         //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
           0.0f,                         //    float     ||  RotateAngle   || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
           0.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
           60.0f,                        //    float  ||    MaxAngle        || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
           0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
           BULLET_TYPE.BASE,            //    enum      ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
           BULLET_IMAGE.BASE_BULLET2_2, //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
           0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
           false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
           0.0f,                        //    float   ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
           0.0f,                           //    float   ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)
           false,
           4.8f,
           3
           );

        newPs = new PatternPackage(newPattern, "B_Perple", "E_5", "E_5", "M_2", m_moveList[0]);
        m_curPatternList.Add(newPs);

        newPattern = new PatternState();

        newPattern.setPattern
           (
           false,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
           PATTERN_NAME.CIRCULAR,       //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
           0.3f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
           0.3f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
           2.5f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
           0.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
           0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
           20.0f,                       //    float  ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
           2.0f,                       //    float   ||    Interval      || 탄환 사이의 간격 (시간)
           0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
           0.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
           36,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
           0.1f,                         //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
           0.0f,                         //    float     ||  RotateAngle   || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
           0.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
           45.0f,                        //    float  ||    MaxAngle        || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
           0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
           BULLET_TYPE.BASE,            //    enum      ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
           BULLET_IMAGE.BASE_BULLET2_2, //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
           0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
           false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
           0.0f,                        //    float   ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
           0.0f                           //    float   ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)
           );

        newPs = new PatternPackage(newPattern, "B_Perple", "E_5", "E_5", "M_2", m_moveList[0]);
        m_curPatternList.Add(newPs);

        ///////////////////////////////////////////////////////////////////////
        //                               페이즈 2
        ////////////////////////////////////////////////////////////////////////
        newPattern = new PatternState();

        newPattern.setPattern
            (
            true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
            PATTERN_NAME.WASHER_FAN,  //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
            0.8f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
            0.8f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
            0.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
            0.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
            0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
            30.0f,                        //    float  ||    AngleRate     || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
            0.2f,                        //    float   ||    Interval      || 탄환 사이의 간격 (시간)
            6f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
            0.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
            5,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
            0.1f,                        //    float   ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 발사 간격
            0.0f,                        //    float   ||  RotateAngle      || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
            5.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
            45.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
            5,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
            BULLET_TYPE.BASE,            //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
            BULLET_IMAGE.BASE_BULLET2_2,   //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
            0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
            false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
            0.0f,                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
            0.0f);                       //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)

        newPs = new PatternPackage(newPattern, "B_Perple", "E_3", "E_3", "M_2", m_moveList[2]);
        m_curPatternList.Add(newPs);

        newPattern = new PatternState();

        newPattern.setPattern
            (
            true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
            PATTERN_NAME.WASHER_FAN,  //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
            0.8f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
            0.8f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
            0.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
            90.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
            0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
            30.0f,                        //    float  ||    AngleRate     || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
            0.2f,                        //    float   ||    Interval      || 탄환 사이의 간격 (시간)
            6f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
            0.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
            5,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
            0.1f,                        //    float   ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 발사 간격
            90.0f,                        //    float   ||  RotateAngle      || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
            5.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
            45.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
            5,                           //    int      ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
            BULLET_TYPE.BASE,            //    enum     ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
            BULLET_IMAGE.BASE_BULLET2_2,   //   enum    ||   BulletImage    || 탄막의 이미지 타입은?
            0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
            false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
            0.0f,                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
            0.0f);                       //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)

        newPs = new PatternPackage(newPattern, "B_Perple", "E_3", "E_3", "M_2", m_moveList[2]);
        m_curPatternList.Add(newPs);


        newPattern = new PatternState();

        newPattern.setPattern
            (
            true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
            PATTERN_NAME.WASHER_FAN,  //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
            0.8f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
            0.8f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
            0.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
            180.0f,                        //    float ||      Angle       || 탄환 첫 발사 각도
            0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
            30.0f,                        //    float  ||    AngleRate     || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
            0.2f,                        //    float   ||    Interval      || 탄환 사이의 간격 (시간)
            6f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
            0.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
            5,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
            0.1f,                        //    float   ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 발사 간격
            180.0f,                        //    float   ||  RotateAngle      || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
            5.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
            45.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
            5,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
            BULLET_TYPE.BASE,            //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
            BULLET_IMAGE.BASE_BULLET2_2,   //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
            0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
            false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
            0.0f,                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
            0.0f);                       //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)

        newPs = new PatternPackage(newPattern, "B_Perple", "E_3", "E_3", "M_2", m_moveList[2]);
        m_curPatternList.Add(newPs);

        newPattern = new PatternState();

        newPattern.setPattern
            (
            true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
            PATTERN_NAME.WASHER_FAN,  //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
            0.8f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
            0.8f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
            0.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
            270.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
            0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
            30.0f,                        //    float  ||    AngleRate     || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
            0.2f,                        //    float   ||    Interval      || 탄환 사이의 간격 (시간)
            6f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
            0.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
            5,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
            0.1f,                        //    float   ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 발사 간격
            270.0f,                        //    float   ||  RotateAngle      || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
            5.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
            45.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
            5,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
            BULLET_TYPE.BASE,            //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
            BULLET_IMAGE.BASE_BULLET2_2,   //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
            0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
            false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
            0.0f,                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
            0.0f
            );                       //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)

        newPs = new PatternPackage(newPattern, "B_Perple", "E_3", "E_3", "M_2", m_moveList[2]);
        m_curPatternList.Add(newPs);


        newPattern = new PatternState();

        newPattern.setPattern
            (
            true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
            PATTERN_NAME.AIMING_DIRECT,  //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
            0.6f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
            0.6f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
            6.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
            0.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
            0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
            0.0f,                        //    float  ||    AngleRate     || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
            0.3f,                        //    float   ||    Interval      || 탄환 사이의 간격 (시간)
            0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
            0.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
            1,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정. ShotGun은 한개 넘게
            0.0f,                        //    float  ||  MinInterval      || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
            0.0f,                        //    float   ||  RotateAngle       || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
            0.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
            0.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
            0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
            BULLET_TYPE.BASE,            //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
            BULLET_IMAGE.BASE_BULLET2_1,   //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
            0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
            false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
            0.0f,                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
            0.0f);                       //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)

        newPs = new PatternPackage(newPattern, "B_Perple", "E_5", "E_5", "M_3", m_moveList[2]);
        m_curPatternList.Add(newPs);

        /////////////////////////////////////////////////////////////////////////////
    }
}
