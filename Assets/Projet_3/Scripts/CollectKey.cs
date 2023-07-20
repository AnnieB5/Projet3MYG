using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{
    [SerializeField] private GameObject doorGO;
    [SerializeField] private AudioSource collectedKeySound;
    [SerializeField] private AudioSource openedDoorSound;
    [HideInInspector] public bool isOpenDoor;
    private MeshRenderer meshRendererKey;
    private MeshRenderer[] meshesRenderer;

    void Start()
    {
        meshRendererKey = GetComponent<MeshRenderer>();

        //Récupère tous les Transform du GO concerné ainsi que tout ceux de ses enfants (activés seulement)
        meshesRenderer = doorGO.GetComponentsInChildren<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        //Si le GO touché est le personnage et que la porte est fermée
        if (other.gameObject.CompareTag("Player") && isOpenDoor == false)
        {
            //Joue un son de collecte de la clé
            collectedKeySound.Play();

            //Joue un son d'ouverture de porte (lointain)
            openedDoorSound.Play();

            //Désactive l'apparence (seulement) de la porte (GO) et de ses enfants qui forment le motif de la clé
            foreach (MeshRenderer mesh in meshesRenderer)
            {
                mesh.enabled = false;
            }

            //Active la téléportation au contact de la porte (voir script "Finish")
            isOpenDoor = true;

            //Désactive l'apparence de la clé (seulement)
            meshRendererKey.enabled = false;
        }
    }
}
