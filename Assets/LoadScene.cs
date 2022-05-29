using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadHistory()
    {
        SceneManager.LoadScene("History1");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("OptionsWindow");
    }

    public void LoadControls()
    {
        SceneManager.LoadScene("ControlsWindow");
    }

    public void LoadVolume()
    {
        SceneManager.LoadScene("VolumeWindow");
    }



    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
