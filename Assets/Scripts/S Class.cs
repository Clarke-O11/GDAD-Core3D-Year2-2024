using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SClass : MonoBehaviour
{
    public int score = 10;
    public int bonus = 20;

    public bool isAlive = true;
    public bool hasKey = false;

    public int playerLevel = 1;

    public float playerHealth = 50;
    public string playerName = "Player";
    public bool gameOver = false;

    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Console");
        //Debug.Log($"Your Score is {score}");
        Debug.Log($"Player Health is {playerHealth}");
        Debug.Log($"Player's Name is {playerName}");
        Debug.Log($"Game Over is {gameOver}");

        //Debug.Log($"Your Score is {score += bonus}");

        if (score > 0)
        {
            Debug.Log($"Your Score is {score}");
        }

        if (isAlive == true && hasKey == false)
        {
            //Debug.Log($"Player is Alive and doesn't have a Key");
        }

        if (playerHealth > 0)
        {
            Debug.Log("Player is Alive");
        }
        else
        {
            Debug.Log("Player is Dead");
        }

        switch (playerLevel)
        {
            case 1:
                Debug.Log("Easy Mode"); break;

            case 2:
                Debug.Log("Medium Mode"); break;

            case 3:
                Debug.Log("Hard Mode"); break;

        }

        for (int i = 0; i < bonus; i++)
        {
            //Debug.Log("1, 2, 3, 4, 5");

        }

        while (i < 5)
        {
            //Debug.Log(i += 1);

        }

        GreetPlayer();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void GreetPlayer()
    {
        Debug.Log("Welcome, Player");

    }

    void AddScore(int score, int bonus)
    {
        score += bonus;
    }

    static int Multiply(int score, int bonus)
    {
        return score * bonus;
    }

}
