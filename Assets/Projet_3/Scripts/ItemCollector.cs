using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private AudioSource collectionSound;
    private int coinsCount = 0;
    private bool isEnemyBodyTouched;

    void Start()
    {
        //Créé et initialise (ou ré-initialise) le PlayerPref CoinsScore 
        PlayerPrefs.SetInt("CoinsScore", 0);

        //DEBUG LAISSER EN COMM'
        //Affiche en console la valeur du PlayerPref
        //Debug.Log("initialisation réussie nb coins collectés: "+ PlayerPrefs.GetInt("CoinsScore"));

        //Affiche le score du nombre de pièces collectées
        coinsText.text = coinsCount.ToString();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Si le GO touché est une pièce (collider) ET si le joueur ne touche pas le corps d'un ennemi (collision)
        if ((other.gameObject.CompareTag("Coin Random") || other.gameObject.CompareTag("Coin Bronze") || other.gameObject.CompareTag("Coin Silver") || other.gameObject.CompareTag("Coin Gold")) && isEnemyBodyTouched == false)
        {
            //Détruit le GO représentant la pièce
            Destroy(other.gameObject);

            //Ajoute un point au score
            coinsCount++;
            
            //Affiche le score
            coinsText.text = coinsCount.ToString();

            //Joue un son de collecte de pièce
            collectionSound.Play();

            //Sauvegarde le nouveau score en écrasant la valeur précédente du PlayerPref
            PlayerPrefs.SetInt("CoinsScore", coinsCount);

            //DEBUG LAISSER EN COMM'
            //Affiche en console la valeur du PlayerPref
            //Debug.Log("save réussie nb coins collectés: "+ PlayerPrefs.GetInt("CoinsScore"));
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //Si le GO touché par le personnage est un corps d'ennemi
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            isEnemyBodyTouched = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            isEnemyBodyTouched = false;
        }
    }
}
