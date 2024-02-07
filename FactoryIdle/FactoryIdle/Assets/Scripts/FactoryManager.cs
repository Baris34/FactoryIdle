using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    public int totalFactory;
    private static FactoryManager instance;
    
    public static FactoryManager Instance
    {
        get
        {
            if (instance==null)
            {
                instance = FindObjectOfType<FactoryManager>(true);

            }

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }



    private void Update()
    {
        getFactoryGold();
    }

    public void getFactoryGold()
    {
        PlayerManager.Instance.totalGold += (totalFactory*Time.deltaTime*10);
        PlayerPrefs.SetFloat("totalGold",PlayerManager.Instance.totalGold);
    }
    
    
}
