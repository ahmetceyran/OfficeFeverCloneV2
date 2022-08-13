using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyManager : MonoBehaviour
{
    [SerializeField] private Text CoinsText;
    [SerializeField] private GameObject CoinAnim;
    [SerializeField] private AudioSource CoinCollectFX;
    public int coinCount = 0;

    void Start()
    {
        //PlayerPrefs.DeleteKey("coinCount");
        if(PlayerPrefs.HasKey("coinCount"))
        {
            coinCount = PlayerPrefs.GetInt("coinCount");
            CoinsText.text = coinCount.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("coinCount",0);
            CoinsText.text = PlayerPrefs.GetInt("coinCount").ToString();
        }
    }

    void Update()
    {
        CoinsText.text = "Coins : " + coinCount;
    }

    private void OnEnable()
    {
        TriggerManager.OnCoinCollected += IncreaseCoin;
        TriggerManager.OnBuyingDesk += BuyArea;
    }

    private void OnDisable()
    {
        TriggerManager.OnCoinCollected -= IncreaseCoin;
        TriggerManager.OnBuyingDesk -= BuyArea;
    }

    void BuyArea()
    {
        if(TriggerManager.areaToBuy != null)
        {
            if(coinCount >= 1)
            {
                TriggerManager.areaToBuy.Buy(1);
                coinCount -= 1;
                PlayerPrefs.SetInt("coinCount",coinCount);
            }
        }

    }

    void IncreaseCoin()
    {
        coinCount += 50;
        CoinAnim.SetActive(true);
        CoinCollectFX.Play();
        StartCoroutine(coinAnimWait());
        PlayerPrefs.SetInt("coinCount",coinCount);
    }

    IEnumerator coinAnimWait()
    {
        yield return new WaitForSeconds(0.9f);
        CoinAnim.SetActive(false);
    }
}
