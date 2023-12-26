using JetBrains.Annotations;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour, Subcriber
{
    private static UIManager instance;

    public static UIManager getInstance()
    {
        if (instance == null)
        {
            instance = GameObject.FindObjectOfType<UIManager>();
        }
        return instance;
    }

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    [Header("----------MENU----------")]
    public GameObject HUD;
    public GameObject Inventory;
    public GameObject Map;
    public GameObject PauseMenu;
    public GameObject HUD;
    public GameObject Inventory;
    public GameObject Map;

    void Start()
    {
        HUD.SetActive(true);
        Inventory.SetActive(false);
        PauseMenu.SetActive(false);

        updateCurrentMap();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && !Inventory.activeInHierarchy)
        {
            OpenIMenu();
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (Inventory.activeInHierarchy)
            {
                CloseIMenu();
            }
            else
            {
                OpenPauseMenu();
            }
        }
    }

    public void closeAllMenu()
    {
        Inventory.SetActive(false );
        HUD.SetActive(true);
        Inventory.SetActive(false);

        updateCurrentMap();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && !Inventory.activeInHierarchy)
        {
            Inventory.SetActive(true);
            PlayerControl.getInstance().isInteract = true;
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (Inventory.activeInHierarchy)
            {
                Inventory.SetActive(false);
                PlayerControl.getInstance().isInteract = false;
            }
        }
    }

    public void OpenIMenu()
    {
        Inventory.SetActive(true);
        PlayerControl.getInstance().isInteract = true;
    }

    public void CloseIMenu()
    {
        Inventory.SetActive(false);
        PlayerControl.getInstance().isInteract = false;
    }

    public void OpenPauseMenu()
    {
        PauseMenu.SetActive(true);
        GameStateManager.getInstance().setState(Game_State.Pause);
    }

    public void CloseGuideMenu()
    {
        PauseMenu.SetActive(false);
    }

    // Map
    public void addMarker(int id, Vector3 pos)
    {
        Map.GetComponent<MapMenuControler>().addMarker(id, pos);
    }

    public void updateCurrentMap()
    {
        Map.GetComponent<MapMenuControler>().updateCurrentMap(SceneManager.GetActiveScene().buildIndex);
    }

    //subcribe
    public void update(int state)
    {
        if (state == (int)Game_State.BacktoMenu)
        {
            Destroy(this.gameObject);
        }
    }

    public void closeAllMenu()
    {
        Inventory.SetActive(false );
    }

    // Map
    public void addMarker(int id, Vector3 pos)
    {
        Map.GetComponent<MapMenuControler>().addMarker(id, pos);
    }

    public void updateCurrentMap()
    {
        Map.GetComponent<MapMenuControler>().updateCurrentMap(SceneManager.GetActiveScene().buildIndex);
    }
}
