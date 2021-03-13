using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWarning : MonoBehaviour
{
    GameObject evo_warning;
    // Start is called before the first frame update

    void closewarning()
    {
        evo_warning =  GameObject.Find("Evo_warning");
        evo_warning.SetActive(false);
        PlayerPrefs.SetInt("evo", 1);
    }
}
