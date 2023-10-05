using UnityEngine;
using System;
using System.Collections.Generic;

public class GenerateSpeech : MonoBehaviour
{     [SerializeField] private String[] globalismNouns;
    [SerializeField] private String[] patriotismNouns;
    [SerializeField] private String[] ruralNouns;
    [SerializeField] private String[] urbanismNouns;
    [SerializeField] private String[] libertarianismNouns;
    [SerializeField] private String[] statismNouns;
    [SerializeField] private String[] traditionalismNouns;
    [SerializeField] private String[] innovationNouns;
    [SerializeField] private String[] equalityNouns;
    [SerializeField] private String[] marketsNouns;
    [SerializeField] private String[] positiveAdj;
    
    void Start()
    {
        CityStats stats = new CityStats();
        stats.Globalism = UnityEngine.Random.value;
        stats.Urbanism = UnityEngine.Random.value;
        stats.Statism = UnityEngine.Random.value;
        stats.Innovation = UnityEngine.Random.value;
        stats.Markets = UnityEngine.Random.value;
    }
    
    public String[] GenerateThoughts(CityStats stats, int population)
    {         
        string[] result = new string[population];
        
        for (int i = 0; i < population; i++)
        {             
            List<string> possibleThoughts = new List<string>() { };
            if (stats.Globalism >= 0.5)
            {
                int index = UnityEngine.Random.Range(0, globalismNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                possibleThoughts.Add(globalismNouns[index] + positiveAdj[index2]);

            }             
            else
            {                 
                int index = UnityEngine.Random.Range(0, patriotismNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                possibleThoughts.Add(patriotismNouns[index] + positiveAdj[index2]);
            }             
            if (stats.Urbanism >= 0.5)
            {
                int index = UnityEngine.Random.Range(0, urbanismNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                possibleThoughts.Add(urbanismNouns[index] + positiveAdj[index2]);
            }             
            else
            {
                int index = UnityEngine.Random.Range(0, ruralNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                possibleThoughts.Add(ruralNouns[index] + positiveAdj[index2]);
            }             
            if (stats.Statism >= 0.5)
            {
                int index = UnityEngine.Random.Range(0, statismNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                possibleThoughts.Add(statismNouns[index] + positiveAdj[index2]);
            }             
            else
            {
                int index = UnityEngine.Random.Range(0, libertarianismNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                possibleThoughts.Add(libertarianismNouns[index] + positiveAdj[index2]);
            }             
            if (stats.Innovation >= 0.5)
            {
                int index = UnityEngine.Random.Range(0, innovationNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                possibleThoughts.Add(innovationNouns[index] + positiveAdj[index2]);
            }             
            else
            {
                int index = UnityEngine.Random.Range(0, traditionalismNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                possibleThoughts.Add(traditionalismNouns[index] + positiveAdj[index2]);
            }             
            if (stats.Markets >= 0.5)
            {
                int index = UnityEngine.Random.Range(0, marketsNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                possibleThoughts.Add(marketsNouns[index] + positiveAdj[index2]);
            }             
            else
            {
                int index = UnityEngine.Random.Range(0, equalityNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                possibleThoughts.Add(equalityNouns[index] + positiveAdj[index2]);
            }
            
            result[i] = possibleThoughts[UnityEngine.Random.Range(0, possibleThoughts.Count)];
            
        }   
        
        return result;
    }
} 
