using UnityEngine;

public interface IPeopleGenerator
{
    // Takes stats and generates an array of GameObjects (People)
    public GameObject[] GeneratePeople(CityStats stats);
}
