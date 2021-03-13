using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvoMon : MonoBehaviour
{
    Animator animator;
    public GameObject monster;
    bool move = false;

    void evo()
    {
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            monster = GameObject.Find("monster");
            monster.transform.position = new Vector3( 0f, -1.589924f, 0f);
            animator = monster.GetComponent<Animator>();
            animator.SetBool("evo", true);
            
        }
    }
}
