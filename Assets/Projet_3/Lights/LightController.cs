using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private GameObject lightGO;
    [SerializeField] private GameObject[] lightGOArray;


    // Start is called before the first frame update
    void Start()
    {
        ResetLights(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Player"))
        return;

        ResetLights(false);
        //lightGO.SetActive(false);

        //foreach (GameObject light in lightGOArray)
        //{
        //    light.SetActive(true);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.gameObject.CompareTag("Player"))
        return;

        ResetLights(true);
    }

    private void ResetLights(bool oneBigLight)
    {
        lightGO.SetActive(oneBigLight);

        foreach (GameObject light in lightGOArray)
        {
            light.SetActive(!oneBigLight);
        }
    }


}
