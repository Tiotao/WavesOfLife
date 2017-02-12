using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlowPointController : MonoBehaviour {

    public GameObject _glowPaths;
    public GameObject _glowPoint;
    public List<Transform[]> _glowPathWayPoints;
    public int _currentPath = 0;
    public bool _updatePath = true;
    public float _pathTime = 3f;

	// Use this for initialization
	void Start () {
        Transform[] paths = GetComponentsInDirectChildren<Transform>(_glowPaths);
        _glowPathWayPoints = new List<Transform[]>();
        for (int i=0; i < paths.Length; i++)
        {
            Transform[] waypoints = GetComponentsInDirectChildren<Transform>(paths[i].gameObject);
            _glowPathWayPoints.Add(waypoints);
        }
        
        _glowPoint.transform.position = _glowPathWayPoints[0][0].position;
        ScaleSprite();
        RotateSprite();
    }
	
	// Update is called once per frame
	void Update () {
       if (_updatePath)
        {
            Transform[] path = _glowPathWayPoints[_currentPath];
            iTween.MoveTo(_glowPoint, iTween.Hash("path", path, "time", _pathTime, "easeType", iTween.EaseType.easeInOutSine));
            _updatePath = false;
        }
        

    }

    void ScaleSprite(bool isUp = true)
    {
        Vector3 scale;
        if (isUp)
        {
            scale = new Vector3(1.1f, 1.1f, 1.1f);
            isUp = false;
        } else
        {
            scale = new Vector3(1.0f, 1.0f, 1.0f);
            isUp = true;
        }
        float changeTime = Random.Range(0.5f, 1f);
        iTween.ScaleTo(_glowPoint, iTween.Hash("scale", scale, "time", changeTime, "oncomplete", "ScaleSprite", "oncompletetarget", gameObject, "oncompleteparams", isUp, "easetype", iTween.EaseType.easeInOutSine));
    }

    void RotateSprite(bool isClockwise = true)
    {
        float degree;
        if (isClockwise)
        {
            degree = Random.Range(0f, 180f);
            isClockwise = false;
        }
        else
        {
            degree = Random.Range(0f, -180f);
            isClockwise = true;
        }
        float changeTime = Random.Range(5f, 10f);
        iTween.RotateTo(_glowPoint, iTween.Hash("z", degree, "time", changeTime, "oncomplete", "RotateSprite", "oncompletetarget", gameObject, "oncompleteparams", isClockwise, "easetype", iTween.EaseType.easeInOutSine));
    }

    public void NextStage()
    {
        _currentPath = _currentPath + 1;
        _updatePath = true;

    }

    public static T[] GetComponentsInDirectChildren<T>(GameObject gameObject)
    {
        int indexer = 0;

        foreach (Transform transform in gameObject.transform)
        {
            if (transform.GetComponent<T>() != null)
            {
                indexer++;
            }
        }

        T[] returnArray = new T[indexer];

        indexer = 0;

        foreach (Transform transform in gameObject.transform)
        {
            if (transform.GetComponent<T>() != null)
            {
                returnArray[indexer++] = transform.GetComponent<T>();
            }
        }

        return returnArray;
    }
}
