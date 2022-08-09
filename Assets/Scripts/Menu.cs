using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]private GameObject victoryPanel;
    [SerializeField]private GameObject defeatPanel;

    public void OpenVictoryPanel()
    {
        victoryPanel.SetActive(true);
    }

    public void OpenDefeatPanel()
    {
        defeatPanel.SetActive(true);
    }
}
