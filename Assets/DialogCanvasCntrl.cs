using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogCanvasCntrl : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private List<String> _dialogList;

    public UnityEvent StartGame = new();
    private void Start()
    {
        StartCoroutine(DialogAnimate());
    }

    private IEnumerator DialogAnimate()
    {
        var temp = "";
        foreach (var dialog in _dialogList)
        {
            temp = dialog;
            foreach (var letter in temp)
            {
                _text.text += letter;
                yield return new WaitForSeconds(UnityEngine.Random.Range(0.01f, 0.1f));
            }
            yield return new WaitForSeconds(1);
            
            int dialogSize = temp.Length;
            for (int i = 0; i <= dialogSize; i++)
            {
                _text.text = temp.Substring(0,dialogSize - i);
                yield return new WaitForSeconds(UnityEngine.Random.Range(0.01f, 0.03f));
            }
        }
        StartGame.Invoke();
    }
}
