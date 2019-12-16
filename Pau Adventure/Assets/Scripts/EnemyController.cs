using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed; //speed of the enemy
    Rigidbody rb2D;
    public bool isVertical; // if it's not, it will walk horitzontaly
 
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody>(); //get the enemy's Rigidbody   
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rb2D.position; // get the current position of the enemy

        {
            position.y = position.y + Time.deltaTime * speed;
        }
        else 
        {
            position.x = position.x + Time.deltaTime * speed; // sum the position x with the speed and the time
        }
        

        rb2D.MovePosition(position); // apply the previous sum position to the enemy's rigibody
    }
}
