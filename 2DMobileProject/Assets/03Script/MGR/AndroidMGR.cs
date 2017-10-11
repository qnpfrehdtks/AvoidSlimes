using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using Google;
using GooglePlayGames;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.BasicApi.Events;
using UnityEngine;


public class AndroidMGR : SingleMGR<AndroidMGR>
{

    public bool m_isLogin;

    protected override bool Init()
    {
        m_isLogin = false;


        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
      .Build();

        PlayGamesPlatform.InitializeInstance(config);

        PlayGamesPlatform.DebugLogEnabled = true;

        PlayGamesPlatform.Activate();

        LogIn();


        return true;

    }



    public void LogIn()
    {
        if (!Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.Authenticate((bool success) =>
        {
            if (success)
            {
                m_isLogin = true;
            }
            else
            {
                m_isLogin = false;
            }
        });
        }


    }


    public void PlayerVictoryProcess(BOSS boss, int Score)
    {
        ReportScore(Score);
        UnlockAchievement(boss);
    }




    private void UnlockAchievement(BOSS boss)
    {
        switch (boss)
        {
            case BOSS.BOSS1:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_stage1, 100f, null);
                break;
            case BOSS.BOSS2:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_stage2, 100f, null);
                break;
            case BOSS.BOSS3:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_stage3, 100f, null);
                break;
            case BOSS.BOSS4:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_stage4, 100f, null);
                break;
            case BOSS.BOSS5:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_stage5, 100f, null);
                break;
            case BOSS.BOSS6:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_stage6, 100f, null);
                break;
            case BOSS.BOSS7:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_stage7, 100f, null);
                break;
        }
    }


    private void ReportScore(int Score)
    {

        LogIn();

        if (Social.localUser.authenticated)
            PlayGamesPlatform.Instance.ReportScore(Score, GPGSIds.leaderboard_score, null);

    }

    public void SignOut(int Score)
    {

        if (Social.localUser.authenticated)
            PlayGamesPlatform.Instance.SignOut();

    }

    public void ShowAchievementUI()
    {

        LogIn();

        if(Social.localUser.authenticated)
        Social.ShowAchievementsUI();
        else
        {
            SoundMGR.Instance.PlayOneShot(SOUND.SOUND_CHANGE); 
        }


    }

    public void ShowLeaderboardUI()
    {
        LogIn();

        if (Social.localUser.authenticated)
            Social.ShowLeaderboardUI();
        else
        {
            SoundMGR.Instance.PlayOneShot(SOUND.SOUND_CHANGE);
        }
    }


}
