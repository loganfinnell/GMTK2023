using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waveStartDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waveStartDelay()
    {
        //wait for time period 
        yield return new WaitForSeconds(4f);

        //start enemy spawner
        GetComponent<EnemySpawner>().StartSpawning();
        
    }


}
