using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GAnalyticsManager : Singleton<GAnalyticsManager>
{

    void Start()
    {
        GameAnalytics.Initialize();
    }



    public void GameStart(int startedLevel)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Game Started Level " + startedLevel);
        Debug.Log("Game Start");
    }

    public void LevelFail(int failedLevel)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Failed Level  " + failedLevel);
        Debug.Log("Level Fail");
    }

    public void LevelComplete(int completedLevel)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Completed Level " + completedLevel);
        Debug.Log("Level Complete");
    }
    public void GameClose(int completedLevel)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Undefined, "Game Closed Level" + completedLevel);
        Debug.Log("Game Close");
    }


}