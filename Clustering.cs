using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clustering : MonoBehaviour
{
    /// <summary>
    /// Prefab Point
    /// </summary>
    [SerializeField] GameObject prefab;

    /// <summary>
    /// List with all Point
    /// </summary>
    List<GameObject> objList;

    /// <summary>
    /// Distance Between Points
    /// </summary>
    private float distanceBetween = 1.41f;
    void Start()
    {
        objList = new List<GameObject>();

        ///<summery>
        /// Generate Points
        ///</summery>
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(prefab, new Vector2(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f)), Quaternion.identity, transform.parent);
            obj.name = "obj-" + i;
            objList.Add(obj);
        }

        ClusteringService();
    }

    ///<summary>
    /// Clustering Service
    /// </summary>
    public void ClusteringService() 
    {
        for (int i = 0; i < objList.Count; i++)
        {
            for (int j = i + 1; j < objList.Count; j++)
            {
                if (Vector2.Distance(objList[i].transform.position, objList[j].transform.position) <= 1.41)
                {
                    Debug.Log("***" + objList[i].name + " - " + objList[j].name + " : " + Vector2.Distance(objList[i].transform.position, objList[j].transform.position));
                    objList[i].SetActive(false);
                    break;

                }
                else
                {
                    objList[i].SetActive(true);
                    Debug.Log(objList[i].name + " - " + objList[j].name + " : " + Vector2.Distance(objList[i].transform.position, objList[j].transform.position));
                }
            }
        }
    }

   
}
