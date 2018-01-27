using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject currentPlayerControlledBot;
    public GameObject firstControlledBot;
    private void Awake()
    {
        currentPlayerControlledBot = firstControlledBot;
    }
}
