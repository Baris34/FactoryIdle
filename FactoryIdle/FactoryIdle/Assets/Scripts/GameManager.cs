using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private State currentState;
    [SerializeField] private GameObject placement;
    [SerializeField] private GameObject mine;
    
    private void Start()
    {
        changeState(State.Mine);
    }

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance==null)
            {
                instance = FindObjectOfType<GameManager>(true);
            }
            return instance;
        }
    }

   public enum State
    {
        Mine,
        Factory,
        MineShop,
        FactoryShop
    }


    public void changeState(State newState)
    {
        currentState = newState;
        switch (newState)
        {
            case State.Mine:
                placement.GetComponent<PlacementSystem>().enabled = false;
                UIManager.Instance.panel.SetActive(false);

                break;
            case State.Factory:
                placement.GetComponent<PlacementSystem>().enabled = true;
                UIManager.Instance.panel.SetActive(false);


                break;
            case State.MineShop:
                
                UIManager.Instance.panel.SetActive(true);
                break;
            case State.FactoryShop:
                break;
            default:
                break;
        }

    }
}
