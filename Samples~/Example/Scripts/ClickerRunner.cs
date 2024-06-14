using System.Collections;
using uClicker;
using UnityEngine;
using System;

public class ClickerRunner : MonoBehaviour
{
    public ClickerManager Manager;

    // Use this for initialization
    IEnumerator Start()
    {
    
        try
        {
            Manager.LoadProgress();
        }
        catch (Exception e)
        {
            Debug.Log("No save!");
        }
        while (Application.isPlaying)
        {
            yield return new WaitForSecondsRealtime(1);
            Manager.Tick();
            Manager.SaveProgress();
            PlayerPrefs.Save();
        }
    }

    private void OnDestroy()
    {
        Manager.SaveProgress();
    }
}
