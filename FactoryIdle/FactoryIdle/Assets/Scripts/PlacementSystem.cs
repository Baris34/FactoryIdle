using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject mouseIndicator,cellIndicator;
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private Grid grid;

    public List<Vector3> machineList;
    private GameObject machine;
    [SerializeField] private GameObject machinePrefab;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        //mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
        
    }

    private void Start()
    {
        machineList = PlayerPrefsExtra.GetList<Vector3>("Konumlar");
        InstantiateFabrikalar();
    }
    void InstantiateFabrikalar()
    {
        
        foreach (Vector3 konum in machineList)
        {
            Instantiate(machinePrefab, konum, Quaternion.identity);
        }
    }


    void SaveFabrikaKonumlar()
    {
        // Fabrika konumlarını PlayerPrefs'e kaydet
        string json = JsonUtility.ToJson(machineList);
        PlayerPrefs.SetString("FabrikaKonumlar", json);
        PlayerPrefs.Save();
    }
    
    private void OnEnable()
    {
        InputManager.onClicked += InputManager_onClicked;
    }

    private void InputManager_onClicked()
    {
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        if ((PlayerManager.Instance.totalGold>=PlayerManager.Instance.factoryPrice)&&(!isThereAnyFactory(mousePosition)))
        {
            
            PlayerManager.Instance.totalGold -= PlayerManager.Instance.factoryPrice;
            Instantiate(machinePrefab,grid.CellToWorld(gridPosition),quaternion.identity);
            
            machineList.Add(grid.CellToWorld(gridPosition));
            PlayerPrefsExtra.SetList("Konumlar",machineList);
            PlayerManager.Instance.factoryPrice += 200;
            FactoryManager.Instance.totalFactory += 1;
            PlayerPrefs.SetInt("totalFactory",FactoryManager.Instance.totalFactory);
            PlayerPrefs.SetInt("factoryPrice",PlayerManager.Instance.factoryPrice);
            UIManager.Instance.setMaliyetText(PlayerManager.Instance.factoryPrice);

        }
        
    }

    private void OnDisable()
    {
        InputManager.onClicked -= InputManager_onClicked;
    }

    private bool isThereAnyFactory(Vector3 gridPosition)
    {
        Collider[] colliders = Physics.OverlapSphere(gridPosition, 0.5f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Fabrika")) 
            {
                return true; 
            }
        }

        return false;
    }
    
    
    
    
}
