using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ArquiteturaARController : MonoBehaviour
{
    public GameObject menuTop;
    public GameObject menuBottom;
    public GameObject btnShowMenu;
    public GameObject HouseOptionPanel;
    public Toggle toggleRoof;
    public Toggle toggleWalls;
    public Toggle toggleWindows;
    public Toggle toggleDoors;

    private GameObject[] externalWalls;
    private GameObject[] roof;
    private GameObject[] windows;
    private GameObject[] doors;
    private ARPlaneManager m_ARPlaneManager;
    private bool isPlaneActive;

    private void Start()
    {
        m_ARPlaneManager = GetComponent<ARPlaneManager>();
        isPlaneActive = true;
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void HideMenuBar()
    {
        menuTop.SetActive(false);
        menuBottom.SetActive(false);
        btnShowMenu.SetActive(true);
    }

    public void ShowMenuBar()
    {
        menuTop.SetActive(true);
        menuBottom.SetActive(true);
        btnShowMenu.SetActive(false);
    }

    public void DestroyHouseObject()
    {
        CloseHouseOptionPanel();
        toggleWalls.isOn = true;
        toggleRoof.isOn = true;
        toggleDoors.isOn = true;
        toggleWindows.isOn = true;
        Destroy(GameObject.FindGameObjectWithTag("casa"));
    }

    public void ShowRoof(bool value)
    {
        GameObject[] houseObject;
        if (!value)
        {
            houseObject = GameObject.FindGameObjectsWithTag("Teto");
            roof = houseObject;
            foreach (var item in houseObject)
            {
                item.SetActive(false);
            }
        }
        else
        {
            houseObject = roof;
            foreach (var item in houseObject)
            {
                item.SetActive(true);
            }
            roof = null;
        }
    }

    public void ShowExternalWall(bool value)
    {
        GameObject[] houseObject;
        if (!value)
        {
            houseObject = GameObject.FindGameObjectsWithTag("ParedeExterna");
            externalWalls = houseObject;
            foreach (var item in houseObject)
            {
                item.SetActive(false);
            }
        }
        else
        {
            houseObject = externalWalls;
            foreach (var item in houseObject)
            {
                item.SetActive(true);
            }
            externalWalls = null;
        }
    }

    public void ShowWindows(bool value)
    {
        GameObject[] houseObject;
        if (!value)
        {
            houseObject = GameObject.FindGameObjectsWithTag("Janela");
            windows = houseObject;
            foreach (var item in houseObject)
            {
                item.SetActive(false);
            }
        }
        else
        {
            houseObject = windows;
            foreach (var item in houseObject)
            {
                item.SetActive(true);
            }
            windows = null;
        }
    }

    public void ShowDoors(bool value)
    {
        GameObject[] houseObject;
        if (!value)
        {
            houseObject = GameObject.FindGameObjectsWithTag("Porta");
            doors = houseObject;
            foreach (var item in houseObject)
            {
                item.SetActive(false);
            }
        }
        else
        {
            houseObject = doors;
            foreach (var item in houseObject)
            {
                item.SetActive(true);
            }
            doors = null;
        }
    }

    public void ShowHouseOptionPanel()
    {
        if (GameObject.FindGameObjectWithTag("casa"))
        {
            HouseOptionPanel.SetActive(true);
        }
    }

    public void CloseHouseOptionPanel()
    {
        HouseOptionPanel.SetActive(false);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Application.Quit();
        }
    }

    public void TogglePlaneDetection()
    {                
        if (isPlaneActive)
        {
            SetAllPlanesActive(false);
            isPlaneActive = false;
        }
        else
        {
            SetAllPlanesActive(true);
            isPlaneActive = true;
        }
    }

    void SetAllPlanesActive(bool value)
    {
        var planeManager = GetComponent<ARPlaneManager>();
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }
}
