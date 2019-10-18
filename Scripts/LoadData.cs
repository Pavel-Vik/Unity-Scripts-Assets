using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    public List<Vector2> coordinates = new List<Vector2>(); 
    // Start is called before the first frame update
    void Start()
    {
        TextAsset pointsData = Resources.Load<TextAsset>("Default Dataset");
        string[] data = pointsData.text.Split(new char[] { '\n' });

        for (int i = 0;  i < data.Length - 1; i++)
        {
            Vector2 cor = getVector2(data[i]);
            coordinates.Add(cor);
            //Debug.Log(coordinates[i]);
        }
    }

    public Vector2 getVector2(string rString)
    {
        string[] temp = rString.Split(',');
        float x = float.Parse(temp[0]);
        float y = float.Parse(temp[1]);
        Vector2 rValue = new Vector2(x, y);
        return rValue;
    }
}
