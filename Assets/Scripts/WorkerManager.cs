using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WorkerManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    List<GameObject> coinList = new List<GameObject>();
    [SerializeField] private Transform paperPoint;
    [SerializeField] private Transform coinPoint;
    [SerializeField] private GameObject paper;
    [SerializeField] private GameObject Coin;
    [SerializeField] private GameObject Worker;
    [SerializeField] private AudioSource workingFX;

    Animator anim;
    
    private void Start()
    {
        anim = Worker.gameObject.GetComponent<Animator>();
        StartCoroutine(GenerateMoney());
    }

    IEnumerator GenerateMoney()
    {
        while (true)
        {
            if(paperList.Count > 0)
            {
                GameObject temp = Instantiate(Coin);
                temp.transform.position = new Vector3(coinPoint.position.x, 0.2f+((float)coinList.Count / 15), coinPoint.position.z);
                coinList.Add(temp);
                RemoveLast();
            }
            yield return new WaitForSeconds(5f);
        }
        
    }

    public void GetPaper()
    {
        GameObject temp = Instantiate(paper);
        temp.transform.position = new Vector3(paperPoint.position.x, 0.53f+((float)paperList.Count/65), paperPoint.position.z);
        paperList.Add(temp);
        anim.SetBool("working" , true);
        workingFX.Play();
    }

    public void RemoveLast()
    {
        if (paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
        if(paperList.Count <= 0)
        {
            anim.SetBool("working" , false);
            workingFX.Stop();
        }
    }
}
