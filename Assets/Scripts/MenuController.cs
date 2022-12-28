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
        OpenOnePanel(PanelType.Main, false);
    }

    public void ChangeScene(string _sceneName)
    {
        manager.ChangeScene(_sceneName);
    }

    private void OpenOnePanel(PanelType _type, bool _animate)
    {
        foreach (MenuPanel _panel in panelsList) _panel.ChangeState(_animate, false);
        if(_type != PanelType.None) panelsDictionary[_type].ChangeState(_animate, true);
    }
    
    public void OpenPanel(PanelType _type)
    {
        OpenOnePanel(_type, true);
    }
    
    public void Restart()
    {
        
    }
    
    public void Quit()
    {
        manager.Quit();
    }
}