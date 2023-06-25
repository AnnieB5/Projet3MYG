using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [HideInInspector] public int chosenCoin = 0;
    public GameObject[] coinGO;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        chosenCoin = Random.Range(0,coinGO.Length); //choisi une valeur pour le type de coin entre 1 et 3 (max exclusif, avec float, en max inclusif)
        Instantiate(coinGO[chosenCoin], transform.position, Quaternion.identity, parent);
        
    }

    
}
