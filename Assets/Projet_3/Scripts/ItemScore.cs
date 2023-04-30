using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemScore : MonoBehaviour
{
    private int score = 0;
    private GameObject coinTouchedGO;
    private CoinSelection coinScript;
    [SerializeField] private TMP_Text scoreText;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
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

            //Affiche le nouveau score
            scoreText.text = "Score: " + score;

        }
    }
}
