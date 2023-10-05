using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour, IBuildingGenerator
{
    [SerializeField] private GameObject[] residentialBuildings;
    [SerializeField] private CityStats[] residentialBuildingStats;
    [SerializeField] private GameObject[] industrialBuildings;
    [SerializeField] private CityStats[] industrialBuildingStats;
    [SerializeField] private GameObject[] commercialBuildings;
    [SerializeField] private CityStats[] commercialBuildingStats;
    [SerializeField] private GameObject[] infrastructureBuildings;
    [SerializeField] private CityStats[] infrastructureBuildingStats;
    [SerializeField] private GameObject[] entertainmentBuildings;
    [SerializeField] private CityStats[] entertainmentBuildingStats;

    //void Start()
    //{
    //    CityStats stats = new CityStats();
    //    stats.Globalism = 0.9f;
    //    stats.Urbanism = 0.9f;
    //    stats.Statism = 0.9f;
    //    stats.Innovation = 0.9f;
    //    stats.Markets = 0.9f;
    //
    //    GameObject building = GenerateBuilding(stats, BuildingType.Industrial);
    //    Instantiate(building, transform);
    //}
    
    public GameObject GenerateBuilding(CityStats stats, BuildingType type)
    {
        GameObject building = null;
        switch (type)
        {
            case BuildingType.Residential:
            {
                building = findClosestBuilding(stats, residentialBuildingStats, residentialBuildings );
                break;
            }
            case BuildingType.Industrial:
            {
                building = findClosestBuilding(stats, industrialBuildingStats, industrialBuildings);
                break;
            }
            case BuildingType.Commercial:
            {
                building = findClosestBuilding(stats, commercialBuildingStats, commercialBuildings);

                break;
            }
            case BuildingType.Infastructure:
            {
                building = findClosestBuilding(stats, infrastructureBuildingStats, infrastructureBuildings);

                break;
            }
            case BuildingType.Entertainment:
            {
                building = findClosestBuilding(stats, entertainmentBuildingStats, entertainmentBuildings);

                break;
            }
        }

        return building;
    }

    public GameObject findClosestBuilding(CityStats stats, CityStats[] anyBuildingsStats, GameObject[] AnyBuildings )
    {
        double bestDiff = 5;
        GameObject closestBuilding = null;
        int iteration = 0;
        foreach (CityStats buildingStats in anyBuildingsStats ) {
            double globalismDiff = System.Math.Abs(stats.Globalism - buildingStats.Globalism);
            double urbanismDiff = System.Math.Abs(stats.Urbanism - buildingStats.Urbanism);
            double statismDiff = System.Math.Abs(stats.Statism - buildingStats.Statism);
            double innovationDiff = System.Math.Abs(stats.Innovation - buildingStats.Innovation);
            double marketsDiff = System.Math.Abs(stats.Markets - buildingStats.Markets);

            double totalDiff = globalismDiff + urbanismDiff + statismDiff + innovationDiff + marketsDiff;
            
            if (totalDiff < bestDiff)
            {
                bestDiff = totalDiff;
                closestBuilding = AnyBuildings[iteration];
                // implement something which then saves the corresponding building from AnyBuildings at the correct position.
            }

            iteration++;
        }

        return closestBuilding;

    }
    
    //loading each of the files
    
    
    
    // public void LoadBuilding(string type)
    // {
    //     Resources.Load(type + ".blend");
    // }
}
