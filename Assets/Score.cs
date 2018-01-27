using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

    public int score = 0;
    public Text text;

    private void Start()
    {
        score = 0;
        UpdateDisplay();
    }

    public void Add (int amount)
    {
        score += amount;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        text.text = "Score: " + score;
    }
}

