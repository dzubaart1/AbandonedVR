using System.Collections.Generic;
using UnityEngine;

public class MountainGenerator : MonoBehaviour
{
    [SerializeField] private int _maxLevel;
    [SerializeField] private GameObject _grassPrefab;

    private void Start()
    {
        for (var i = 0; i < _maxLevel; i++)
        {
            var list = GeneratePoints(i, transform.position);
            foreach (var point in list)
            {
                Instantiate(_grassPrefab, point, _grassPrefab.transform.rotation, transform);
            }
        }
    }

    private List<Vector3> GeneratePoints(int level, Vector3 startPos)
    {
        var resList = new List<Vector3>();
        for (var i = 0; i < level*2; i++)
        {
            resList.Add(new Vector3(startPos.x - level + i, startPos.y - level, startPos.z - level));
            resList.Add(new Vector3(startPos.x + level - i, startPos.y - level, startPos.z + level));
            resList.Add(new Vector3(startPos.x + level, startPos.y - level, startPos.z - level + i));
            resList.Add(new Vector3(startPos.x - level, startPos.y - level, startPos.z + level - i));
        }

        return resList;
    }
}
