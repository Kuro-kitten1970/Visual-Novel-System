using System;

[Serializable]
public class DataStruct
{
    public string CharName;
    public string Dialogue;
    public string Expression;
    public string Choice1;
    public string Choice2;

    public DataStruct(string name, string dialogue, string expression, string choice1, string choice2)
    {
        CharName = name;
        Dialogue = dialogue;
        Expression = expression;
        Choice1 = choice1;
        Choice2 = choice2;
    }
}
