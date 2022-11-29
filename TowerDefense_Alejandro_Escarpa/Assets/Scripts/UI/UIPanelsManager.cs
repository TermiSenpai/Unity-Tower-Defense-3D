using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelsManager : MonoBehaviour
{
    [SerializeField] GameObject activePanel;
    [SerializeField] GameObject closeBtn;
    [SerializeField] GameObject roundInfo;

    public void ChangePanel(GameObject panel)
    {
        if (activePanel != null)
            activePanel.SetActive(false);

        closeBtn.SetActive(true);
        roundInfo.SetActive(false);
        activePanel = panel;
        activePanel.SetActive(true);
    }

    public void ClosePanel()
    {
        activePanel.SetActive(false);
        activePanel = null;
        closeBtn.SetActive(false);
        roundInfo.SetActive(true);
    }
}
