using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public NPCController killingenemy;
    public int speed = 2;
    public float rotation = 100;
    public bool cansuckblood = false;
    public bool suckingblood = false;
    private BoxCollider2D bc2d;
    public float life;
    public float damagetimer;
    public bool takingdamage;
    public int bloodmeter;
    public float battimer;
    public bool batform;
    public float scaretimer;

    private void Awake()
    {
        bc2d = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        battimer = 6;
        damagetimer = 3;
        life = 99;
        scaretimer = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        
        float delta = Time.deltaTime;
        if (scaretimer > 0)
        {
            scaretimer -= delta;
        }
        if (batform == true)
        {
            speed = 4;
            battimer -= delta;
            if(battimer <= 0)
            {
                batform = false;
                battimer = 6;
            }

        }
        else
        {
            speed = 2;
        }

        if (takingdamage)
        {
            damagetimer -= Time.deltaTime;
            takedamage();
        }
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

            if (cansuckblood)
            {
                killingenemy.dead = true;
                bloodmeter++;
                suckingblood = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {

            if (batform == false)
            {
                turnIntoBat();
            }
        }




    }

    private void turnIntoBat()
    {
        if (bloodmeter > 0)
        {
            batform = true;
            bloodmeter--;
        }

    }

    private bool checkRaycastWithNPC(RaycastHit2D hit)
    {
       
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "NPC" ){ return true; }
            }
        
        return false;
    }

    private void takedamage()
    {
        if (damagetimer <= 0)
        {
            life--;
            damagetimer = 3;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            if (cansuckblood == false)
            {
                //bool col1 = false;
                //bool col2 = false;
                //bool col3 = false;
                //float centerx = (bc2d.bounds.min.x + bc2d.bounds.max.x) / 2;
                //Vector2 positionright = new Vector2(bc2d.bounds.max.x, bc2d.bounds.max.y);
                //Vector2 positioncenter = new Vector2(centerx, bc2d.bounds.max.y);
                //Vector2 positionleft = new Vector2(bc2d.bounds.max.x, bc2d.bounds.max.y);

                ////RaycastHit2D right = Physics2D.Raycast(positionright, transform.up, 10000);
                ////if (checkRaycastWithNPC(right)) { col1 = true; };
                //RaycastHit2D left = Physics2D.Raycast(positionleft, transform.right, 30);
                //if (checkRaycastWithNPC(left)) { col2 = true; };
                ////RaycastHit2D center = Physics2D.Raycast(positioncenter, transform.up, 1000);
                ////if (checkRaycastWithNPC(center)) { col3 = true; };

                //if (col2 ) { cansuckblood = true; };
                cansuckblood = true;


                killingenemy = collision.gameObject.GetComponent<NPCController>();

            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            cansuckblood = false;
            killingenemy = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Linterna")
        {
            takingdamage = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Linterna")
        {
            takingdamage = false;
            damagetimer = 3;
        }
    }
}

