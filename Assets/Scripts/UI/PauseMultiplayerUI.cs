using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMultiplayerUI : MonoBehaviour
{
    void Start()
    {
        KitchenGameManager.Instance.OnMultiplayerGamePaused += KitchenGameManager_OnMultiplauerGamePaused;
        KitchenGameManager.Instance.OnMultiplayerGameUnpaused += KitchenGameManager_OnMultiplauerGameUnpaused;

        Hide();
    }

    private void KitchenGameManager_OnMultiplauerGamePaused(object sender, System.EventArgs e) {
        Show();
    }

    private void KitchenGameManager_OnMultiplauerGameUnpaused(object sender, System.EventArgs e) {
        Hide();
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }
}
