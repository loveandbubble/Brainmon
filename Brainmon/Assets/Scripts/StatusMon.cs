using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatusMon : MonoBehaviour
{
    [SerializeField] GameObject floatingTextPrefab;
    public int checkmemory;
    [SerializeField] Text memoryText;
    public GameObject evo_warning;
    public int EvoCondition = 5;

    Animator animator;
    public Sprite spite2;
    public Sprite spite1;

    // Start is called before the first frame update


    void Start()
    {
        Debug.Log("before" + checkmemory);
        Debug.Log("PlayerPrefs" + PlayerPrefs.GetInt("memory"));

        if (checkmemory != PlayerPrefs.GetInt("memory"))
        {
            checkmemory = PlayerPrefs.GetInt("memory");
            showstates();
            Debug.Log("after" + checkmemory);
        }

        memoryText.text = checkmemory.ToString();
        animator = this.GetComponent<Animator>();
        CheckForm();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkmemory != PlayerPrefs.GetInt("memory"))
        {
            checkmemory = PlayerPrefs.GetInt("memory");
            showstates();
            Debug.Log("after" + checkmemory);
        }
    }

    void CheckForm()
    {
        Debug.Log("form");
        if (checkmemory >= EvoCondition && PlayerPrefs.GetInt("evo") == 1)
        {
            spite1 = this.GetComponent<SpriteRenderer>().sprite;
            animator.SetInteger("EvolutionForm", 1);
            Debug.Log("form2");
        }
        else
        {
            spite2 = this.GetComponent<SpriteRenderer>().sprite;
            Debug.Log("form1");
            animator.SetInteger("EvolutionForm", 0);
        }
    }

    

    void showstates()
    {
        GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = "Memory = " + checkmemory;
        memoryText.text = checkmemory.ToString();
        if (checkmemory >= EvoCondition && PlayerPrefs.GetInt("evo") != 1)
        {
            evo_warning.SetActive(true);
            Debug.Log("evo" + PlayerPrefs.GetInt("evo"));
        }
    }



}
