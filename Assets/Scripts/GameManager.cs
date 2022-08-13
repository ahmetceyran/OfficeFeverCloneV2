using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject BuyDesk1;
    [SerializeField] private GameObject BuyGameObject1;
    [SerializeField] private GameObject BuyArea1;
    [SerializeField] private GameObject BuyDesk2;
    [SerializeField] private GameObject BuyGameObject2;
    [SerializeField] private GameObject BuyArea2;
    [SerializeField] private GameObject BuyDesk3;
    [SerializeField] private GameObject BuyGameObject3;
    [SerializeField] private GameObject BuyArea3;
    [SerializeField] private GameObject BuyPrinter;
    [SerializeField] private GameObject BuyGameObjectPrinter;
    [SerializeField] private GameObject BuyAreaPrinter;

    public int desk1;
    public int desk2;
    public int desk3;
    public int printer;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if(PlayerPrefs.HasKey("desk1"))
        {
            desk1 = PlayerPrefs.GetInt("desk1");
            if(desk1 == 1)
            {
                BuyGameObject1.SetActive(false);
                BuyArea1.SetActive(false);
                BuyDesk1.SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt("desk1",0);
        }

        if(PlayerPrefs.HasKey("desk2"))
        {
            desk2 = PlayerPrefs.GetInt("desk2");
            if(desk2 == 1)
            {
                BuyGameObject2.SetActive(false);
                BuyArea2.SetActive(false);
                BuyDesk2.SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt("desk2",0);
        }

        if(PlayerPrefs.HasKey("desk3"))
        {
            desk3 = PlayerPrefs.GetInt("desk3");
            if(desk3 == 1)
            {
                BuyGameObject3.SetActive(false);
                BuyArea3.SetActive(false);
                BuyDesk3.SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt("desk3",0);
        }

        if(PlayerPrefs.HasKey("printer"))
        {
            printer = PlayerPrefs.GetInt("printer");
            if(printer == 1)
            {
                BuyGameObjectPrinter.SetActive(false);
                BuyAreaPrinter.SetActive(false);
                BuyPrinter.SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt("printer",0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(BuyDesk1.gameObject.activeInHierarchy)
        {
            PlayerPrefs.SetInt("desk1",1);
        }

        if(BuyDesk2.gameObject.activeInHierarchy)
        {
            PlayerPrefs.SetInt("desk2",1);
        }

        if(BuyDesk3.gameObject.activeInHierarchy)
        {
            PlayerPrefs.SetInt("desk3",1);
        }

        if(BuyPrinter.gameObject.activeInHierarchy)
        {
            PlayerPrefs.SetInt("printer",1);
        }
    }
}
