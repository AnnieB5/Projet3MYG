using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeScore : MonoBehaviour
{
    public PlayerLife playerLifeScript;
    [SerializeField] TMP_Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        //Créé et initialise (ou ré-initialise) le PlayerPref LifeScore 
        PlayerPrefs.SetInt("LifeScore", playerLifeScript.startLife);

        //DEBUG LAISSER EN COMM'
        //Affiche en console la valeur du PlayerPref EnemiesScore
        //Debug.Log("initialisation réussie nb vies: "+ PlayerPrefs.GetInt("LifeScore"));
    }

    public void DisplayAndSaveScore()
    {
        //Passe les valeurs de vie négatives en égales à zéro
        if (playerLifeScript.life <= 0)
        {
            playerLifeScript.life = 0;
        }

        //Affiche le nombre de vie restant
        lifeText.text = playerLifeScript.life.ToString();

        //Sauvegarde le nouveau score en écrasant la valeur précédente du PlayerPref
        PlayerPrefs.SetInt("LifeScore", playerLifeScript.life);

        //DEBUG LAISSER EN COMM'
        //Affiche en console la valeur du PlayerPref
        //Debug.Log("save réussie nb vies restantes: "+ PlayerPrefs.GetInt("LifeScore"));
    }
}
