using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;


public class SceneSelector : MonoBehaviour {

	public Button[] _SceneBtns;

	public Sprite[] _SceneUnlockBtnsSprite;
	public AsyncSceneLoader _AsyncSceneLoader;
	private int _sceneIndexOffset = 1;
	
	public int _maxLevel = 2;


	// Use this for initialization
	void Start () {
		
		for (int i = 0; i < _maxLevel; i++) {
			int _sceneIndex = i + _sceneIndexOffset;
			_SceneBtns[i].gameObject.GetComponent<Image>().sprite = _SceneUnlockBtnsSprite[i];
			_SceneBtns[i].onClick.AddListener(delegate () { LoadScene(_sceneIndex); });
		}

        // try unlock 2nd level.
        LoadLevels();
        //SetLevel("1", true);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadScene(int sceneIndex) {
		
		_AsyncSceneLoader.ToSelectedScene(sceneIndex);
	}

	IEnumerator GoToSelectedScene(int sceneIndex) {
		yield return new WaitForSeconds (3f);
        _AsyncSceneLoader.ToSelectedScene(sceneIndex);
    }

    // The following two functions will maintain level list and set the lock/unlock state of a level.

    // Load Xml file.
    public static List<Level> LoadLevels()
    {
        XmlDocument xmlDoc = new XmlDocument();
        string filePath = Application.persistentDataPath + "/levels.xml";
        if (!IOHelper.isFileExists(filePath))
        {
            xmlDoc.LoadXml(((TextAsset)Resources.Load("levels")).text);
            IOHelper.CreateFile(filePath, xmlDoc.InnerXml);
        }
        else
        {
            xmlDoc.Load(filePath);
        }
        XmlElement root = xmlDoc.DocumentElement;
        XmlNodeList levelsNode = root.SelectNodes("/levels/level");
        // make the level list
        List<Level> levels = new List<Level>();
        foreach (XmlElement xe in levelsNode)
        {
            Level l = new Level();
            l.ID = xe.GetAttribute("id");
            // mark unlock
            if (xe.GetAttribute("unlocked") == "1")
            {
                l.Unlocked = true;
            } else
            {
                l.Unlocked = false;
            }
            levels.Add(l);
            }
        return levels;
        }

    public static void SetLevel(string ID, bool unlock)
    {
        // create the xml object
        XmlDocument xmlDoc = new XmlDocument();
        string filePath = Application.persistentDataPath + "/levels.xml";
        xmlDoc.Load(filePath);
        XmlElement root = xmlDoc.DocumentElement;
        XmlNodeList levelsNode = root.SelectNodes("/levels/level");

        //find the corresponding level
        foreach (XmlElement xe in levelsNode){
            if (xe.GetAttribute("id") == ID)
            {
                if (unlock)
                {
                    xe.SetAttribute("unlocked", "1");
                }
                else
                {
                    xe.SetAttribute("unlocked", "0");
                }
            }
        }
        //save the file
        xmlDoc.Save(filePath);
    }
}


