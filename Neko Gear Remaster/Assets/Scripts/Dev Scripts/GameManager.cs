using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject player;
    public static GameManager Instance;
     bool isCounterOn;
    public float counterTime = 3;
    float currentCounter;
    public GameObject beatleveltext;
    bool bossIsBeated = false;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
            Instance = this;

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (isCounterOn)
        {
            if (currentCounter > 0)
            {
                currentCounter -= Time.deltaTime;
            }
            else
            {
                isCounterOn = false;
                ChangeTimeScale(0);
            }
        }

        if(Input.GetButtonUp("Submit"))
        {
            //Pause Game
            if(Time.timeScale == 1 && !bossIsBeated)
            {
                ChangeTimeScale(0);
            }
            else if (Time.timeScale == 0 && !bossIsBeated)
            {
                ChangeTimeScale(1);
            }
            else if(Time.timeScale == 0 && bossIsBeated)
            {
                ResetScene();
            }
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartTimer()
    {
        currentCounter = counterTime;
        isCounterOn = true;
    }

    public void ChangeTimeScale(int i)
    {
        Time.timeScale = i;
    }

    public void BeatLevel()
    {
        beatleveltext.SetActive(true);
        StartTimer();
        bossIsBeated = true;
    }
}
