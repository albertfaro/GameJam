using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Vector2 deadscale;
    private Rigidbody2D rb2d; //reference to this object's rigid body
    private BoxCollider2D bc2d;
    public float rotation; // the rotation that will be applied to the NPC when he changes his movement
    public float speed; // the speed the npc walks
    private float timer; //the timer to change the movement of the NPC
    private int turn;//random range that tells in what direction the NPC is turning
    private bool scared;// bool that will activate the scared mode, that will make the npc run away from the main character
    public float radius; //the radius of detection, if the main character drinks blood of an NPC inside this radius range, the NPC will enter in scared mode
    public GameObject Player;
    public bool dead;
    public float deathtimer;
    public float scaredtimer;
    private SpriteRenderer sprite;
    private Animator animator;
    private int deadid;
   

    private void Awake()
    {   

        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        deadscale = new Vector2(1.2f, 1.2f);
        deadid = Animator.StringToHash("Dead");
        Player = GameObject.FindGameObjectWithTag("Playable");
        scared = false;
        radius = 100;
        rotation = 90;
        speed = 15;
        timer = 0;
        deathtimer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        if (dead==true)
        {
           
            sprite.enabled = false;
            this.transform.localScale = deadscale;

            Destroy(rb2d);
            Destroy(bc2d);
            
            deathtimer -= delta;

        }
        if (deathtimer <= 0)
        {
            
            sprite.enabled = true;
            
            animator.SetBool(deadid, true);
            Destroy(gameObject, 5);
        }
        if (dead == false)
        {
            if (scared == false)
            {

                rb2d.velocity = transform.up * speed; // speed when they are moving without danger
            }
            else
            {
                rb2d.velocity = transform.up * (speed + 40); // speed when they are moving with danger
                  scaredtimer-=delta;
        }


            if (timer <= 0)
            {
                changedirection();


            }
            else
            {
                timer -= Time.deltaTime; // 
            }
            GetScared();
        }
    }
    private void FixedUpdate()
    {
        
    }

    private void changedirection()
    {
        turn = Random.Range(0, 2);
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
        timer = 2;
    }//function with a random nuber that rotates the NPC randomly

    private void GetScared() // changes the bool to change the speed of the NPC
    {
        if (Player.GetComponent<Character>().suckingblood == true && Vector2.Distance(this.transform.position, Player.transform.position) <= radius && scared==false)
        {
            scared = true;
            scaredtimer = 6;

            int random = Random.Range(0, 6);
            if (random <= 3)
            {
                FindObjectOfType<SoundManager>().Play("Grito1");
            }
            else
            {
                FindObjectOfType<SoundManager>().Play("Grito2");
            }



        }
        if (Vector2.Distance(this.transform.position, Player.transform.position) > radius && scaredtimer<=0)
        {
            scared = false;
        }
    }
    void OnDrawGizmosSelected() //show the radio in unity
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Playable" || collision.gameObject.tag == "Scenario"|| collision.gameObject.tag=="Playable"|| collision.gameObject.tag=="Police") //change direction if an NPC collides with a player a part from the scenario
        {
            transform.Rotate(new Vector3(0, 0, -180));
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ZoneLimiter")
        {
            transform.Rotate(new Vector3(0, 0, -180));
        }
    }
}
