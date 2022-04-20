using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

 
public class FileReader : MonoBehaviour
{
    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text = " "; // assigned to allow first line to be read below
    List<List<List<decimal>>> NeuralNetwork = new List<List<List<decimal>>>();  
    void Start () {
        int layernum = -1;
        int count = 0;

        theSourceFile = new FileInfo ("../Connect4 AI/Assets/Weights/Weights.txt");
        reader = theSourceFile.OpenText();
        CultureInfo provider = new CultureInfo("en-US");

        bool flag = true;
        while(flag){

            text = reader.ReadLine();
            if(text == "NewLayer"){

                NeuralNetwork.Add(new List<List<decimal>>());
                layernum++;
                count = 0;
            } else if(text == "End") {
                flag = false;
            }else{

                String[] tempstringarray = text.Split(',');
                NeuralNetwork[layernum].Add(new List<decimal>());
                //decimal[] temparray = tempstringarray.Select(x => decimal.Parse(x));
                for(int i = 0; i < tempstringarray.Length; i++){
                    NeuralNetwork[layernum][count].Add(decimal.Parse(tempstringarray[i], NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, provider));
                }
                count++;
            }
            
        }
        for (int i = 0; i < NeuralNetwork.Count; i++)
        {
            for (int j = 0; j <NeuralNetwork[i].Count; j++)
            {
                for (int k = 0; k < NeuralNetwork[i][j].Count; k++)
                {
                    decimal s = NeuralNetwork[i][j][k];
                }
            }
        }

    }
    void Update () {
    }
}
