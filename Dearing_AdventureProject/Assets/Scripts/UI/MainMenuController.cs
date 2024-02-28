using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject titlePanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject questPanel;




    Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();

    void Start()
    {
        panels.Add("TitlePanel", titlePanel);
        panels.Add("SettingsPanel", settingsPanel);
        panels.Add("QuestPanel", questPanel);

        SwitchPanel("TitlePanel");

    }

    // Update is called once per frame
    void Update()
    {

    }


    void SwitchPanel(string panelName)
    {
        string currentPanelName;
        foreach (var panel in panels)
        {
            if (panel.Key == panelName)
            {
                panel.Value.SetActive(true);
                currentPanelName = panelName;
            }
            else
            {
                panel.Value.SetActive(false);
            }
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gym");
    }

    public void BackToMainMenu()
    {
        SwitchPanel("TitlePanel");
    }

    public void SwitchToQuestPanel()
    {
        SwitchPanel("QuestPanel");
    }
    public void SwitchToSettingsPanel()
    {
        SwitchPanel("SettingsPanel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
