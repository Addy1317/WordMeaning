using System.Collections.Generic;
using UnityEngine;
using WM.Audio;
using WM.dictionary;
using WM.Generic;
using WM.UI;
using WM.VFX;

namespace WM.Services
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        [Header("Managers")]
        [SerializeField] internal AudioManager audioManager;
        [SerializeField] internal UIManager uiManager;
        [SerializeField] internal DictionaryManager dictionaryManager;
        [SerializeField] internal VFXManager vFXManager;

        protected override void Awake()
        {
            base.Awake();
            if (Instance == this)
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            InitializeServices();
        }

        private void InitializeServices()
        {
            var services = new Dictionary<string, Object>
            {
            { "AudioManager", audioManager },
            { "UIManager", uiManager },
            { "DictionayManager", dictionaryManager },
            { "VFXManager", vFXManager }
            };

            foreach (var service in services)
            {
                if (service.Value == null)
                {
                    Debug.LogError($"{service.Key} failed to initialize.");
                }
                else
                {
                    Debug.Log($"{service.Key} is initialized.");
                }
            }
        }
    }
}
