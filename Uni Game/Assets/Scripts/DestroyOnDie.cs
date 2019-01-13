
using UnityEngine;



public class DestroyOnDie : MonoBehaviour
{
    AudioSource enemyDieSoundAS;
   
    public void Die()
    {
        //get the audio source
        enemyDieSoundAS = GameObject.FindGameObjectWithTag("DieAS").GetComponent<AudioSource>();
        
        if(enemyDieSoundAS.isPlaying == false)
        {
            enemyDieSoundAS.Play();
        }
        Destroy(gameObject);

    }
}
