using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float rotation; // the rotation that will be applied to the NPC when he changes his movement
    public float speed; // the speed the npc walks
    public float timer; //the timer to change the movement of the NPC
    public bool chasing;// bool that will activate the scared mode, that will make the npc run away from the main character
    public float radius; //the radius of detection, if the main character drinks blood of an NPC inside this radius range, the NPC will enter in scared mode
    public GameObject Player;

    // Start is called before the first frame update

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Playable");
    }
    void Start()
    {
        chasing = false;
        radius = 13;
        speed = 8;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;

            rb2d.velocity = transform.up * speed; // speed when they are moving without danger
            if (Player.gameObject.GetComponent<Character>().suckingblood == true && Vector2.Distance(this.transform.position, Player.transform.position) <= radius)
            {
                chasing = true;
                timer = 6;
            }
        
    }
    private void changedirection()
    {
       
        
            transform.Rotate(new Vector3(0, 0, rotation));
        
    }

        void OnDrawGizmosSelected() //show the radio in unity
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PoliceLimit")
        {
            changedirection();
        }
    }

    
}
