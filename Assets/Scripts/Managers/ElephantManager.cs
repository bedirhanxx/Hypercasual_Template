using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ElephantManager : Singleton<ElephantManager>
    {
        public void LevelFailed()
        {
            Debug.Log("Level Lose Elephant");
            ElephantSDK.Elephant.LevelFailed(LevelManager.Instance.LevelNumber);
        }


        public void LevelWin()
        {
            Debug.Log("Level Win Elephant");
            ElephantSDK.Elephant.LevelCompleted(LevelManager.Instance.LevelNumber);
        }
    }
