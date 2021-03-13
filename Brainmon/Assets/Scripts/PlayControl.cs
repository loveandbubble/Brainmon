using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour
{
    public bool feed;
    public GameObject meat;
    float randX;
    Vector2 whereToSpawn;
    Rigidbody2D rb;
    public float spawnRate = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // void KeyboardControl()
    // {
    //     if (Input.GetKeyDown("a"))
    //     {
    //         Setfeed(true);
    //     }

    //     if (Input.GetKeyUp("a"))
    //     {
    //         Setfeed(false);
    //     }
    // }

    public void Setfeed(bool b)
    {
        feed = b;
    }

    // Update is called once per frame
    void Update()
    {
        // KeyboardControl();
    

            if (feed)
            {
                randX = Random.Range (-3.4f, 3.4f);
                whereToSpawn = new Vector2 (randX, transform.position.y);
                Instantiate (meat, whereToSpawn, Quaternion.identity);
                Setfeed(false); 

            }

    }
}
