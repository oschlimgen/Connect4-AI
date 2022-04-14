using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
 
public class FileReader : MonoBehaviour
{
    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text = " "; // assigned to allow first line to be read below
    List<List<List<float>>> NeuralNetwork = new List<List<List<float>>>();  
    void Start () {
        int layernum = -1;
        int count = 0;
        Debug.Log('a');
        theSourceFile = new FileInfo ("../Connect4 AI/Assets/Weights/Weights.txt");
        reader = theSourceFile.OpenText();
        while(text != null){
            Debug.Log('b');
            text = reader.ReadLine();
            if(text == "NewLayer"){
                Debug.Log('c');
                layernum++;
                count = 0;
            }else{
                Debug.Log('d');
                string[] tempstringarray = text.Split(',');
                //float[] temparray = tempstringarray.Select(x => float.Parse(x));
                for(int i = 0; i < tempstringarray.Length; i++){

                    NeuralNetwork[layernum,count,i] = float.Parse(tempstringarray[i]);
                }

                count++;
            }
            
        }
        for (int i = 0; i < NeuralNetwork.GetLength(0); i++)
        {
            for (int j = 0; j <NeuralNetwork.GetLength(1); j++)
            {
                for (int k = 0; k < NeuralNetwork.GetLength(2); k++)
                {
                    float s = NeuralNetwork[i, j, k ];
                    Debug.Log(s);
                }
            }
        }
        Debug.Log('e');
    }
    void Update () {
    }
}
