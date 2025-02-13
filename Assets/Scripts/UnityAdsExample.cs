﻿using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class UnityAdsExample : MonoBehaviour
{
    public string next_scene;

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }
    public void ShowRewardedAdWithHandler(LevelManager levelmanager)
    {
        Debug.Log("Rewarded Video 1");
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Debug.Log("Rewarded Video 2");
            var options = new ShowOptions { resultCallback = levelmanager.HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                if(next_scene.Length > 0)
                    SceneManager.LoadScene(next_scene);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                SceneManager.LoadScene(next_scene);

                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                SceneManager.LoadScene(next_scene);

                break;
        }
    }
}
