using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReader : MonoBehaviour
{
    [Header("Database")]
    public TextAsset _textAsset;
    public List<DataStruct> dataStruct;

    private string[] getData;

    private void Awake()
    {
        getData = _textAsset.text.Split('\n');
        ParseText(getData);
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

            DataStruct database = new DataStruct(CharName, Dialogue, Expression, Choice1, Choice2);
            dataStruct.Add(database);
        }
    }
}
