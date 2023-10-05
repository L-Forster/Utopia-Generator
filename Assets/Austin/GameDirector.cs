using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private Slider globalismSlider;
    [SerializeField] private Slider urbanismSlider;
    [SerializeField] private Slider statismSlider;
    [SerializeField] private Slider innovationSlider;
    [SerializeField] private Slider marketsSlider;
    
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject player;

    [SerializeField] private MockCityPlanner cityPlanner;
    [SerializeField] public BuildingGenerator buildingGenerator;
    [SerializeField] private PeopleGenerator peopleGenerator;
    [SerializeField] private GenerateSpeech speechGenerator;

    [SerializeField] private Vector2 minBound;
    [SerializeField] private Vector2 maxBound;

    [SerializeField] private GameObject thoughtBubble;
    [SerializeField] private Camera mainCamera;

    private List<GameObject> _objects;
    private string[] thoughts;

    public CityStats s;

    public void Start()
    {
        _objects = new List<GameObject>();
        allowThought = true;
    }

    public void OnDone()
    {
        CityStats stats = new CityStats();
        stats.Globalism = globalismSlider.value;
        stats.Urbanism = urbanismSlider.value;
        stats.Statism = statismSlider.value;
        stats.Innovation = innovationSlider.value;
        stats.Markets = marketsSlider.value;
        s = stats;

        mainMenu.SetActive(false);

        GameObject[] people = peopleGenerator.GeneratePeople(stats);
        thoughts = speechGenerator.GenerateThoughts(stats, people.Length);
        for (int i = 0; i < people.Length; i++)
        {
            people[i].transform.position = new UnityEngine.Vector3(UnityEngine.Random.Range(minBound.x, maxBound.x), 0.5f,UnityEngine.Random.Range(minBound.y, maxBound.y));
            people[i].transform.rotation = UnityEngine.Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
        }

        CityPlan cityPlan = cityPlanner.GenerateCity(stats);
        for (int i = 0; i < cityPlan.BuildingRequirements.Length; i++)
        {
            //GameObject buildingPrefab = buildingGenerator.GenerateBuilding(stats, cityPlan.BuildingRequirements[i].Item2);
            //GameObject building = Instantiate(buildingPrefab, cityPlan.BuildingRequirements[i].Item1);
            //building.transform.localScale = new UnityEngine.Vector3(5f, 5f, 5f);
            //building.transform.position = new UnityEngine.Vector3(UnityEngine.Random.Range(minBound.x, maxBound.x), 0.5f,UnityEngine.Random.Range(minBound.y, maxBound.y));
            //building.transform.rotation = UnityEngine.Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
            //building.transform.parent = transform;
            //_objects.Add(building);
        }
        //GameObject road = Instantiate(cityPlan.Road, transform);
        //_objects.Add(road)
        player.SetActive(true);
        mainCamera.gameObject.SetActive(false);
    }

    private bool allowThought;
    private void Update()
    {
        Camera cam = player.GetComponentInChildren<Camera>();
        Debug.DrawLine(cam.transform.position, player.transform.forward);
        
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, 5f)) {
            Debug.Log("Hit");
            if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("Player")) && allowThought)
            {
                Debug.Log("Hit player");
                GameObject thought = Instantiate(thoughtBubble, hit.collider.gameObject.transform);
                thought.transform.GetChild(0).GetChild(0).position = cam.WorldToScreenPoint(hit.collider.gameObject.transform.position + new UnityEngine.Vector3(0, -0.5f, 0));
                thought.GetComponentInChildren<TextMeshProUGUI>().text = thoughts[Random.Range(0, thoughts.Length)];
                allowThought = false;
                StartCoroutine(ExecuteAfterSeconds(() => {Destroy(thought);
                    allowThought = true;
                },3f));
            }
        }
    }

    public void MakeBuilding(GameObject building, Vector3 pos)
    {
        GameObject b = Instantiate(building, transform);
        b.transform.position = pos;
    }
    
    public static IEnumerator ExecuteAfterSeconds(System.Action executable, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        executable();
    }
}
