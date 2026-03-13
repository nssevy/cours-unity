using System;
using Unity.VisualScripting;
using UnityEngine;

public class poseManager : MonoBehaviour
{
    private bool isGamePaused = false;

    [SerializeField]
    private GameObject pauseMenuUI;


    private void Awake()
    {
        pauseMenuUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;

            if (isGamePaused == true)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }


}
