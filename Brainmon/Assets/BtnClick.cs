using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnClick : MonoBehaviour
{
    public string scene;

    public void BtnNewScene()
    {
        SceneManager.LoadScene(scene);
    }
}
