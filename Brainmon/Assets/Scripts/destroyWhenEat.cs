using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyWhenEat : MonoBehaviour
{
    [SerializeField] GameObject floatingTextPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "monster"){
            Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
