using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{
    [SerializeField] private GameObject doorGO;
    [SerializeField] private AudioSource collectedKeySound;
    [SerializeField] private AudioSource openedDoorSound;
    [HideInInspector] public bool isOpenDoor;
    private MeshRenderer meshRenderer;
    [SerializeField] private MeshRenderer meshRendererDoor;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isOpenDoor == false)
        {
            //Joue un son de collecte de la clé
            collectedKeySound.Play();

            //Joue un son d'ouverture de porte (lointain)
            openedDoorSound.Play();

            //Désactive l'apparence de la porte (GO) (seulement)
            meshRendererDoor.enabled = false;

            //Active la téléportation au contact de la porte (voir script "Finish")
            isOpenDoor = true;

            //Désactive l'apparence de la clé (seulement)
            meshRenderer.enabled = false;
        }
    }
}
