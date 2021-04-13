using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum Direction { NONE, UP, DOWN, LEFT, RIGHT };
    private Direction vampiremove;
    public NPCController killingenemy;
    public Camera cam;
    private float speed = 0.0000003f;
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
    private Rigidbody2D rb2d;
    private Vector3 mouseposition;
    private void Awake()
    {
        bc2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        battimer = 4;
        damagetimer = 3;
       
        scaretimer = 0;
    }

    // Update is called once per frame
    void Update()
    {


        float delta = Time.deltaTime;
        vampiremove = Direction.NONE;
        
        if (scaretimer > 0 && suckingblood)
        {
            scaretimer -= delta;
        }
        else if (scaretimer <= 0)
        {
            
                suckingblood = false;

            

            if (batform == true)
            {

                BatForm();
            }
            else if (takingdamage == true)
            {
                speed = 30; 
                damagetimer -= Time.deltaTime;
                takedamage();
            }
            else if(batform==false && takingdamage==false)
            {
                speed = 50;
            }

        
            //MOVEMENT


            facemouse();

            if (Input.GetKey(KeyCode.W))
            {
                vampiremove = Direction.UP;
               
            }

            if (Input.GetKey(KeyCode.S))
            {
                vampiremove = Direction.DOWN;
                
            }

            if (Input.GetKey(KeyCode.D))
            {
                vampiremove = Direction.RIGHT;
               
            }

            if (Input.GetKey(KeyCode.A))
            {
                vampiremove = Direction.LEFT;
                
            }

            //...

            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (cansuckblood)
                {
                    killingenemy.dead = true;
                    bloodmeter++;
                    suckingblood = true;
                    scaretimer = 2;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {

                if (batform == false)
                {
                    BatForm();
                }
            }




        }
    }
    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime*1000;
        if (vampiremove == Direction.NONE)
        {
            rb2d.velocity = Vector2.zero;
        }

        else if (vampiremove == Direction.UP)
        {
            rb2d.velocity = transform.up * speed;
        }
       else if (vampiremove == Direction.DOWN)
        {
            rb2d.velocity = transform.up * speed * -1 ;
        }
        else if (vampiremove == Direction.RIGHT)
        {
            rb2d.velocity = transform.right * speed  ;
        }
        else if (vampiremove == Direction.LEFT)
        {
            rb2d.velocity = transform.right * speed * -1;
        }
    }

    private void BatForm()
    {
        if (bloodmeter > 0 && batform==false)
        {

            batform = true;
            takingdamage = false;
            speed = 100;
            bloodmeter--;
        }
        if (batform == true)
        {
            battimer -= Time.deltaTime;
            damagetimer = 3;
            if (battimer <= 0)
            {
                batform = false;
                battimer = 4;
            }
        }

    }
    private void facemouse()
    {
        Vector2 MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 NewPos = new Vector2(MousePos.x - transform.position.x, MousePos.y - transform.position.y);
        transform.up = NewPos;
    }

    //private bool checkRaycastWithNPC(RaycastHit2D hit)
    //{
       
    //        if (hit.collider != null)
    //        {
    //            if (hit.collider.gameObject.tag == "NPC" ){ return true; }
    //        }
        
    //    return false;
    //}

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

                ////RaycastHit2D right = Physics2D.Raycast(positionright, transform.up, 10);
                ////if (checkRaycastWithNPC(right)) { col1 = true; };
                //RaycastHit2D left = Physics2D.Raycast(positionleft, transform.right, 10);
                //if (checkRaycastWithNPC(left)) { col2 = true; };
                ////RaycastHit2D center = Physics2D.Raycast(positioncenter, transform.up, 10);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Linterna" && batform ==false)
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

