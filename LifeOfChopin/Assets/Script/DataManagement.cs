using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

[Serializable]
public class InterestData
{
    public string pointName;
    public int year;
    public string infos;
    public float x;
    public float y;
    public float z;

}

public class AllInterestData
{
    public InterestData[] interestData;

}

public class DataManagement : MonoBehaviour
{
    public string dataFileName;

    public AllInterestData GetData()
    {
        TextAsset dataAsJson = Resources.Load<TextAsset>(dataFileName);
        return JsonUtility.FromJson<AllInterestData>(dataAsJson.text);
    }
}
