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
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinsCount++;
            coinsText.text = "Coins: " + coinsCount;
            collectionSound.Play();
        }
    }
}
