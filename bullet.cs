using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private readonly int bronzeRate = 5, silverRate = 8, BRONZE_INDEX = 0, SILVER_INDEX = 1, GOLD_INDEX = 2;

    [SerializeField]
    GameObject[] coins;
    public int speed = 10;
    private Rigidbody2D rb;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        isOutOfBound();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("enemy"))
        {
            createCoin(collision.gameObject);
           
            Destroy(collision.gameObject);

            controller.kill++;

            Destroy(gameObject);

        }
    }
    void createCoin(GameObject enemy)
    {
        int index = Random.Range(1, 12);

        if (index < bronzeRate) index = BRONZE_INDEX;
        else if (index < silverRate) index = SILVER_INDEX;
        else index = GOLD_INDEX;

        float hPosition = enemy.transform.position.x;

        float vPosition = enemy.transform.position.y;

        GameObject coin = Instantiate(coins[index]);

        coin.transform.position = new Vector3(hPosition, vPosition);
    }

     void isOutOfBound()
    {

        if (transform.position.x < -50 || transform.position.x > 50) Destroy(gameObject);

    }
}
