using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Manager for UI Menus. This singleton keeps track of the open menus to close them in order
/// </summary>
public class MenuManager : MonoBehaviour {

    public Dictionary<string, Menu> menus;
    public Stack<Menu> openMenus;
    
    /// <summary>
    /// True if any menu was closed in the Update operation this frame
    /// </summary>
    public bool aMenuClosedThisFrame;

    public AudioSource audioSource;
    public AudioClip openMenuSfx;
    
    void Start () {
        menus = new Dictionary<string, Menu>();
        openMenus = new Stack<Menu>();
    }

    void Update()
    {
        aMenuClosedThisFrame = false;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseCurrentMenu();
        }
    }

    /// <summary>
    /// Opens a menu by name. The name of a menu is the name of the gameobject that holds the menu script
    /// </summary>
    /// <param name="menuName">Name of the menu to open. This is the name of the gameobject that holds the menu script</param>
    public void OpenMenu(string menuName)
    {
        OpenMenu(menus[menuName]);
    }

    /// <summary>
    /// Opens the specified menu.
    /// </summary>
    /// <param name="menu"></param>
    public void OpenMenu(Menu menu, bool triggerOnOpenEvent)
    {
        if (menu.CanBeOpened())
        {
            if (openMenus.Count > 0)
            {
                openMenus.Peek().cgv.Show(false);

                // If the menu to be opened is on the top of the stack, dont push it again
                if (openMenus.Peek() != menu)
                {
                    openMenus.Push(menu);
                }
            }
            else
            {
                openMenus.Push(menu);
            }
            menu.cgv.Show(true);
            if (triggerOnOpenEvent)
            {
                menu.OnOpened();
            }
        }
    }

    public void OpenMenu(Menu menu)
    {
        OpenMenu(menu, true);
    }

    /// <summary>
    /// Same as OpenMenu but closes one menu before opening the specified one 
    /// </summary>
    /// <param name="menuName"></param>
    /// <param name="force">Force the menus to switch even if their CanBeClosed function returns false</param>
    public void SwitchMenu(string menuName, bool force = false)
    {
        CloseCurrentMenu(force);
        OpenMenu(menuName);
    }

    /// <summary>
    /// Closes the last menu that was opened. This is the only reliable way to close menus.
    /// If you close a menu manually, you need to also update the MenuManager.openMenus Stack to reflect that.
    /// <param name="force">Force the menus to close even if their CanBeClosed function returns false</param>
    /// </summary>
    public void CloseCurrentMenu(bool triggerOnCloseEvent, bool triggerOnOpenEvent, bool force = false) {
        if (openMenus.Count > 0 && (openMenus.Peek().CanBeClosed() || force))
        {
            Menu closedMenu = openMenus.Pop();
            closedMenu.cgv.Show(false);
            if (triggerOnCloseEvent)
            {
                closedMenu.OnClosed();
            }
            aMenuClosedThisFrame = true;
            if (openMenus.Count > 0)
            {
                openMenus.Peek().Open(triggerOnOpenEvent);
            }
        }
    }

    public void CloseCurrentMenu(bool force = false)
    {
        CloseCurrentMenu(true, true, force);
    }

    /// <summary>
    /// Closes all the open menus
    /// <param name="force">Force the menus to close even if their CanBeClosed function returns false</param>
    /// </summary>
    public void CloseAllMenus(bool force = false)
    {
        CloseCurrentMenu(true, false, force);
        while (openMenus.Count > 0 && (openMenus.Peek().CanBeClosed() || force))
        {
            CloseCurrentMenu(false, false, force);
        }
    }

    #region Singleton
    /* Singleton implementation */
    private static MenuManager _instance;
    private MenuManager() { }

    public static MenuManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("No MenuManager instance is present, but its being accessed");
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                DestroyImmediate(this.gameObject);
        }
    }
    #endregion
}
