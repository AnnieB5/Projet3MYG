using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesScore : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TMP_Text scoreText;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Head"))
        {
            Debug.Log("détection head");

            //attention, pas score++ car commence de 0 !
            score = score + 1;

            DisplayScore();
        }
    }

    private void DisplayScore()
    {
        scoreText.text = "Ennemis tués: " + score;
    }
}
