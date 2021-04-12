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
    private bool scared;// bool that will activate the scared mode, that will make the npc run away from the main character
    public float radius; //the radius of detection, if the main character drinks blood of an NPC inside this radius range, the NPC will enter in scared mode
    public GameObject Player;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Playable");
        scared = false;
        radius = 10;
        rotation = 90;
        speed = 2;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (scared == false)
        {

            rb2d.velocity = transform.up * speed; // speed when they are moving without danger
        }
        else
        {
            rb2d.velocity = transform.up * speed*2; // speed when they are moving with danger
        }
        float delta = Time.deltaTime * 1000;

        if (timer <= 0)
        {
            changedirection();
            
          
        }
        else
        {
            timer -= Time.deltaTime; // time
        }
        GetScared();

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

    private void GetScared()
    {
        if (Player.GetComponent<Character>().suckingblood == true && Vector2.Distance(this.transform.position, Player.transform.position) <= radius && scared==false)
        {
            scared = true;
            

        }
        if (Vector2.Distance(this.transform.position, Player.transform.position) > radius)
        {
            scared = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
