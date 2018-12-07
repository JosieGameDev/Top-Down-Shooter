/**********************************************************
 * 
 * HurtTrigger.cs
 * - damages things that com into contact with it
 * - has a timer that disables the collider when triggered, then re-enables it after a short time
 * 
 * 
 * public variables
 * - damage
 *   - the amount of damage this hurt trigger will do
 *   
 * - resetTime
 *   - the time between enabling the trigger
 *   
 *   
 * private custom methods
 * - ResetTrigger
 *   - enables the collider, ready to do damage again
 *   
 *   
 **********************************************************/

using UnityEngine;

public class HurtTrigger : MonoBehaviour
{
    public int damage;

    public float resetTime = 3f;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.tag == "Player")
        {
            //debuggint to check collider
            //Debug.Log("colliding w player");
            collision.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

        
            GetComponent<Collider2D>().enabled = false;

        
            Invoke("ResetTrigger", resetTime);

        }
        else
        {
            //debugging to check colliders worked
            //Debug.Log("other collision");
        }
       
    }


    
    private void ResetTrigger()
    {
       
        GetComponent<Collider2D>().enabled = true;
    }
}
