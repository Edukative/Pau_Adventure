﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{

    public float speed;
    Rigidbody2D rubyRB2D; //the player's Rigidbody

    public int maxHealth = 5;
    public int currentHealth;

    //timer values
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float InvincibleTimer;




    //animator values
    Animator anim;
    Vector2 lookDirection = new Vector2(1, 0); // the direction is facing the player in the scene

    // Start is called before the first frame update
    void Start()
    {
        rubyRB2D = GetComponent<Rigidbody2D>(); //Get the player's rigidbody 
        currentHealth = maxHealth; // the current health is the max health aviable to the player 
        anim = GetComponent<Animator>(); //get the player's Animator

        currentHealth = 1; //
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // get the horizontal input 
        float vertical = Input.GetAxis("Vertical"); // get the vertical input 

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) // if ot's moving

        {
            lookDirection.Set(move.x, move.y); // sets the vector already created
            lookDirection.Normalize(); // just puts the number into 1 or -1
        }

        // animator set values
        anim.SetFloat("Look X", lookDirection.x);
        anim.SetFloat("Look Y", lookDirection.y);
        anim.SetFloat("Speed", move.magnitude);


        Vector2 position = rubyRB2D.position; // makes a vector based on current position
        position = position + move * speed * Time.deltaTime;

        //transfor.position = position; // sevaes this position to the current
        rubyRB2D.MovePosition(position);

        if (isInvincible) // invincible because the player has collided with damage
        {
            InvincibleTimer -= Time.deltaTime; // count down the timer

            if (InvincibleTimer < 0) // the tomer ended
            {
                isInvincible = false; // the player is vulnerable
            }


        }
       
    }


    public void ChangeHealth(int amount)

   {

        if (amount < 0) // as is inferior to 0, it means damage 
        {
            if(isInvincible) 
            {
                return;
            }
            isInvincible = true; // male the player invincible
            InvincibleTimer = timeInvincible; // resets the timer to the public value

        }
   

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);// limits the number between 0 and max health
        Debug.Log(currentHealth + "/" + maxHealth);

    }
 


}