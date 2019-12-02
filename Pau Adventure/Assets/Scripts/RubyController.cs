﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{

    public float speed;
    Rigidbody2D rubyRB2D; //the player's Rigidbody

    public int maxHealth = 5;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        rubyRB2D = GetComponent<Rigidbody2D>(); //Get the player's rigidbody 
        currentHealth = maxHealth; // the current health is the max health aviable to the player 

        currentHealth = 1; //
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // get the horizontal input 
        float vertical = Input.GetAxis("Vertical"); // get the vertical input 

        Vector2 position = transform.position; // makes a vector based on current position

        position.x = position.x + speed * horizontal * Time.deltaTime; // the position is equal tp the same position but a little bit bigger
        position.y = position.y + speed * vertical * Time.deltaTime;

        //transfor.position = position; // sevaes this position to the current
        rubyRB2D.MovePosition(position);

        Debug.Log("horizontal" + horizontal); // See the values are you sending when pressing the keys 
        Debug.Log("vertical" + vertical);

       
    }


    public void ChangeHealth(int amount)
    {

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);// limits the number between 0 and max health
        Debug.Log(currentHealth + "/" + maxHealth);

    }
 


}