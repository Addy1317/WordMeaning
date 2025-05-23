#region Summary
///<summary>
///UI Manager script for Game's UI
///</summary>
#endregion
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WM.Services;

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

        private void Start()
        {
            ButtonHoverEffect();
        }

        private void ButtonHoverEffect()
        {
            GameService.Instance.vFXManager.AddHoverEffect(settingButton);
            GameService.Instance.vFXManager.AddHoverEffect(homeButton);
            GameService.Instance.vFXManager.AddHoverEffect(quitButton);
        }

        private void OnSettingButton()
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf);
            GameService.Instance.audioManager.PlaySFX(SFXType.OnButtonClick);
        }

        private void OnHomeButton()
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Loading MainMenu");
            GameService.Instance.audioManager.PlaySFX(SFXType.OnButtonClick);
        }

        private void OnQuitButton()
        {
            Debug.Log("Quitting Application");
            Application.Quit();
            GameService.Instance.audioManager.PlaySFX(SFXType.OnButtonClick);
        }
    }
}
