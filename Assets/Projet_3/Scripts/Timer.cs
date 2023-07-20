using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeStart = 90;
    [HideInInspector] public float timeValue;
    private float timeRealised;
    public TextMeshProUGUI timerText;
    public PlayerLife playerLife;
    [HideInInspector] public bool stopChrono;

    void Start()
    {
        //Attribue le temps restant de départ
        timeValue = timeStart;

        stopChrono = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopChrono == false)
        {
            //Alors si la valeur du temps est supérieure à 0, décrémenter le temps du compte à rebours selon le temps qu'il s'écoule réellement
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }

            //Sinon le temps sera égal à 0 (temps écoulé, pas de temps négatif)
            else
            {
                timeValue = 0;
            }

            //Affiche le temps restant
            DisplayTime(timeValue);
        }
    }

    public void StopAndSaveTime()
    {
        //Arrete le compte à rebours (le fige, ne le remet pas à 0)
        stopChrono = true;

        //Calcule le temps réalisé (temps restant inversé)
        timeRealised = timeStart - timeValue;

        //Sauvegarde le temps réalisé
        PlayerPrefs.SetFloat("TimeScore", timeRealised);

        //Affiche en console la valeur du PlayerPref
        Debug.Log("save réussie temps réalisé: " + PlayerPrefs.GetFloat("TimeScore"));
    }

    void DisplayTime(float timeToDisplay)
    {
        //Si temps restant à afficher est inférieur à 0, le temps affiché est 0 (temps écoulé, pas de temps négatif) et le perso du joueur meurt
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            playerLife.Die();
        }

        /* 
        //Seulement si affiche pas les millisecondes, permet qu'à la dernière seconde il soit écrit 1 sec restante plutôt que 0.
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }
        */

        //calcule les minutes restantes: le temps restant calculé en secondes à l'origine, est divisé par 60 pour afficher des minutes, arrondi à l'unité
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);

        //calcule les secondes restantes: on cherche le reste issu d'une division par 60, qui correspond aux restes inférieurs à une minute, arrondi à l'unité
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //calcule les millisecondes restantes: on cherche le reste issu d'une division par 1, qui correspond aux restes inférieurs à une seconde, arrondi à l'unité
        float milliseconds = timeToDisplay % 1 * 1000;

        //met dans le bon format d'affichage le temps à afficher et l'affiche
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
