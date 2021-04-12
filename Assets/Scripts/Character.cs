using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public int speed = 2;
    public float rotation = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //MOVEMENT
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

       

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, -Input.GetAxis("Horizontal") *
            rotation * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, Input.GetAxis("Horizontal") *
            -rotation * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S))
            {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        //...

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //MORDER A GENTE
        }



    }
}

