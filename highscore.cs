using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class highscore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI texty;

    void Awake()
    {
        texty = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        

        string newText = "-High Score-\n " + PlayerPrefs.GetInt("point", 0).ToString(); ;

        texty.text = newText;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }
}
