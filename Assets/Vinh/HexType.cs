using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEditor.SceneTemplate;
using UnityEngine;

using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

public interface HexType
{
    //public Vector2 Coords;
    //public string Type;
    public void GenerateHex(Vector3 Coords);
}

public class HexGen : MonoBehaviour

{
    private HexType hextype;
    private List<int> HexList;
    public void hexlist(int Residential, int Industrial, int Commercial, int Infrastructure,
        int Entertainment, int Greenspace, int Nothing)
    {
        List<int> HexList = listgenerator(Residential, 0);
        HexList.AddRange(listgenerator(Industrial, 1));
        HexList.AddRange(listgenerator(Commercial, 2));
        HexList.AddRange(listgenerator(Infrastructure, 3));
        HexList.AddRange(listgenerator(Entertainment, 4));
        HexList.AddRange(listgenerator(Greenspace, 5));
        HexList.AddRange(listgenerator(Nothing, 6));
        
        this.HexList = HexList;
    }

    public HexType generator(Vector3 coords)
    {
        Debug.Log("seg");
        var Rnd = new System.Random();
        int HexIndex = Rnd.Next(HexList.Count);
        switch (HexList[HexIndex])
        {
            case 0:
                Residential residential = new Residential();
                Debug.Log("res");
                return residential;
            case 1:
                Industrial industrial = new Industrial();
                return industrial;
            case 2:
                Commercial commercial = new Commercial();
                return commercial;
            case 3:
                Infrastructure infrastructure = new Infrastructure();
                return infrastructure;
            case 4:
                Entertainment entertainment = new Entertainment();
                return entertainment;
            case 5:
                Greenspace greenspace = new Greenspace();
                return greenspace;
            case 6:
                Nothing nothing = new Nothing();
                return nothing;
            default:
                break;
        }
        
        return hextype;
    }

    private List<int> listgenerator(int size, int value)
    {
        List<int> l = new List<int>();
        for (int i = 0; i < size; i++)
        {
            l.Add(value);
        }

        return l;
    }
}

public class Residential : HexType
{
    public new void GenerateHex(Vector3 Coords)
    {
        BuildingGenerator bGen = GameObject.Find("GameDirector").GetComponent<GameDirector>().buildingGenerator;
        CityStats stats = GameObject.Find("GameDirector").GetComponent<GameDirector>().s;;
        GameObject building = bGen.GenerateBuilding(stats, BuildingType.Residential);
        GameObject.Find("GameDirector").GetComponent<GameDirector>().MakeBuilding(building, Coords);
        Debug.Log("Residential"+ Coords);
    }
}
public class Industrial : HexType
{
    public new void GenerateHex(Vector3 Coords)
    {
        int i = 10;
        BuildingGenerator bGen = GameObject.Find("GameDirector").GetComponent<GameDirector>().buildingGenerator;
        CityStats stats = GameObject.Find("GameDirector").GetComponent<GameDirector>().s;;
        GameObject building = bGen.GenerateBuilding(stats, BuildingType.Industrial);
        GameObject.Find("GameDirector").GetComponent<GameDirector>().MakeBuilding(building, Coords);
        Debug.Log("Industrial"+ Coords);
    }
}
public class Commercial : HexType
{
    public new void GenerateHex(Vector3 Coords)
    {
        int i = 10;
        BuildingGenerator bGen = GameObject.Find("GameDirector").GetComponent<GameDirector>().buildingGenerator;
        CityStats stats = GameObject.Find("GameDirector").GetComponent<GameDirector>().s;;
        GameObject building = bGen.GenerateBuilding(stats, BuildingType.Commercial);
        GameObject.Find("GameDirector").GetComponent<GameDirector>().MakeBuilding(building, Coords);
        Debug.Log("Commercial"+ Coords);
    }
}
public class Infrastructure : HexType
{
    public new void GenerateHex(Vector3 Coords)
    {
        int i = 10;
        BuildingGenerator bGen = GameObject.Find("GameDirector").GetComponent<GameDirector>().buildingGenerator;
        CityStats stats = GameObject.Find("GameDirector").GetComponent<GameDirector>().s;;
        GameObject building = bGen.GenerateBuilding(stats, BuildingType.Infastructure);
        GameObject.Find("GameDirector").GetComponent<GameDirector>().MakeBuilding(building, Coords);
        Debug.Log("Infrastructure"+ Coords);
    }
}
public class Entertainment : HexType
{
    public new void GenerateHex(Vector3 Coords)
    {
        int i = 10;
        BuildingGenerator bGen = GameObject.Find("GameDirector").GetComponent<GameDirector>().buildingGenerator;
        CityStats stats = GameObject.Find("GameDirector").GetComponent<GameDirector>().s;;
        GameObject building = bGen.GenerateBuilding(stats, BuildingType.Entertainment);
        GameObject.Find("GameDirector").GetComponent<GameDirector>().MakeBuilding(building, Coords);
        Debug.Log("Entertainment"+ Coords);
    }
}
public class Greenspace : HexType
{
    public new void GenerateHex(Vector3 Coords)
    {
        int i = 10;
        BuildingGenerator bGen = GameObject.Find("GameDirector").GetComponent<GameDirector>().buildingGenerator;
        CityStats stats = GameObject.Find("GameDirector").GetComponent<GameDirector>().s;;
        GameObject building = bGen.GenerateBuilding(stats, BuildingType.Residential);
        GameObject.Find("GameDirector").GetComponent<GameDirector>().MakeBuilding(building, Coords);
        Debug.Log("green");
    }
}
public class Nothing : HexType
{
    public new void GenerateHex(Vector3 Coords)
    {
        int i = 10;
        Debug.Log("implement this");
    }
}

