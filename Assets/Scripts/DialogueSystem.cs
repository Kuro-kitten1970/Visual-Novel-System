using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using System;

public class DialogueSystem : MonoBehaviour
{
    [Header("Dialogue Boxes")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject choiceBox1;
    [SerializeField] private GameObject choiceBox2;

    [Header("Text in the boxes")]
    [SerializeField] private TMP_Text _charName;
    [SerializeField] private TMP_Text _dialogue;
    [SerializeField] private TMP_Text _choice1;
    [SerializeField] private TMP_Text _choice2;

    [Header("Properties")]
    [SerializeField, Range(0.1f, 1f)] float _textSpeed;

    SceneController sceneController;
    DataReader dataReader;

    private void Awake()
    {
        sceneController = gameObject.GetComponent<SceneController>();
        dataReader = gameObject.GetComponent<DataReader>();
    }

    private void Start()
    {
        DisplayDialogue();
    }

    public void DisplayDialogue()
    {
        StartCoroutine(PlayDialogue(dataReader.dataStruct));
    }

    private IEnumerator PlayDialogue(List<DataStruct> values)
    {
        for (int i = 0; i < values.Count; i++)
        {
            _dialogue.text = "";
            _charName.text = values[i].CharName;

            foreach (char c in values[i].Dialogue.ToCharArray())
            {
                _dialogue.text += c;
                yield return new WaitForSeconds(_textSpeed);
            }

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            //yield return null;
        }

        dialogueBox.SetActive(false);
        dataReader.dataStruct.Clear();
        sceneController.NextScene();
    }
}
