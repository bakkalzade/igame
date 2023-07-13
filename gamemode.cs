using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamemode : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI texty;

    void Awake()
    {
        texty = gameObject.GetComponent<TextMeshProUGUI>();
        

    }

    private void Start()
    {
        string newText = "Game Mode: " + gamecontroller.instance.Mode.ToUpper();

        texty.text = newText;
        if (gamecontroller.instance.Mode.Equals("hard"))
        {
            texty.color = Color.red;
        }
        else
        {
            texty.color = Color.green;
        }

    }
}
