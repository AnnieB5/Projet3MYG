using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySavedPlayerPrefs : MonoBehaviour
{
    [SerializeField] private TMP_Text enemiesScoreText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text timerText;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        //Affiche la valeur du PlayerPref nb ennemis tués
        enemiesScoreText.text = "Ennemis tués: " + PlayerPrefs.GetInt("EnemiesScore");

        //Affiche la valeur du PlayerPref score
        scoreText.text = "Score: " + PlayerPrefs.GetInt("ItemScore");

        //Affiche la valeur du PlayerPref nb coins collectés
        coinsText.text = "Coins: " + PlayerPrefs.GetInt("CoinsScore");

        //Récupère la valeur du PlayPref temps réalisé
        time = PlayerPrefs.GetFloat("TimeScore");

        //calcule les minutes restantes: le temps restant calculé en secondes à l'origine, est divisé par 60 pour afficher des minutes, arrondi à l'unité
        float minutes = Mathf.FloorToInt(time / 60);

        //calcule les secondes restantes: on cherche le reste issu d'une division par 60, qui correspond aux restes inférieurs à une minute, arrondi à l'unité
        float seconds = Mathf.FloorToInt(time % 60);

        //calcule les millisecondes restantes: on cherche le reste issu d'une division par 1, qui correspond aux restes inférieurs à une seconde, arrondi à l'unité
        float milliseconds = time % 1 * 1000;

        //met dans le bon format d'affichage le temps à afficher et l'affiche
        timerText.text = "Temps réalisé: " + string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
