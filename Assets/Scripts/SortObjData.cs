using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName="Data", menuName="SortObject/CreateData")]
public class SortObjsDataList : ScriptableObject
{
    public int count;
     public List<ObjData> ObjsData = new List<ObjData>(); 
}

[Serializable]
public class ObjData
{
    public string Name;
    public float Scale;
    public float Value;
    public Color Color;
    public GameObject GameObject;

    public ObjData(string name, float scale, float value, Color color, GameObject gameObject)
    {
        this.Name = name;
        this.Scale = scale;
        this.Value = value;
        this.Color = color;
        this.GameObject = gameObject;
    }

}
