using System.Collections.Generic;
using UnityEngine;

public enum PanelType
{
    None,
    Main,
    Options,
}

public class MenuController : MonoBehaviour
{
    private GameManager manager;
    [SerializeField] private List<MenuPanel> panelsList = new();
    private Dictionary<PanelType, MenuPanel> panelsDictionary = new();
    private void Start()
    {
        manager = GameManager.instance;
        foreach(MenuPanel _panel in panelsList)
        {
            if(_panel) panelsDictionary.Add(_panel.GetPanelType(), _panel);
        }
        OpenOnePanel(PanelType.Main);
    }

    public void ChangeScene(string _sceneName)
    {
        manager.ChangeScene(_sceneName);
    }

    private void OpenOnePanel(PanelType _type)
    {
        foreach (MenuPanel _panel in panelsList) _panel.ChangeState(false);
        if(_type != PanelType.None) panelsDictionary[_type].ChangeState(true);
    }
    
    public void OpenPanel(PanelType _type)
    {
        OpenOnePanel(_type);
    }
    
    public void Restart()
    {
        
    }
    
    public void Quit()
    {
        manager.Quit();
    }
}