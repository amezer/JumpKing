using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    private Button pauseBtn;
    public GameObject resume;
    private Button resumeBtn;
    public GameObject exit;
    private Button exitBtn;
    public AudioSource audioSource;
    // Start is called before the first frame update
    private void Start() {
        pauseBtn = pause.GetComponent<Button>();
        pauseBtn.onClick.AddListener(Pause);

        resumeBtn = resume.GetComponent<Button>();
        resumeBtn.onClick.AddListener(Resume);

        exitBtn = exit.GetComponent<Button>();
        exitBtn.onClick.AddListener(Exit);
    }
    public void Pause(){
        pause.SetActive(false);
        resume.SetActive(true);
        Time.timeScale = 0f;
        audioSource.Pause();
    }

    public void Resume(){
        pause.SetActive(true);
        resume.SetActive(false);
        Time.timeScale = 1f;
        audioSource.UnPause();
    }

    public void Exit(){
        Application.Quit();
    }
}
