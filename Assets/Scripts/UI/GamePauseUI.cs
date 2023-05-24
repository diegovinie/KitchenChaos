using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class GamePauseUI : MonoBehaviour {


    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button optionsButton;


    private void Awake() {
        resumeButton.onClick.AddListener(() => {
            KitchenGameManager.Instance.TogglePauseGame();
        });
        mainMenuButton.onClick.AddListener(() => {
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
        optionsButton.onClick.AddListener(() => {
            Hide();
            OptionsUI.Instance.Show(Show);
        });
    }

    private void Start() {
        KitchenGameManager.Instance.OnLocalGamePaused += KitchenGameManager_OnGamePaused;
        KitchenGameManager.Instance.OnLocalGameUnpaused += KitchenGameManager_OnGameUnpaused;

        Hide();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e) {
        Hide();
    }

    private void KitchenGameManager_OnGamePaused(object sender, System.EventArgs e) {
        Show();
    }

    private void Show() {
        gameObject.SetActive(true);

        resumeButton.Select();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}