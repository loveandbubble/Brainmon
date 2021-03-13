using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateMemory : MonoBehaviour
{
    // monster mon;
    public string scene;

    private SceneController scriptScene;
    
    // public void UpdateMem()
    // {
    //     SceneManager.LoadScene(scene);
    //     scriptScene = GetComponent<SceneController>();
    //     StatusMon.memoryPoint += scriptScene.point;
    //     scriptScene.point = 0;
    //     // mon = GameObject.Find("monster").GetComponent<StatusMon>();
    //     // mon.showstates;
    // }
 
    public void UpdateMem()
    {
        SceneManager.LoadScene(scene);
        scriptScene = GetComponent<SceneController>();
        scriptScene.point += PlayerPrefs.GetInt("memory");
        Debug.Log(scriptScene.point);
        PlayerPrefs.SetInt("memory", scriptScene.point);
        Debug.Log("memory = " + PlayerPrefs.GetInt("memory"));
        scriptScene.point = 0;
        // mon = GameObject.Find("monster").GetComponent<StatusMon>();
        // mon.showstates;
    }
}
