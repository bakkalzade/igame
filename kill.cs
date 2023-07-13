using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class kill : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private TextMeshProUGUI texty;

    void Awake()
    {
        texty = gameObject.GetComponent<TextMeshProUGUI>();
        texty.text = "0";
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        string newText = "Kill: " + controller.kill;

        texty.text = newText;

    }
}
