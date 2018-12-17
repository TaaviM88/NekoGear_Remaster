using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score Instance;
    [Header("UI-TextBoxs")]
    public TMP_Text uiScore;
    int currentScore = 0;
    int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
            Instance = this;


        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void AddPoint(int point)
    {
        currentScore += point;
        uiScore.text = "Score: " + currentScore.ToString();
    }
}
