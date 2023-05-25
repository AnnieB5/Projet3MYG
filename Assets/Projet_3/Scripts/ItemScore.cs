using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score = 0;
    private GameObject coinTouchedGO;
    private CoinSelection coinScript;
    
    
    void Start()
    {
        //Créé et initialise le PlayerPref ItemScore
        PlayerPrefs.SetInt("ItemScore", 0);

        //Affiche en console la valeur du PlayerPref
        Debug.Log("initialisation réussie score: "+ PlayerPrefs.GetInt("ItemScore"));

        //Affiche le score
        DisplayScore();
        





        
        //Charge le score (pièces*valeur de la pièce) sauvegardé, et affiche 0 par défaut de sauvegarde
        //score = PlayerPrefs.GetInt("ItemScore", 0);
        //DisplayScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin Random")) //si la pièce touchée était une pièce choisie aléatoirement
        {
            //Récupère la référence du gameobject pièce concerné
            coinTouchedGO = other.gameObject;

            //Récupère le component MeshRenderer de la pièce
            Renderer coinRenderer = coinTouchedGO.GetComponent<Renderer>();

            //Récupère le script "CoinSelection" de la pièce
            coinScript = coinTouchedGO.GetComponent<CoinSelection>();

            //Ajoute au score les points correspondant à la pièce
            switch (coinScript.chosenCoin)
            {
                case 1:
                    score = score + 1;
                    break;

                case 2:
                    score = score + 5;
                    break;

                case 3:
                    score = score + 10;
                    break; 
            }

            DisplayScore();
            SaveScore();
        }
        //si la pièce choisie était une pièce pré-sélectionnée/déterminée
        else if (other.gameObject.CompareTag("Coin Bronze"))
        {
            score =  score + 1;
            DisplayScore();
            SaveScore();
        }
        else if (other.gameObject.CompareTag("Coin Silver"))
        {
            score =  score + 5;
            DisplayScore();
            SaveScore();
        }
        else if (other.gameObject.CompareTag("Coin Gold"))
        {
            score =  score + 10;
            DisplayScore();
            SaveScore();
        }
    }

    private void DisplayScore()
    {
        //Affiche le (nouveau) score
        scoreText.text = "Score: " + score;
    }

    private void SaveScore()
    {
        //Sauvegarde le score de pièces (nb*valeur) et écrase la précédente sauvegarde s'il y a
        PlayerPrefs.SetInt("ItemScore", score);

        //Affiche en console la valeur du PlayerPref
        Debug.Log("save réussie score: "+ PlayerPrefs.GetInt("ItemScore"));
    }
}
