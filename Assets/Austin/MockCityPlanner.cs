using UnityEngine;

public class MockCityPlanner : MonoBehaviour
{
    public CityPlan GenerateCity(CityStats stats)
    {
        CityPlan cityPlan = new CityPlan();
        (Transform, BuildingType)[] buildingRequirements = new (Transform, BuildingType)[3];
        buildingRequirements[0] = (transform, BuildingType.Commercial);
        buildingRequirements[1] = (transform, BuildingType.Residential);
        buildingRequirements[2] = (transform, BuildingType.Industrial);
        cityPlan.BuildingRequirements = buildingRequirements;
        return cityPlan;
    }
}
