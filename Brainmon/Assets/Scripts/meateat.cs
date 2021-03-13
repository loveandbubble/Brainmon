using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meateat : MonoBehaviour
{
    Transform myTrans;
    public float moveSpeed;
    Rigidbody2D rb;
    Object caneat;

    // [SerializeField] private GameObject floatingTextPrefab;
    // Start is called before the first frame update
    void Start()
    {

        myTrans = this.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find ("meat(Clone)") != null)
        {
            Debug.Log ("meat found");
            if(GameObject.Find("meat(Clone)").transform.position.y < 0.05){
                eat();
            }
        }
    }


    private void eat()
    {
        if(myTrans.position.x < GameObject.Find("meat(Clone)").transform.position.x)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y = 180;
            myTrans.eulerAngles = currRot;
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else if (myTrans.position.x > GameObject.Find("meat(Clone)").transform.position.x)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y = 0;
            myTrans.eulerAngles = currRot;
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if(other.gameObject.tag == "Food"){
    //         Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
    //         Destroy(other.gameObject);
    //     }
    // }

    // void ShowTextOverChara(string text)
    // {
    //     if(floatingTextPrefab)
    //     {
    //         Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
    //         prefab.GetComponentInChildren<TextMesh>().text = text;
    //     }
    // }
}
