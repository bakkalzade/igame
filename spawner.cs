using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public int secondRandomRange;// how often enemy will be spawned
    
    [HideInInspector]
    public int speedRandomUpRange; // how fast enemy can run 
    [HideInInspector]
    public int speedRandomDownRange; // how fast enemy can run 

    private int randomSide; // if 0 left else right
    

    [SerializeField]
    private GameObject enemy;// enemy type

    private GameObject spawnedEnemy;

    [SerializeField]
    private Transform[] sides;

    private bool inCoroutine;

    void Start()
    {
        if (gamecontroller.instance.Mode.Equals("hard"))
        {
            secondRandomRange = 5; // normal = 6, hard = 4
            speedRandomUpRange = 10; // normal = 7, hard = 10
            speedRandomDownRange = 3; // normal = 1 hard = 3
        }
        else
        {
            secondRandomRange = 6; // normal = 6, hard = 4
            speedRandomUpRange = 7; // normal = 7, hard = 10
            speedRandomDownRange = 1; // normal = 1 hard = 3
        }
        
        inCoroutine = false;
        StartCoroutine(spawnEnemy()); // first call of spawner


    }

    // Update is called once per frame
    void Update()
    {
        if(!inCoroutine)
            StartCoroutine(spawnEnemy());

    }

    IEnumerator spawnEnemy()
    {

        inCoroutine = true;
        yield return new WaitForSeconds(Random.Range(2, secondRandomRange));

        randomSide = Random.Range(0, 2);

        Transform side = sides[randomSide];

        spawnedEnemy = Instantiate(enemy);

        spawnedEnemy.transform.position = side.position;

        if (randomSide != 0)
            spawnedEnemy.GetComponent<enemyMove>().speed = -Random.Range(speedRandomDownRange, speedRandomUpRange); // if right speed is left
        else
            spawnedEnemy.GetComponent<enemyMove>().speed = Random.Range(speedRandomDownRange, speedRandomUpRange); // if left speed is right

        inCoroutine = false;

    }
}
