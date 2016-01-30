using UnityEngine;

/// <summary>
/// Base class for UI Menus. All menus should derive form this class so that the MenuManager keeps track of them.
/// The preferred way to open and close menus is by using the MenuManager methods. If you manually open and close
/// menus, the MenuManager.openMenus Stack should be updated to reflect it
/// </summary>
public class Menu : MonoBehaviour {
    [HideInInspector]
    public CanvasGroupVisibility cgv;
    
    public void Start()
    {
        cgv = GetComponent<CanvasGroupVisibility>();
        MenuManager.Instance.menus.Add(this.name, this);
    }

    public void Open()
    {
        Open(true);
    }

    public void Open(bool triggerOnOpenEvent) {
        MenuManager.Instance.OpenMenu(this, triggerOnOpenEvent);
    }

    /// <summary>
    /// Can be implemented by menus to avoid being closed in special cases (like the start menu while in the Start scene)
    /// </summary>
    /// <returns></returns>
    public virtual bool CanBeClosed()
    {
        return true;
    }

    /// <summary>
    /// Can be implemented by menus to avoid being opened in special cases (like the pause menu while in the Start scene)
    /// </summary>
    /// <returns></returns>
    public virtual bool CanBeOpened()
    {
        return true;
    }

    /// <summary>
    /// Override to execute code after the menu is opened
    /// </summary>
    public virtual void OnOpened() {
    }

    /// <summary>
    /// Override to execute code after the menu is closed
    /// </summary>
    public virtual void OnClosed()
    {
        
    }

    public void PlayOpenSfx()
    {
        MenuManager.Instance.audioSource.clip = MenuManager.Instance.openMenuSfx;
        MenuManager.Instance.audioSource.Play();
    }

    static public void DestroyChildren(Transform t)
    {
        bool isPlaying = Application.isPlaying;
        while (t.childCount != 0)
        {
            Transform child = t.GetChild(0);

            if (isPlaying)
            {
                child.SetParent(null);
                Destroy(child.gameObject);
            }
            else DestroyImmediate(child.gameObject);
        }
    }
}
