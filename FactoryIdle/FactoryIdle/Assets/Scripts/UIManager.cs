using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class UIManager : MonoBehaviour
{
    public TMP_Text materyalText;
    public GameObject panel;
    [SerializeField] private TMP_Text GelenMadenText;
    [SerializeField] private TMP_Text kazancText;
    [SerializeField] private TMP_Text goldText;
    private bool panelAcikMi=false;
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance==null)
            {
                instance = FindObjectOfType<UIManager>(true);
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        kazancText.text = MadenManager.Instance.arttirPrice.ToString();
        GelenMadenText.text = MadenManager.Instance.madenHitPrice.ToString();
    }

    private void Update()
    { 
        
        goldText.text = Convert.ToInt32(PlayerManager.Instance.totalGold).ToString();
    }
    public void cameraControl()
    {
        if (CameraManager.Instance.cam.position==new Vector3(-5,25,5))
        {
            fabrikaGec();
        }
        else
        {
            
            madenGec();
        }
    }

    public void madenGec()
    {
        GameManager.Instance.changeState(GameManager.State.Mine);
        CameraManager.Instance.madenCam();
    }
    public void fabrikaGec()
    {
        GameManager.Instance.changeState(GameManager.State.Factory);
        CameraManager.Instance.fabrikaCam();
    }

    public void setGoldText(int value)
    {
        goldText.text = value.ToString();
    }

    public void KazancBtn()
    {
        MadenManager.Instance.KazancArttir();
        kazancText.text = MadenManager.Instance.arttirPrice.ToString();
    }

    public void ShopButton()
    {
        if (!panelAcikMi)
        {
            panelAcikMi = true;
            GameManager.Instance.changeState(GameManager.State.MineShop);
        }
        else
        {
            panelAcikMi = false;
            GameManager.Instance.changeState(GameManager.State.Mine);
        }
    }

    public void GelenMadenBtn()
    {
        MadenManager.Instance.MadenTikArttir();
        GelenMadenText.text = MadenManager.Instance.madenHitPrice.ToString();
    }
    public void Exit()
    {
        panel.SetActive(false);
        panelAcikMi = false;
        GameManager.Instance.changeState(GameManager.State.Mine);

    }
}
