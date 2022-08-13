using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyableArea : MonoBehaviour
{
    [SerializeField] private GameObject DeskGameObject;
    [SerializeField] private GameObject BuyGameObject;
    [SerializeField] private Image progressImage;
    [SerializeField] private GameObject BuyArea;
    public float cost;
    private float currentMoney;
    private float progress;

    public void Buy(int coinAmount)
    {
        currentMoney += coinAmount;
        progress = currentMoney/cost;
        progressImage.fillAmount = progress;
        if(progress >= 1)
        {
            BuyGameObject.SetActive(false);
            BuyArea.SetActive(false);
            DeskGameObject.SetActive(true);
        }

    }
}
