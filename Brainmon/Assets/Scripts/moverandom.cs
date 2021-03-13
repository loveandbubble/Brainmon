using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverandom : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float nextActionTime = 0.0f;
    public float time = 1f;
    float myWidth;
    float myHight;
    int random;
    Transform myTrans;

    // private Vector3 directionToMeat;
    // private Vector3 localScale;
    // private float moveSpeed;
    // private GameObject meat;

    // Start is called before the first frame update
    void Start()
    {
        myTrans = this.transform;
        rb = GetComponent<Rigidbody2D> ();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
        myHight = this.GetComponent<SpriteRenderer>().bounds.extents.y;

        // moveSpeed = 2f;
        // localScale = transform.localScale;
    }


    // private void MoveMon()
    // {
    //     directionToMeat = (meat.transform.position - transform.position).normalized;
    //     rb.velocity = new Vector2(directionToMeat.x, myHight) * moveSpeed;
    // }


    // Update is called once per frame
    void Update()
    {
        //if found food
        if (!GameObject.Find ("meat(Clone)"))
        {
            if (Time.time > nextActionTime) {
                nextActionTime += time;
                // execute block of code here
                random = Random.Range(-1, 2);
                // print(random);
                if(random > 0)
                {
                    Vector3 currRot = myTrans.eulerAngles;
                    currRot.y = 180;
                    myTrans.eulerAngles = currRot;
                    movement = new Vector2(random, myHight);
                }
                if(random < 0)
                {
                    Vector3 currRot = myTrans.eulerAngles;
                    currRot.y = 0;
                    myTrans.eulerAngles = currRot;
                    movement = new Vector2(random, myHight);
                }
                if(random == 0)
                {
                    movement = new Vector2(random, myHight);
                }
                // transform.position += transform.position + new Vector3(1, myHight, 0);

            }
        }

    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
        // MoveMon();
    }
}
