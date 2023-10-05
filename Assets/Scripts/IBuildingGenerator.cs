using UnityEngine;

public interface IBuildingGenerator
{
    public GameObject GenerateBuilding(CityStats stats,
        BuildingType type);
}
