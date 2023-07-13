using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpwn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] coins;

    private int COIN_SECOND = 5;

    private readonly int bronzeRate = 5, silverRate = 8,  BRONZE_INDEX = 0, SILVER_INDEX = 1, GOLD_INDEX = 2;


    private readonly float upLimit = 2.7f; //max height player can jump
    private readonly float downLimit = 0.8f; //min height player can jump
    private readonly float rightLimit = 34f; //most right player can go
    private readonly float leftLimit = -22f; //most left player can go

    public static int coinCount;// created coin counts
    private int coinLimit; // max coin count

    private bool inCoroutine;

    private GameObject spawnedCoin;



    // Start is called before the first frame update
    void Start()
    {
        inCoroutine = false;
        
        StartCoroutine(createCoin());
        
        inCoroutine = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (!inCoroutine) StartCoroutine(createCoin());

    }

    IEnumerator createCoin()
    {

        inCoroutine = true;
        yield return new WaitForSeconds(COIN_SECOND);

        float hPosition = Random.Range(leftLimit, rightLimit);
        float vPosition = Random.Range(downLimit, upLimit);

        int index = Random.Range(1, 12);

        if (index < bronzeRate) index = BRONZE_INDEX;
        else if (index < silverRate) index = SILVER_INDEX;
        else index = GOLD_INDEX;

        GameObject coin = Instantiate(coins[index]);

        coin.transform.position = new Vector3(hPosition, vPosition);

        inCoroutine = false;

    }
}
