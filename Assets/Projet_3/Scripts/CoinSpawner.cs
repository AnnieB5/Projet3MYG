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
        //Choisit une valeur pour le type de coin entre 1 et 3 (max exclusif, avec float, en max inclusif)
        chosenCoin = Random.Range(0,coinGO.Length);

        //Génère les GO des pièces du tableau coinGO, selon la position donnée de leurs transform, leurs rotations et leur parent (?)
        Instantiate(coinGO[chosenCoin], transform.position, Quaternion.identity, parent);
    }
}
