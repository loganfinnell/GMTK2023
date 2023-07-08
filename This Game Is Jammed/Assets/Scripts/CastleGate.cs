using UnityEngine;

public class CastleGate : MonoBehaviour
{

    public int healthCount;
    public int maxHealth;


    public void init()
    {
        healthCount = maxHealth;
    }

    private void Losehealth()
    {
        healthCount--;
        checkHealthCount();
    }


    void checkHealthCount()
    {
        if (healthCount <= 0)
        {
            Debug.Log("You Lost!");

        }
    
    }

}
