using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{

    [SerializeField] private WordView wordViewPrefab;
    [SerializeField] private RectTransform wordParent;
    [SerializeField] private List<WordView> allWords;


    [Button]
    public void InitializeWordViews(string[] words)
    {
        for (int i = 0; i < words.Length; i++)
        {
            WordView wordView = Instantiate(wordViewPrefab, transform.position, Quaternion.identity, wordParent);
            wordView.SetText(words[i]);
            allWords.Add(wordView);
        }
    }

    public void CompleteWord(int id)
    {
        allWords[id].Complete();
    }
}
