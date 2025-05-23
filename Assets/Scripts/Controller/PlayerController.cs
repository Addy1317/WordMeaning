#region Summary
///<summary>
/// Player Controller script for taking Input and providing Data 
///</summary>
#endregion
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WM.Audio;
using WM.dictionary;
using WM.Services;

namespace WM
{
    public class PlayerController : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private TMP_InputField wordInputField;
        [SerializeField] private Button getMeaningButton;
        [SerializeField] private TMP_Text outputText;

        [Header("External Managers")]
        [SerializeField] private AudioManager audioManager;

        private void Start()
        {
            if (getMeaningButton != null)
            {
                getMeaningButton.onClick.AddListener(OnGetMeaningClicked);
            }
            GameService.Instance.vFXManager.AddHoverEffect(getMeaningButton);
        }

        private void OnDestroy()
        {
            if (getMeaningButton != null)
            {
                getMeaningButton.onClick.RemoveListener(OnGetMeaningClicked);
            }
        }

        //On Clicking Meaning Button
        private void OnGetMeaningClicked()
        {
            string inputWord = wordInputField.text.Trim();

            if (string.IsNullOrEmpty(inputWord) || inputWord.Contains(" "))
            {
                outputText.text = "<color=red>❌ Please enter a single word without spaces.</color>";
                return;
            }

            outputText.text = "<i>Fetching meaning...</i>";

            GameService.Instance.dictionaryManager.FetchWordData(inputWord,OnWordDataReceived);
            GameService.Instance.audioManager.PlaySFX(SFXType.OnButtonClick);
        }

        //On Reciving Word Data
        private void OnWordDataReceived(WordData data)
        {
            if (data == null)
            {
                outputText.text = "<color=red> Could not find definition. Please try another word.</color>";
                return;
            }

            string display = $"<b><size=120%>{data.word}</size></b>\n\n" +
                             $"<b>Definition:</b> {data.definition}\n" +
                             (string.IsNullOrEmpty(data.example) ? "" : $"<b>Example:</b> \"{data.example}\"");

            outputText.text = display;

            if (!string.IsNullOrEmpty(data.audioUrl))
            {
                //audioManager.PlayAudioFromURL(data.audioUrl);
            }
            else
            {
                Debug.LogWarning("No audio available for this word.");
            }
        }
    }
}
