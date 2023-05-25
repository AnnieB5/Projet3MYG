using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySavedPlayerPrefs : MonoBehaviour
{
    [SerializeField] private TMP_Text enemiesScoreText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text coinsText;

    // Start is called before the first frame update
    void Start()
    {
        //Affiche la valeur du PlayerPref nb ennemis tués
        enemiesScoreText.text = "Ennemis tués: " + PlayerPrefs.GetInt("EnemiesScore");

        //Affiche la valeur du PlayerPref score
        scoreText.text = "Score: " + PlayerPrefs.GetInt("ItemScore");

        //Affiche la valeur du PlayerPref nb coins collectés
        coinsText.text = "Coins: " + PlayerPrefs.GetInt("CoinsScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
