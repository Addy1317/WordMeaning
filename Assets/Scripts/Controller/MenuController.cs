using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace WM
{
    public class MenuController : MonoBehaviour
    {
        [Header("Menu Buttons")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button settingButton;
        [SerializeField] private Button quitButton;

        [Header("Settings Panel")]
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private Button settingsCloseButton;

        private void OnEnable()
        {
            startButton.onClick.AddListener(OnStartButton);
            settingButton.onClick.AddListener(OnSettingsButton);
            quitButton.onClick.AddListener(OnQuitButton);

            settingsCloseButton.onClick.AddListener(OnSettingsCloseButton);
        }

        private void OnDisable()
        {
            startButton.onClick.RemoveListener(OnStartButton);
            settingButton.onClick.RemoveListener(OnSettingsButton);
            quitButton.onClick.RemoveListener(OnQuitButton);

            settingsCloseButton.onClick.RemoveListener(OnSettingsCloseButton);
        }

        private void OnStartButton()
        {
            SceneManager.LoadScene("MainGame");
        }

        private void OnSettingsButton()
        {   
            settingsPanel.SetActive(true);
        }

        private void OnQuitButton()
        {
            Application.Quit();
        }

        private void OnSettingsCloseButton()
        {
            settingsPanel.SetActive(false);
        }

    }
}
