using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject UI;
    public static GameObject currentPlayerControlledBot;
    public GameObject firstControlledBot;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        currentPlayerControlledBot = firstControlledBot;
    }
}
