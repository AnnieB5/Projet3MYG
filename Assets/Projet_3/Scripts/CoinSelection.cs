using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSelection : MonoBehaviour
{
    [HideInInspector] public int chosenCoin = 0;
    public Material[] materials = new Material[3];
    private Renderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<Renderer>();//lie le component MeshRenderer au script
        chosenCoin = Random.Range(1,4); //choisi une valeur pour le type de coin entre 1 et 3
        ChangeMaterial();
    }

    void ChangeMaterial()
    {
        switch (chosenCoin)
        {
            case 1:
                //Change le material en bronze
                meshRenderer.sharedMaterial = materials[0];
                break;

            case 2:
                //Change le material en argent
                meshRenderer.sharedMaterial = materials[1];
                break;

            case 3:
                //Change le material en or
                meshRenderer.sharedMaterial = materials[2];
                break;  
        }
    }
}
