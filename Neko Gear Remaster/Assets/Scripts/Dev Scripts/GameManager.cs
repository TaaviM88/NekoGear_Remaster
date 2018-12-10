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

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
            Instance = this;
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
}
