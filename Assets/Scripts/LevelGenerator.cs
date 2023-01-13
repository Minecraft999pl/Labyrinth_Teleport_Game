using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefarb[] colorMappings;
    public float offset = 5f;
    public Material material01;
    public Material material02;

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x,z);

        if(pixelColor.a == 0)
        {
            return;
        }

        foreach(ColorToPrefarb colorMapping in colorMappings)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                if(!colorMapping.isSpecial)
                {
                    Vector3 position = new Vector3(x, 0 ,z) * offset;
                    Instantiate(colorMapping.prefarb, position, Quaternion.identity, transform);
                    colorMapping.pixelsLeft--;
                    return;
                }
                else
                {
                    int timesSkipped = 0;
                    foreach(var tileNum in colorMapping.tileNums)
                    {
                        if(tileNum.Equals(colorMapping.pixelsLeft))
                        {
                            Vector3 position = new Vector3(x, 0 ,z) * offset;
                            Instantiate(colorMapping.specialTile, position, Quaternion.identity, transform);
                            colorMapping.pixelsLeft--;
                        }
                        else if(!tileNum.Equals(colorMapping.pixelsLeft) && timesSkipped == colorMapping.tileNums.Count - 1)
                        {
                            Vector3 position = new Vector3(x, 0 ,z) * offset;
                            Instantiate(colorMapping.prefarb, position, Quaternion.identity, transform);
                            colorMapping.pixelsLeft--;
                        }
                        else
                        {
                            timesSkipped++;
                        }
                    }  
                }    
            }
        }
    }

    public void GenerateLabyrinth()
    {
        foreach(ColorToPrefarb colorMapping in colorMappings)
        {
            colorMapping.pixelNum = 0;
            colorMapping.pixelsLeft = 0;
            colorMapping.specialNum = colorMapping.specialMax;
            colorMapping.tileNums.Clear();
        }
        
        for(int x = 0; x < map.width; x++)
        {
            for(int z = 0; z < map.height; z++)
            {
                CountPixels(x, z);
            }
        }

        foreach(ColorToPrefarb colorMapping in colorMappings)
        {
            if(colorMapping.specialMax > colorMapping.pixelNum)
            {
                GameManager.gameManager.ErrorPanel.SetActive(true);
            }
            else
            {   
                GameManager.gameManager.ErrorPanel.SetActive(false);
                while(colorMapping.specialMax > colorMapping.tileNums.Count)
                {
                    GetTileNums();
                }
            }
        }

        for(int x = 0; x < map.width; x++)
        {
            for(int z = 0; z < map.height; z++)
            {
                GenerateTile(x, z);
                ColorTheChildren();
            }
        }
    }

    void CountPixels(int x, int z)
    {
         Color pixelColor = map.GetPixel(x,z);

        foreach(ColorToPrefarb colorMapping in colorMappings)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                colorMapping.pixelNum++;
                colorMapping.pixelsLeft++;
            }
        }
    }

    void GetTileNums()
    {
        foreach(ColorToPrefarb colorMapping in colorMappings)
        {
            if(colorMapping.specialNum >= 1)
            {
                int num = Random.Range(1, colorMapping.pixelNum + 1);
                if(!colorMapping.tileNums.Contains(num))
                {
                    colorMapping.tileNums.Add(num);
                    colorMapping.specialNum--;
                }
            }
        }
    }

    public void ColorTheChildren()
    {
        foreach(Transform child in transform)
        {
            if(child.tag == "Wall")
            {
                if(Random.Range(1,100) % 3 == 0)
                {
                    child.gameObject.GetComponent<Renderer>().material = material02;
                }
                else
                {
                    child.gameObject.GetComponent<Renderer>().material = material01;
                }
            }
            
            if(child.childCount > 0)
            {
                foreach(Transform grandchild in child.transform)
                {
                    if(grandchild.tag == "Wall")
                    {
                        if(Random.Range(1, 100) % 3 == 0)
                        {
                            grandchild.gameObject.GetComponent<Renderer>().material = material02;
                        }
                        else
                        {
                            grandchild.gameObject.GetComponent<Renderer>().material = material01;
                        }
                    }
                }
            }
        }

    }
}
