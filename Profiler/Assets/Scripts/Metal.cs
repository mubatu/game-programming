using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metal : MonoBehaviour
{

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void Update()
    {
        
    }

    void LateUpdate()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Metal")
        {
            Debug.Log(gameObject.name + " hit " + collision.gameObject.name);
        }
    }
}
