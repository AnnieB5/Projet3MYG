using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesScore : MonoBehaviour
{
    [SerializeField] private TMP_Text enemiesScoreText;
    private int enemiesScore = 0;
    

    void Start()
    {
        //Créé et initialise (ou ré-initialise) le PlayerPref EnemiesScore 
        PlayerPrefs.SetInt("EnemiesScore", 0);

        //Affiche en console la valeur du PlayerPref EnemiesScore
        Debug.Log("initialisation réussie nb ennemis tués: "+ PlayerPrefs.GetInt("EnemiesScore"));

        //Affiche le score du nombre d'ennemis tués
        enemiesScoreText.text = "Ennemis tués: " + enemiesScore;
    }
    
    private void OnCollisionEnter(Collision collision) //Se déclenche à la collision du GO attaché au script, avec un autre GO
    {
        if(collision.gameObject.CompareTag("Enemy Head"))
        {
            //Ajoute un point par ennemi tué, au score du nombre d'ennemis tués
            enemiesScore++;

            //Affiche le score du nombre d'ennemis tués
            enemiesScoreText.text = "Ennemis tués: " + enemiesScore;

            //Sauvegarde le nouveau score en écrasant la valeur précédente du PlayerPref
            PlayerPrefs.SetInt("EnemiesScore", enemiesScore);

            //Affiche en console la valeur du PlayerPref
            Debug.Log("save réussie nb ennemis tués: "+ PlayerPrefs.GetInt("EnemiesScore"));
        }
    }
}
