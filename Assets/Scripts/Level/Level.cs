using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Scritable Objects/Level")]
public class Level : ScriptableObject
{
    public List<Vector3> obstacle025StartingCoordinates;
    public List<Vector3> obstacle05StartingCoordinates;
    public List<Vector3> collectibleStartingCoordinates;
}
