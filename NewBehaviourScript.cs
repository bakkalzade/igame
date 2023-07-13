using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private readonly string GROUND_TAG = "ground", BRONZE_TAG = "bronze", GOLD_TAG = "gold", SILVER_TAG = "silver", JUMPER_TAG = "jumper",
        WALK_ANIMATION = "walk";


    private readonly int BRONZE_POINT = 1, SILVER_POINT = 2, GOLD_POINT = 3;


    public float speed = 5f;

    [SerializeField]
    private Vector2 jumpForce = new Vector2(0, 5);

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private bool isGrounded;// is jump ended
    [HideInInspector]
    public int point = 0;

    [SerializeField]
    GameObject deathScene;

    [SerializeField]
    GameObject endScene;
    bool end = false;



    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            xCoordinate();
            jump();
            isFall();//if it falls destroy
        }
        
        
    }
    private void LateUpdate()// after executing everything calculate ponint
    {
        pointCalc();
    }

    void pointCalc()
    {
        if (gamecontroller.instance.Mode.Equals("hard"))
            controller.point = point * 2;
        else
        {
            controller.point = point;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //enemy collision
        if (collision.gameObject.tag.Equals(GROUND_TAG))
            isGrounded = true;
        if (collision.gameObject.tag.Equals("enemy"))
            playerDead();
        


    }
    void happyEnd()
    {

        end = true;
        endScene.SetActive(true);
    }
    void playerDead()
    {
        anim.SetBool("exit", true);
        deathScene.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //coin collision 
        if (collision.gameObject.tag.Equals(BRONZE_TAG))
        {
            Destroy(collision.gameObject); point += BRONZE_POINT;
        }
        else if (collision.gameObject.tag.Equals(SILVER_TAG))
        {
            Destroy(collision.gameObject); point += SILVER_POINT;
        }
        else if (collision.gameObject.tag.Equals(GOLD_TAG))
        {
            Destroy(collision.gameObject); point += GOLD_POINT;
        }
        else if (collision.gameObject.tag.Equals(JUMPER_TAG))
        {
            isGrounded = true;

        }

        else if (collision.gameObject.tag.Equals("princess"))
            happyEnd();
    }

   
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                rb.AddForce(jumpForce, ForceMode2D.Impulse);
                
                isGrounded = false;
            }
      
        }
        
    } 
    void xCoordinate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 vec = transform.position;

        if (h < 0) sr.flipX = true;
        else if (h > 0) sr.flipX = false;

        if (h != 0) anim.SetBool(WALK_ANIMATION, true);//animation of walking
        else anim.SetBool(WALK_ANIMATION, false);
        
        
        vec.x += h * speed * Time.deltaTime;
        transform.position = vec;

    }
    private void isFall()
    {
        if (transform.position.y < -5)
        {
            playerDead();
            Destroy(gameObject);
        };
    }


}
