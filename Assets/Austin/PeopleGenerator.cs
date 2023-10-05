using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PeopleGenerator : MonoBehaviour, IPeopleGenerator
{
    private int _population = 100;
    [SerializeField] private GameObject personPrefab;
    [SerializeField] private Shader defaultShader;

    public GameObject[] GeneratePeople(CityStats stats)
    {
        _population = 10 + Mathf.RoundToInt(_population * stats.Urbanism);
        GameObject[] people = new GameObject[_population];
        for (int i = 0; i < (_population); i++) {
                people[i] = Instantiate(personPrefab, transform);
        }
        GenerateCharacterColours(stats, people);
        return people;
    }

    public void GenerateCharacterColours(CityStats stats, GameObject[] personObjects)
    {
        Color nativeColour = Random.ColorHSV();
        for (int i = 0; i < _population; i++)
        {
            if (stats.Globalism > Random.value)
            {
                MeshRenderer[] meshes = personObjects[i].GetComponentsInChildren<MeshRenderer>();
                Color color = Random.ColorHSV();
                Material mat = new Material(defaultShader);
                mat.SetColor("_Color", color);
                for (int j = 0; j < meshes.Length; j++)
                {
                    meshes[j].material = mat;
                }
            }
            else
            {
                MeshRenderer[] meshes = personObjects[i].GetComponentsInChildren<MeshRenderer>();
                Color color = Random.ColorHSV();
                Material mat = new Material(defaultShader);
                mat.SetColor("_Color", nativeColour);
                for (int j = 0; j < meshes.Length; j++)
                {
                    meshes[j].material = mat;
                }
            }
        }
    }
}
