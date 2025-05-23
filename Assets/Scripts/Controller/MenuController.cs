#region Summary
///<summary>
///Menu script for controlling the main menu UI 
///</summary>
#endregion
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WM.Audio;
using WM.VFX;

namespace WM.Menu
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

        [Header("Script Ref")]
        [SerializeField] private AudioManager audioManager;
        [SerializeField] private VFXManager vfxManager;

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

        private void Start()
        {
            ButtonHoverEffect();
        }

        private void ButtonHoverEffect()
        {
            vfxManager.AddHoverEffect(startButton);
            vfxManager.AddHoverEffect(settingButton);
            vfxManager.AddHoverEffect(quitButton);
            vfxManager.AddHoverEffect(settingsCloseButton);
        }

        private void OnStartButton()
        {
            SceneManager.LoadScene("MainGame");
            audioManager.PlaySFX(SFXType.OnButtonClick);
        }

        private void OnSettingsButton()
        {   
            settingsPanel.SetActive(true);
            audioManager.PlaySFX(SFXType.OnButtonClick);
        }

        private void OnQuitButton()
        {
            Application.Quit();
            audioManager.PlaySFX(SFXType.OnButtonClick);
        }

        private void OnSettingsCloseButton()
        {
            settingsPanel.SetActive(false);
            audioManager.PlaySFX(SFXType.OnButtonClick);
        }
    }
}
