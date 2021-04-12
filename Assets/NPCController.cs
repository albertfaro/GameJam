using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Rigidbody2D rb2d; //reference to this object's rigid body
    public float rotation; // the rotation that will be applied to the NPC when he changes his movement
    public float speed; // the speed the npc walks
    private float timer; //the timer to change the movement of the NPC
    private int turn;//random range that tells in what direction the NPC is turning
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rotation = 90;
        speed = 2;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;
        rb2d.velocity = transform.up * speed; // speed when they are moving without danger
        if (timer <= 0)
        {
            changedirection();
            
          
        }
        else
        {
            timer -= Time.deltaTime; // time
        }
    }

    private void changedirection()
    {
        turn = Random.Range(0, 3);
        switch (turn)
        {
            case 0:
                transform.Rotate(new Vector3(0, 0, rotation));
                break;
            case 1:
                transform.Rotate(new Vector3(0, 0, rotation * 2));
                break;
            case 2:
                transform.Rotate(new Vector3(0, 0, rotation * 3));
                break;

        }
        timer = 4;
    }//function with a random nuber that rotates the NPC randomly
}
