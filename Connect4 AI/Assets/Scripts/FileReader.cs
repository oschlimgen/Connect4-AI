using UnityEngine;
using System.Collections;
using System;
using System.IO;
 
public class LineReader : MonoBehaviour
{
    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text = " "; // assigned to allow first line to be read below
    float[,] NeuralNetwork;  
    void Start () {
        int layernum = -1;
        int count = 0;
        
        theSourceFile = new FileInfo ("../Weights/Weights.txt");
        reader = theSourceFile.OpenText();
        while(text != null){
            text = reader.ReadLine();
            if(text == "NewLayer"){
                layernum++;
                count = 0;
            }else{
                string[] tempstringarray = text.Split(',');
                float[] temparray = tempstringarray.Select(x => float.Parse(x));
                NeuralNetwork[layernum,count] = temparray;
                count++;
            }
            
        }
    }
   
    void Update () {
    }
}
