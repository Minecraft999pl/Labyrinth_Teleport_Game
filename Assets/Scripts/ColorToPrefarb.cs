using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ColorToPrefarb 
{
    public Color color;
    public GameObject prefarb;
    public bool isSpecial;
    public GameObject specialTile;
    public int specialNum;
    public int pixelNum;
    public int pixelsLeft;
    public List<int> tileNums = new List<int>();
    public int specialMax;
}
