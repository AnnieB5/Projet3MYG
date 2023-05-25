using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesScore : MonoBehaviour
{
    [SerializeField] private TMP_Text enemiesScoreText;
    private int enemiesScore = 0;
    

    //[SerializeField] private RestartPlayerPrefs restartScript;

    //[SerializeField] private GameObject playerGO;

    //Méthode appelée à chaque activation du GO, instantation de GO et chargement de scène
    void Start()
    {
        //Créé et initialise le PlayerPref EnemiesScore 
        PlayerPrefs.SetInt("EnemiesScore", 0);

        //Affiche en console la valeur du PlayerPref
        Debug.Log("initialisation réussie nb ennemis tués: "+ PlayerPrefs.GetInt("EnemiesScore"));

        //Affiche le score
        enemiesScoreText.text = "Ennemis tués: " + enemiesScore;






        //Le GO associé au script reste dans la Hierarchy même en changeant de scène
        //DontDestroyOnLoad(this.gameObject);

        //Charge le nombre d'ennemis tués sauvegardé, et affiche 0 par défaut de sauvegarde
        //enemiesScore = PlayerPrefs.GetInt("EnemiesScore", 0);
        //Debug.Log("charge réussie: "+ PlayerPrefs.GetInt("EnemiesScore"));

        //Affiche le score stocké au démarrage/activation du GO
        //DisplayScore();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Head"))
        {
            //Debug.Log("détection head");

            //Ajoute un point par ennemi tué, au score.
            enemiesScore++;
            
            //Attention, pas score++ car commence de 0 !
            //enemiesScore = enemiesScore + 1;

            //Affiche le score
            enemiesScoreText.text = "Ennemis tués: " + enemiesScore;

            //Sauvegarde le nouveau score en écrasant la valeur précédente du PlayerPref
            PlayerPrefs.SetInt("EnemiesScore", enemiesScore);

            //Affiche en console la valeur du PlayerPref
            Debug.Log("save réussie nb ennemis tués: "+ PlayerPrefs.GetInt("EnemiesScore"));
            







            //DisplayScore();
            //SaveScore();
        }
    }

    /*
    private void DisplayScore()
    {
        enemiesScoreText.text = "Ennemis tués: " + restartScript.enemiesScore;
    }

    private void SaveScore()
    {
        //Sauvegarde le nombre d'ennemis tués et écrase la précédente sauvegarde s'il y a
        //PlayerPrefs.SetInt("EnemiesScore", enemiesScore) ;
        //Debug.Log("save réussie: "+ PlayerPrefs.GetInt("EnemiesScore"));
    }
    */
}
