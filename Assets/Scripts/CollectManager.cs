using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    [SerializeField] private GameObject paper;
    [SerializeField] private Transform colllectPoint;
    public Vector3 sizeChange;

    int paperLimit = 10;
    
    private void OnEnable()
    {
        TriggerManager.OnPaperCollect += GetPaper;
        TriggerManager.OnPaperGive += GivePaper;
    }

    private void OnDisable()
    {
        TriggerManager.OnPaperCollect -= GetPaper;
        TriggerManager.OnPaperGive -= GivePaper;
    }

    void GetPaper()
    {
        if(paperList.Count <= paperLimit)
        {
            GameObject temp = Instantiate(paper,colllectPoint);
            temp.transform.localScale = temp.transform.localScale + sizeChange;
            temp.transform.position = new Vector3(colllectPoint.position.x, 0.5f+((float)paperList.Count/65), colllectPoint.position.z);
            paperList.Add(temp);
            if(TriggerManager.printerManager != null)
            {
                TriggerManager.printerManager.RemoveLast();
            }
        }
    }

    void GivePaper()
    {
        if(paperList.Count > 0)
        {
            TriggerManager.workerManager.GetPaper();
            RemoveLast();
        }
    }

    public void RemoveLast()
    {
        if (paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
    }

}
