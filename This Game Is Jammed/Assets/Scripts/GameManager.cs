using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CastleGate>().init();
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
