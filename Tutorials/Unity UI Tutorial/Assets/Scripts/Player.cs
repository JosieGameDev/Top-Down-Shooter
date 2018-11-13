using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public IntVariable health;

    public UnityEvent onDamaged;


	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        health.Value -= damage;
        onDamaged.Invoke();
    }
    
}
