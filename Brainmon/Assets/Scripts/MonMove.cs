using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonMove : MonoBehaviour
{
    public LayerMask monMask;
    public float speed = 1;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;
    // Start is called before the first frame update
    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Check to see
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, monMask);

        // if(!isGrounded)
        // {
        //     Vector3 currRot = myTrans.eulerAngles;
        //     currRot.y += 180;
        //     myTrans.eulerAngles = currRot;
        // }

        //move forward
        Vector2 myVel = myBody.velocity;
        myVel.x = - myTrans.right.x * speed;
        myBody.velocity = myVel;
    }
}
