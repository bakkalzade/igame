using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class point : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private TextMeshProUGUI texty;

    void Awake()
    {
        texty = gameObject.GetComponent<TextMeshProUGUI>();
        
    }
    private void Update()
    {
        if(PlayerPrefs.GetInt("point", 0) < controller.point)
        {
            PlayerPrefs.SetInt("point", controller.point);
            Debug.Log(controller.point);
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        string newText = "Point: " + controller.point;

        texty.text = newText;

    }
}
