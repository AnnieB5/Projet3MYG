using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    private int coinsCount = 0;
    [SerializeField] private AudioSource collectionSound;

    void Start()
    {
        //Créé et initialise le PlayerPref EnemiesScore 
        PlayerPrefs.SetInt("CoinsScore", 0);

        //Affiche en console la valeur du PlayerPref
        Debug.Log("initialisation réussie nb coins collectés: "+ PlayerPrefs.GetInt("CoinsScore"));

        //Affiche le score
        coinsText.text = "Coins: " + coinsCount;








        //Charge le nombre d'ennemis tués sauvegardé, et affiche 0 par défaut de sauvegarde
        //coinsCount = PlayerPrefs.GetInt("CoinsScore", 0);
        //Debug.Log("charge réussie: "+ PlayerPrefs.GetInt("CoinsScore"));
        //DisplayScore();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin Random") || other.gameObject.CompareTag("Coin Bronze") || other.gameObject.CompareTag("Coin Silver") || other.gameObject.CompareTag("Coin Gold"))
        {
            //Détruit le GO représentant la pièce
            Destroy(other.gameObject);

            //Ajoute un point au score
            coinsCount++;
            
            //Affiche le score
            coinsText.text = "Coins: " + coinsCount;

            //Joue un son de collecte de pièce
            collectionSound.Play();

            //Sauvegarde le nouveau score en écrasant la valeur précédente du PlayerPref
            PlayerPrefs.SetInt("CoinsScore", coinsCount);

            //Affiche en console la valeur du PlayerPref
            Debug.Log("save réussie nb coins collectés: "+ PlayerPrefs.GetInt("CoinsScore"));
        }
    }

    /*
    private void DisplayScore()
    {
        coinsText.text = "Coins: " + coinsCount;
    }

    private void SaveScore()
    {
        //Sauvegarde le nombre d'ennemis tués et écrase la précédente sauvegarde s'il y a
        PlayerPrefs.SetInt("CoinsScore", coinsCount) ;
        //Debug.Log("save réussie: "+ PlayerPrefs.GetInt("CoinsScore"));
    }
    */
}
