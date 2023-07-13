using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ammunition : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI texty;

    void Awake()
    {
        texty = gameObject.GetComponent<TextMeshProUGUI>();
        texty.text = "Ammo = 5" ;
    }

    // Update is called once per frame
    private void Update()
    {
        string newText = "Ammo = " + controller.ammo;

        texty.text = newText;

    }
}
