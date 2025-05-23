using UnityEngine;

namespace WM.dictionary
{
    public class WordData 
    {
        public string word;
        public string definition;
        public string example;
        public string audioUrl;

        public WordData(string word, string definition, string example, string audioUrl)
        {
            this.word = word;
            this.definition = definition;
            this.example = example;
            this.audioUrl = audioUrl;
        }
    }

    [System.Serializable]
    public class WordApiResponse
    {
        public string word;
        public Phonetic[] phonetics;
        public Meaning[] meanings;
    }

    [System.Serializable]
    public class Phonetic
    {
        public string text;
        public string audio;
    }

    [System.Serializable]
    public class Meaning
    {
        public string partOfSpeech;
        public Definition[] definitions;
    }

    [System.Serializable]
    public class Definition
    {
        public string definition;
        public string example;
    }
}
