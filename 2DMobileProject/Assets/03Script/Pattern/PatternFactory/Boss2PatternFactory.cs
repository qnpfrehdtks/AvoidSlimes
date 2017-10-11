using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2PatternFactory : PatternFactory {


    public Boss2PatternFactory(BOSS boss) : base(boss)
    {

    }

    protected override void createPatternAxis()
    {
        m_PhaseAxis[0] = 0.7f;
        m_PhaseAxis[1] = 0.35f;
    }

    protected override void createMovePattern()
    {
        SetMoverStat(MoveType.ROTATE1, 1.0f, 15.0f, iTween.LoopType.pingPong, iTween.EaseType.linear, "One");
        SetMoverStat(MoveType.THREE_KING1, 1.0f, 20.0f, iTween.LoopType.pingPong, iTween.EaseType.linear, "Three1", "Three2", "Three3");
    }


    protected override void createPattern()
    {
        PatternPackage newPs = null;

        PatternState newPattern = new PatternState();



/////////////////////////////////////////////////////////////////////////////////////////////
        newPattern.setPattern
    (
    true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
    PATTERN_NAME.SPIRAL_ONE,     //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
    0.5f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
    0.5f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
    6.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
    0.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
    0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
    10.0f,                        //    float  ||    AngleRate     || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
    0.1f,                        //    float   ||    Interval      || 탄환 사이의 간격 (시간)
    0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
    0.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
    4,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
    0.1f,                         //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
    0.8f,                        //    float   ||  RotateAngle       || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
    0.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
    0.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
    0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
    BULLET_TYPE.BASE,          //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
    BULLET_IMAGE.BASE_BULLET1_1, //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
    0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
    false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
    0.0f,                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
    0.0f);                       //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)

        newPs = new PatternPackage(newPattern, "B_Green", "E_3", "E_3", "M_1", m_moveList[0]);
        m_curPatternList.Add(newPs);

        newPattern = new PatternState();

        newPattern.setPattern
            (
            false,                        //    bool    ||       isMix      || 패턴을 다음에 쓰는 SetPattern 패턴과 조합해서 쓸것인지? true면 yes 아니면 false
            PATTERN_NAME.AIMING_DIRECT,  //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
            0.7f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
            0.7f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
            5.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
            30.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
            0.0f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
            0.0f,                        //    float  ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
            1.0f,                        //    float   ||    Interval      || 탄환 사이의 간격 (시간)
            0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
            0.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
            3,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
            0.1f,                        //    float  ||  MinInterval      || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
            0.0f,                        //    float   ||  RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
            0.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
            0.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
            0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
            BULLET_TYPE.BASE,            //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
            BULLET_IMAGE.BASE_BULLET1_2,   //   enum     ||   BulletImage  || 탄막의 이미지 타입은?
            0.0f,                        //    float   ||  HomingRate      || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
            false,                       //    bool    ||   isHoming       || 유도탄으로 발사할건가? 
            0.0f,                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
            1.0f,                        //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)
            true,                         //    bool    ||   isMyPos       || 발사 위치를 내 자리에 아니면 사용자가 지정한 위치에 둘것인지?? 
            0.0f,                         //    float    ||   StopTime     || 탄환의 시작 위치 X값
            0.0f);                        //    float    ||   StopTime     ||  탄환의 시작 위치 Y값

        newPs = new PatternPackage(newPattern, "B_Green", "E_3", "E_3", "M_4", m_moveList[0]);
        m_curPatternList.Add(newPs);




        ///////////////////////////////////////////////////////////////////////
        //                               페이즈 2
        ////////////////////////////////////////////////////////////////////////

        newPattern = new PatternState();

        newPattern.setPattern
            (
            true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
            PATTERN_NAME.ROTATE_CIRCULAR,     //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
            0.6f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
            0.6f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
            5.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
            7.50f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
            0.5f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
            0.0f,                        //    float  ||    AngleRate     || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
            1.0f,                        //    float   ||    Interval      || 탄환 사이의 간격 (시간)
            0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
            15.00f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
            24,                           //    int    ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
            0.0f,                         //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
            15.0f,                        //    float   ||   RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
            10.00f,                       //    float  ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
            0.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
            0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
            BULLET_TYPE.BASE,   //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
            BULLET_IMAGE.BASE_BULLET1_1, //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
            0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
            false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
            0.0f,                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
            0.0f);                       //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)

        newPs = new PatternPackage(newPattern, "B_Green", "E_3", "E_3", "M_1", m_moveList[0]);
        m_curPatternList.Add(newPs);


        newPattern = new PatternState();

        newPattern.setPattern
            (
            true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
            PATTERN_NAME.ROTATE_CIRCULAR,     //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
            0.6f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
            0.6f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
            5.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
            0.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
            0.5f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
            0.0f,                       //    float  ||    AngleRate     || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
            1.0f,                        //    float   ||    Interval      || 탄환 사이의 간격 (시간)
            0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
            15.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
            24,                           //    int    ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
            0.1f,                         //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
            0.0f,                        //    float   ||   RotateAngle     || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
            10.00f,                       //    float  ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
            0.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
            0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
            BULLET_TYPE.STOP_AND_PLAY,   //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
            BULLET_IMAGE.BASE_BULLET1_1, //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
            0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
            false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
            0.0f,                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
            0.2f);                       //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)

        newPs = new PatternPackage(newPattern, "B_Green", "E_3", "E_3", "M_1", m_moveList[0]);
        m_curPatternList.Add(newPs);


        newPattern = new PatternState();

        newPattern.setPattern
            (
            false,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
            PATTERN_NAME.AIMING_FAN,  //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
            1.0f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
            1.0f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
            3.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
            270.0f,                      //    float   ||      Angle       || 탄환 첫 발사 각도
            0.1f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
            60.0f,                        //    float  ||    AngleRate      || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
            3.0f,                        //    float   ||    Interval      || 탄환 사이의 간격 (시간)
            0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
            0.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
            5,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정. ShotGun은 한개 넘게
            0.1f,                        //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
            0.0f,                        //    float   ||  RotateAngle       || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
            0.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
            0.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
            0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
            BULLET_TYPE.TRAIL,            //    enum   ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
            BULLET_IMAGE.BASE_BULLET1_1,   //   enum   ||   BulletImage    || 탄막의 이미지 타입은?
            0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
            false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
            0.0f,                        //    float   ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
            0.0f);                       //    float   ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)
        newPs = new PatternPackage(newPattern, "B_Green", "E_3", "E_3", "M_1", m_moveList[0]);

        m_curPatternList.Add(newPs);

        ///////////////////////////////////////////////////////////////////////
        //                               페이즈 3
        ////////////////////////////////////////////////////////////////////////

        newPattern = new PatternState();

        newPattern.setPattern
            (
            true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
            PATTERN_NAME.ROTATE_CIRCULAR,     //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
            0.6f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
            0.6f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
            5.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
            0.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
            0.5f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
            10.0f,                        //    float  ||    AngleRate     || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
           1.5f,                        //    float   ||    Interval      || 탄환 사이의 간격 (시간)
            0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
            24.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
            32,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
            0.1f,                         //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
            0.0f,                        //    float   ||  RotateAngle       || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
            0.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
            0.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
            0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
            BULLET_TYPE.STOP_AND_PLAY,          //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
            BULLET_IMAGE.BASE_BULLET1_2, //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
            0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
            false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
            0.1f,                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
            1.0f);                       //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)

        newPs = new PatternPackage(newPattern, "B_Green", "E_3", "E_3", "M_1", m_moveList[0]);
        m_curPatternList.Add(newPs);

        newPattern = new PatternState();

        newPattern.setPattern
            (
            true,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
            PATTERN_NAME.ROTATE_CIRCULAR,     //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
            0.6f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
            0.6f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
            5.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
            0.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
            0.5f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
            10.0f,                        //    float  ||    AngleRate     || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
            1.5f,                        //    float   ||    Interval      || 탄환 사이의 간격 (시간)
            0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
            26.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
            32,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
            0.1f,                         //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
            0.0f,                        //    float   ||  RotateAngle       || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
            0.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
            0.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
            0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
            BULLET_TYPE.STOP_AND_PLAY,   //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
            BULLET_IMAGE.BASE_BULLET1_2, //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
            0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
            false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
            0.2f,                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
            1.1f);                       //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)

        newPs = new PatternPackage(newPattern, "B_Green", "E_3", "E_3", "M_4", m_moveList[0]);
        m_curPatternList.Add(newPs);


        newPattern = new PatternState();

        newPattern.setPattern
            (
            false,                        //    bool    ||       isMix      || 패턴을 다른 패턴과 조합해서 쓸것인지
            PATTERN_NAME.ROTATE_CIRCULAR,     //    enum    ||     PatternName  || 무슨 패턴을 쓸건지?
            0.6f,                        //    float   ||      XScale      ||  X Scale 값 조정.    
            0.6f,                        //    flaot   ||      YScale      ||  Y Scale 값 조정.    
            5.0f,                        //    float   ||       Speed      || 탄환이 나갈 때 첫 속도
            0.0f,                        //    float   ||      Angle       || 탄환 첫 발사 각도
            0.5f,                        //    float   ||    SpeedRate     || 탄환이 나갈 때 첫 속도를 점점 올릴것인지?
            0.0f,                        //    float  ||    AngleRate     || 탄환이 나갈 때 발사 각도를 점점 올릴것인지? 샷건이나 부채꼬에서는 각도를 각 각도
            1.5f,                        //    float   ||    Interval      || 탄환 사이의 간격 (시간)
            0.0f,                        //    float   ||  BulletSpeedRate || 탄환이 가속도  
            28.0f,                        //    float   ||  BulletAngleRate || 탄환의 각 증가속도?? 알아서 탄환의 각이 커짐. 
            32,                           //    int     ||     Count        || 탄환을 한번에 발사 하는 놈의 수를 조정.
            0.0f,                         //    float  ||  MinInterval     || ShotGun ,Direct 패턴에서 탄환의 그룹안의 탄환간의 간격
            0.0f,                        //    float   ||  RotateAngle       || 거의 쓸일은 없겠지만, 회전 각 정하기? Washer에서 주로 쓰임.
            00.00f,                       //    float   ||  RotateAngleRate || 탄환이 회전 하는 패턴을 가질 경우, 회전 각 속도 조정 Rotate 붙은 패턴에서 쓰임.
            0.0f,                        //    float   ||    MaxAngle      || Washer 회전 패턴의 경우, 최대 돌 각도가 어느정도인지?
            0,                           //    int     ||   GroupCount     || ShotGun Pattern에서만 쓰임. Shot Group 수 결정. 0으로 둬도 무방.
            BULLET_TYPE.STOP_AND_PLAY,   //    enum    ||   BulletType     || 탄막의 종류는? 안쓰면 Blue값이 Default
            BULLET_IMAGE.BASE_BULLET1_2, //   enum     ||   BulletImage    || 탄막의 이미지 타입은?
            0.0f,                        //    float   ||  HomingRate     || 유도탄의 유도정도, 유도탄 안쓰면 0.0f
            false,                       //    bool    ||   isHoming      || 유도탄으로 발사할건가? 
            0.3f,                        //    float    ||  MoveTime       || 탄환을 처음 어느 정도 움직일 것인가>
            1.2f);                       //    float    ||   StopTime      || 탄환을 어느 정도 멈추고 다시 진행할 것인가)

        newPs = new PatternPackage(newPattern, "B_Green", "E_3", "E_3", "M_4", m_moveList[0]);
        m_curPatternList.Add(newPs);
    }

}
