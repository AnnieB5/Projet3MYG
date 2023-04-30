using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int coinsCount = 0;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private AudioSource collectionSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin Random") || other.gameObject.CompareTag("Coin Bronze") || other.gameObject.CompareTag("Coin Silver") || other.gameObject.CompareTag("Coin Gold"))
        {
            Destroy(other.gameObject);
            coinsCount++;
            coinsText.text = "Coins: " + coinsCount;
            collectionSound.Play();
        }
    }
}
