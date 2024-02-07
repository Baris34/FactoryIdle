using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadenManager : MonoBehaviour
{
    
    public int arttirPrice=20;
    public int madenHitPrice = 10;
    private static MadenManager instance;
    public static MadenManager Instance
     {
        get
        {
            if (instance==null)
            {
                instance = FindObjectOfType<MadenManager>(true);
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
        Mine();
        Clicker();
    }

    public void Mine()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit))
            {
                if (hit.collider.gameObject.CompareTag("Maden"))
                {
                    PlayerManager.Instance.totalMine += PlayerManager.Instance.hitMine;
                    PlayerPrefs.SetFloat("totalMine",PlayerManager.Instance.totalMine);
                }
            }
        }
        
    }
    public void Clicker()
    {
        UIManager.Instance.materyalText.text = ((int)PlayerManager.Instance.totalMine).ToString();
        PlayerManager.Instance.mineIncreasePerSec = PlayerManager.Instance.multipliyer * Time.deltaTime;
        PlayerPrefs.SetFloat("mineIncreasePerSec",PlayerManager.Instance.mineIncreasePerSec);
        PlayerManager.Instance.totalMine += PlayerManager.Instance.mineIncreasePerSec;
    }

    public void KazancArttir()
    {
        if (PlayerManager.Instance.totalMine>=arttirPrice)
        {
            PlayerManager.Instance.totalMine -= arttirPrice;
            PlayerManager.Instance.multipliyer += 2;
            arttirPrice += 50;
            PlayerPrefs.SetFloat("multipliyer",PlayerManager.Instance.multipliyer);
            PlayerPrefs.SetInt("arttirPrice",arttirPrice);
        }
    }
    public void MadenTikArttir()
    {
        
        if (PlayerManager.Instance.totalMine>=madenHitPrice)
        {
            PlayerManager.Instance.totalMine -= madenHitPrice;
            PlayerManager.Instance.hitMine += 1;
            PlayerPrefs.SetFloat("hitMine",PlayerManager.Instance.hitMine);
            madenHitPrice += 60;
            PlayerPrefs.SetInt("madenHitPrice",madenHitPrice);
        }
    }
}
