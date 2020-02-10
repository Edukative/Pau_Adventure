using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed; //speed of the enemy
    Rigidbody2D rb2D;
    public bool isVertical; // if it's not, it will walk horitzontaly

    //timer
    float timer;
    int direction = 1;
    public float changeTime = 3.0f;

    // animator values
    Animator anim;

    //waypoint values
    public Vector2[] localNodes;
    //private vectrot2[] worldNodes;
    int currentNode;
    int nextNode;
    Vector2 Velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //get the enemy's Rigidbody   
        timer = changeTime; // set the timer
        anim = GetComponent<Animator>(); // get the enemy's Animator

        // waypoint stuff
        localNodes = new Vector2[transform.childCount];


        for (int i = 0; i<= transform.childCount - 1; ++i) 
        {

            Transform child = transform.GetChild(i).transform;
            localNodes[i] = new Vector2(child.transform.position.x, child.transform.position.y);
            Debug.Log("index"+ i + "Transform" + localNodes[i]) ;

        }



        currentNode = 0;
        nextNode = 1;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (timer < 0)
        {

            direction = -direction; // turns positive to negative and vicerversa
            timer = changeTime; // resets the timer

        }
        Vector2 position = rb2D.position; // get the current position of the enemy

        Vector2 wayPointDirection = localNodes[nextNode] - rb2D.position;
        UpdateAnimations(wayPointDirection);

        float dist = speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        

        if (wayPointDirection.sqrMagnitude < dist * dist)
        {
            dist = wayPointDirection.magnitude;
            currentNode = nextNode;
            nextNode += 1;
            if (nextNode >= localNodes.Length)
            {
                nextNode = 0;
            }



        }


        Velocity = wayPointDirection.normalized * dist;

        rb2D.MovePosition(rb2D.position + Velocity);

        
       

        /*if (isVertical) // if the enemy walks vertically
        {
            position.y = position.y + Time.deltaTime * speed * direction;


            // animator values settings
            anim.SetFloat("Move X", 0);
            anim.SetFloat("Move Y", direction);
        }

        else 
        {
            position.x = position.x + Time.deltaTime * speed * direction; // sum the position x with the speed and the time


            // animator values settings
            anim.SetFloat("Move X", direction);
            anim.SetFloat("Move Y", 0);
        }
        

        rb2D.MovePosition(position); */
        // apply the previous sum position to the enemy's rigibody
    }

    void UpdateAnimations(Vector2 direction)
    {
        anim.SetFloat("Move X", direction.x);
        anim.SetFloat("Move Y", direction.y);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {

            player.ChangeHealth(-1); //damages the player

        }
    }
}
