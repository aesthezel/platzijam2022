using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerOtroPeroDistinto : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene") Destroy(this.gameObject);
    }
}
