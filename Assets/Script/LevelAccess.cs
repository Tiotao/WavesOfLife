using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
public class LevelAccess {

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
