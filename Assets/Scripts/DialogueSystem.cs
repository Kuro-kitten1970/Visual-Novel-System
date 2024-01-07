using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
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

    [Header("Database")]
    public TextAsset _textAsset;
    List<TextDatabase> textDatabases;
    string[] getData;

    [Header("Properties")]
    [SerializeField, Range(0.1f, 1f)] float _textSpeed;

    SceneController sceneController;

    private void Awake()
    {
        textDatabases = new List<TextDatabase>();
        getData = _textAsset.text.Split('\n');
        ParseText(getData);
        sceneController = gameObject.GetComponent<SceneController>();
    }

    private void Start()
    {
        DisplayDialogue();
    }

    public void DisplayDialogue()
    {
        StartCoroutine(PlayDialogue(textDatabases));
    }

    private IEnumerator PlayDialogue(List<TextDatabase> values)
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
        textDatabases.Clear();
        sceneController.NextScene();
    }

    public void ParseText(string[] lines)
    {
        foreach (string line in lines)
        {
            if (line == "" || line == null) continue;
            if (line.StartsWith("//")) continue;

            string[] extractLine = line.Split(':');
            string CharName = extractLine[0].TrimStart();
            string Dialogue = extractLine[1].TrimStart();
            string Expression = extractLine[2].TrimStart();
            string Choice1 = extractLine[3].TrimStart();
            string Choice2 = extractLine[4].TrimStart();

            TextDatabase database = new TextDatabase(CharName, Dialogue, Expression, Choice1, Choice2);
            textDatabases.Add(database);
        }
    }
}
