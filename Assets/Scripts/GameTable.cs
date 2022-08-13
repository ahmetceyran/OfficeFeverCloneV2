using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTable : MonoBehaviour
{
    [SerializeField] private GameObject Worker1;
    private float timer;
    private float timeDelay;

    void Start()
    {
        timer = 0f;
        timeDelay = 15f;
    }

    
    void Update()
    {
        timer = timer + 1f * Time.deltaTime;

        if(timer >= timeDelay)
        {
            timer = 0f;
            Worker1.GetComponent<WorkerManager>().enabled = false;
        }

    }
}
