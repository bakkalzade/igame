using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject instructionPanel;
    // Start is called before the first frame update
    public void PlayGame()
    {

        string mode = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        gamecontroller.instance.Mode = mode;

        SceneManager.LoadScene("SampleScene");

    }
    public void Retry()
    {
       
        SceneManager.LoadScene("MainMenu");
        controller.point = 0;
        controller.kill = 0;
        controller.ammo = 5;


    }

    public void InstructionPanel()
    {
        instructionPanel.SetActive(true);

    }
    public void InstructionPanelOut()
    {
        instructionPanel.SetActive(false);

    }

}
