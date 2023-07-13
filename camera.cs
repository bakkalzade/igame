using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Transform player;

    private Vector3 tempPos;
    // Start is called before the first frame update

    void Start()
    {
        //Debug.Log(gamecontroller.instance.Mode);
        player = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            tempPos = transform.position;
            tempPos.x = player.position.x;

            if (player.position.y > 6) tempPos.y = player.position.y;
            else tempPos.y = 3;

            transform.position = tempPos;
        }
        

    }
}
