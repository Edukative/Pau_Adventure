using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    void OnTriggerStay2D (Collider2D other)
    {
        Debug.Log("object that entred the trigger: " + other);

        RubyController controller = other.GetComponent<RubyController>(); // get the player controller from the other thing collied with trigger 


       if (controller != null) // if the controller retrived is not empty 
        {
            // ! the excamation is a negation value 
            if (controller.currentHealth < controller.maxHealth)
            {
                controller.ChangeHealth(1); // call the health function and add 1 to the health of the player

                Destroy(gameObject); // Destroys all the game object and this script too! 
            }
        
        }
    }
}