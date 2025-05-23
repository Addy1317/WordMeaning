#region Summary
///<summary>
///DictionaryManager script for Fetching Data from API
///</summary>
#endregion
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace WM.dictionary 
{
    public class DictionaryManager : MonoBehaviour
    {
        [Header("API Configuration")]
        private const string API_URL = "https://api.dictionaryapi.dev/api/v2/entries/en/";

        //Method to start fetching meaning for a word.
        public void FetchWordData(string word, Action<WordData> onResult)
        {
            if (string.IsNullOrEmpty(word) || word.Contains(" "))
            {
                Debug.LogWarning("Invalid input. Please enter a single word without spaces.");
                onResult?.Invoke(null);
                return;
            }

            string requestUrl = API_URL + word.ToLower();
            StartCoroutine(RequestDefinitionCoroutine(requestUrl, onResult));
        }

        //Method to Reterive Data 
        private IEnumerator RequestDefinitionCoroutine(string url, Action<WordData> onResult)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
                if (request.result != UnityWebRequest.Result.Success)
#else
            if (request.isNetworkError || request.isHttpError)
#endif
                {
                    Debug.LogError("API Request Failed: " + request.error);
                    onResult?.Invoke(null);
                    yield break;
                }

                string json = request.downloadHandler.text;
                WordApiResponse[] wordEntries = JsonHelper.FromJson<WordApiResponse>(json);

                if (wordEntries != null && wordEntries.Length > 0)
                {
                    WordApiResponse entry = wordEntries[0];

                    string audioUrl = "";
                    if (entry.phonetics != null && entry.phonetics.Length > 0)
                    {
                        audioUrl = entry.phonetics[0].audio;
                    }

                    string definition = "";
                    string example = "";
                    if (entry.meanings != null && entry.meanings.Length > 0 &&
                        entry.meanings[0].definitions != null && entry.meanings[0].definitions.Length > 0)
                    {
                        definition = entry.meanings[0].definitions[0].definition;
                        example = entry.meanings[0].definitions[0].example;
                    }

                    WordData wordData = new WordData(entry.word, definition, example, audioUrl);
                    onResult?.Invoke(wordData);
                }
                else
                {
                    Debug.LogWarning("No definitions found.");
                    onResult?.Invoke(null);
                }
            }
        }
    }
}
