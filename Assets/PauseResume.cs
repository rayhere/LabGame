using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    [SerializeField] GameObject[] pauseMode;
    [SerializeField] GameObject[] resumeMode;
    // Start is called before the first frame update
    void Start()
    {
        pauseMode = GameObject.FindGameObjectsWithTag("ShowInPauseMode");
        resumeMode = GameObject.FindGameObjectsWithTag("ShowInResumeMode");
        ResumeMode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        //Time.timeScale to zero to stop
        Time.timeScale = 0.0f;
        PauseMode();
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        ResumeMode();
    }

    public void PauseMode()
    {

        foreach (GameObject go in pauseMode)
            go.SetActive(true);

        foreach (GameObject go in resumeMode)
            go.SetActive(false);
    }

    public void ResumeMode()
    {

        foreach (GameObject go in pauseMode)
            go.SetActive(false);

        foreach (GameObject go in resumeMode)
            go.SetActive(true);
    }
}
