using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DrawStickerFigure("Frippy", 26, "LL");
        DrawStickerFigure("Tay", 25, "A");
    }

    void DrawStickerFigure(string name, int age, string sex)
    {
        Terminal.WriteLine("Hello, my name is " + name + ", my age is " + age);
        Terminal.WriteLine(" o");
        Terminal.WriteLine("/|>");
        Terminal.WriteLine(" " + sex);
        Terminal.WriteLine("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
