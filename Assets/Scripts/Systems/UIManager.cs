using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace WM.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Settings Panel")]
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private Button settingButton;
        [SerializeField] private Button homeButton;
        [SerializeField] private Button quitButton;

        private void OnEnable()
        {
            settingButton.onClick.AddListener(OnSettingButton);
            homeButton.onClick.AddListener(OnHomeButton);
            quitButton.onClick.AddListener(OnQuitButton);
        }

        private void OnDisable()
        {
            settingButton.onClick.RemoveListener(OnSettingButton);
            homeButton.onClick.RemoveListener(OnHomeButton);
            quitButton.onClick.RemoveListener(OnQuitButton);
        }

        private void OnSettingButton()
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf);
        }

        private void OnHomeButton()
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Loading MainMenu");
        }   

        private void OnQuitButton()
        {
            Debug.Log("Quitting Application");
            Application.Quit();
        }
    }
}
