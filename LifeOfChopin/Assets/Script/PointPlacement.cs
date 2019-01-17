using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointPlacement : MonoBehaviour
{
    public Camera camera;

    public DataManagement Data;
    private AllInterestData AllData;
    public GameObject PrefabPoint;

    Transform wayPoint;

    public Slider ChangeYear;
    public Text YearAndPlaceInfo;
    public Text YearInfo;
    int SavedYear;

    private List<GameObject> PointList;

    Quaternion _lookRotation;
    Vector3 _lookPosition;


    void Start()
    {
        PointList = new List<GameObject>();

        AllData = Data.GetData();
        foreach(InterestData interest in AllData.interestData)
        {
            GameObject interestPoint = Instantiate(PrefabPoint, new Vector3(interest.x, interest.y, interest.z), Quaternion.identity);
            PointList.Add(interestPoint);
        }
        int LengthSlider = AllData.interestData.Length - 1;
        ChangeYear.maxValue = LengthSlider;

        ChangeYear.onValueChanged.AddListener(delegate { CheckYear(); });
        SavedYear = 0;

        CheckYear();
    }

    void CheckYear()
    {
        SavedYear = Mathf.FloorToInt(ChangeYear.value);

        string formatedText = AllData.interestData[SavedYear].year + " - " + AllData.interestData[SavedYear].pointName;
        YearAndPlaceInfo.text = formatedText;
        YearInfo.text = AllData.interestData[SavedYear].infos;

        rotateTowards(PointList[SavedYear].transform.position);
    }

    void rotateTowards(Vector3 to) {
        _lookPosition = to;
        _lookPosition.z = _lookPosition.z + .45f;
        _lookPosition.y = _lookPosition.y - .1f;
        _lookPosition.x = _lookPosition.x + .2f;
        to.x = to.x + .2f;
        _lookRotation = Quaternion.LookRotation((to - _lookPosition).normalized);
        
    }

    void Update()
    {
        camera.transform.position = Vector3.Lerp(camera.transform.position, _lookPosition, Time.deltaTime * 1);
        camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, _lookRotation, Time.deltaTime * 1);
    }
}
