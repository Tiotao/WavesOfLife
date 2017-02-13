using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlowPointController : MonoBehaviour {

    public GameObject _glowPaths;
    public GameObject _glowPoint;
    public List<Transform[]> _glowPathWayPoints;
    public List<float> _glowPathTimes;
    public int _currentPath = 0;
    public bool _updatePath = true;
    public float _pathTime = 3f;
    public GameObject _finalFish;

	// Use this for initialization
	void Start () {

        
        Transform[] paths = GetComponentsInDirectChildren<Transform>(_glowPaths);
        _finalFish = GameObject.Find("Final_Fish");
        _glowPathWayPoints = new List<Transform[]>();
        for (int i=0; i < paths.Length; i++)
        {
            Transform[] waypoints = GetComponentsInDirectChildren<Transform>(paths[i].gameObject);
            _glowPathWayPoints.Add(waypoints);
            _glowPathTimes.Add(paths[i].gameObject.GetComponent<GlowPointTrigger>()._glowPathTime);
        }
        
        _glowPoint.transform.position = _glowPathWayPoints[0][0].position;
        ScaleSprite();
        RotateSprite();
        iTween.FadeTo(_glowPoint.transform.Find("GlowPointSprite").gameObject, 0f, 0f);
        iTween.FadeTo(_glowPoint.transform.Find("GlowPointSprite").gameObject, iTween.Hash("alpha", 1f, "time", 1f, "delay", 0.1f));

    }

    // Update is called once per frame
    void Update () {
       if (_updatePath)
        {
            Transform[] path = _glowPathWayPoints[_currentPath];

            if (_currentPath == _glowPathWayPoints.Count - 1)
            {
                iTween.MoveTo(_glowPoint, iTween.Hash("path", path, "time", _glowPathTimes[_currentPath], "easeType", iTween.EaseType.easeInOutSine, "oncomplete", "GoToFinalPosition", "oncompletetarget", gameObject));
            } else
            {
                iTween.MoveTo(_glowPoint, iTween.Hash("path", path, "time", _glowPathTimes[_currentPath], "easeType", iTween.EaseType.easeInOutSine));
            }

            
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
        float changeTime = Random.Range(1.5f, 2f);
        iTween.RotateTo(_glowPoint, iTween.Hash("z", degree, "time", changeTime, "oncomplete", "RotateSprite", "oncompletetarget", gameObject, "oncompleteparams", isClockwise, "easetype", iTween.EaseType.easeInOutSine));
    }

    void GoToFinalPosition()
    {
        iTween.Stop();
        iTween.RotateTo(_glowPoint, iTween.Hash("amount", new Vector3 (7.24f, 12.285f, -185.569f) , "time", 1f, "easetype", iTween.EaseType.easeInOutSine, "oncomplete", "AttachToFinalFish", "oncompletetarget", gameObject));
    }

    void AttachToFinalFish()
    {

        _glowPoint.transform.parent = _finalFish.transform;
        
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
