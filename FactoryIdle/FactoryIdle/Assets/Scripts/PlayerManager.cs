using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float totalGold;
    public float totalMine;
    public int totalDiamond;
    public int factoryPrice;
    public float hitMine;
    public float mineIncreasePerSec;
    public float multipliyer;
    private int ilkBasladi=0;
    private void Start()
    {
        
        ilkBasladi = PlayerPrefs.GetInt("ilkBasladi");
        if (ilkBasladi==0)
        {
            ilkBasladi = 1;
            PlayerPrefs.SetFloat("totalGold",100);
            PlayerPrefs.SetFloat("hitMine",1);
            PlayerPrefs.SetFloat("mineIncreasePerSec",1);
            PlayerPrefs.SetFloat("multipliyer",0);
            PlayerPrefs.SetInt("arttirPrice",20);
            PlayerPrefs.SetInt("madenHitPrice",10);
            PlayerPrefs.SetInt("totalFactory",0);
            PlayerPrefs.SetInt("factoryPrice",100);
            PlayerPrefs.SetInt("ilkBasladi",ilkBasladi);
        }
        
            totalGold = PlayerPrefs.GetFloat("totalGold");
            hitMine = PlayerPrefs.GetFloat("hitMine");
            multipliyer = PlayerPrefs.GetFloat("multipliyer");
            mineIncreasePerSec = PlayerPrefs.GetFloat("mineIncreasePerSec");
            MadenManager.Instance.arttirPrice = PlayerPrefs.GetInt("arttirPrice");
            MadenManager.Instance.madenHitPrice = PlayerPrefs.GetInt("madenHitPrice");
            FactoryManager.Instance.totalFactory = PlayerPrefs.GetInt("totalFactory");
            totalMine = PlayerPrefs.GetFloat("totalMine");
            factoryPrice=PlayerPrefs.GetInt("factoryPrice", factoryPrice);
            
        totalDiamond = 0;
        
    }

    private static PlayerManager instance;
    
    public static PlayerManager Instance
    {
        get
        {
            if (instance==null)
            {
                instance = FindObjectOfType<PlayerManager>(true);

            }

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    
    
}
