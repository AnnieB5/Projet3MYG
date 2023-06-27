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
        PlayerPrefs.SetInt("LifeScore", 0);

        //Affiche en console la valeur du PlayerPref EnemiesScore
        Debug.Log("initialisation réussie nb vies: "+ PlayerPrefs.GetInt("LifeScore"));
    }



    public void DisplayAndSaveScore()
    {
        //Affiche le nombre de vie restant
        lifeText.text = playerLifeScript.life.ToString();

        //Sauvegarde le nouveau score en écrasant la valeur précédente du PlayerPref
        PlayerPrefs.SetInt("LifeScore", playerLifeScript.life);

        //Affiche en console la valeur du PlayerPref
        Debug.Log("save réussie nb vies restantes: "+ PlayerPrefs.GetInt("LifeScore"));
    }
}
