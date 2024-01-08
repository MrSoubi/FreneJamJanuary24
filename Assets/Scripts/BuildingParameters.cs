using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingParameter", menuName = "ScriptableObjects", order = 1)]

public class BuildingParameters : ScriptableObject
{
    public int hitPoints;
    public int experiencePoints;
    public int rank;

    public List<Material> materials; // From intact to destroyed
}
