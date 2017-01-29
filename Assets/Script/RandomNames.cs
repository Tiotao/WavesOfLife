using UnityEngine;
using System.Collections;
using System.IO;

public class RandomNames : MonoBehaviour {

    public TextAsset TxtFile;   
    private string Nametxt;       
    private ArrayList Namelist;

    public GameObject LastNameField;
    private string LastName;
    public bool test;


    // Use this for initialization
    void Awake () {
        Namelist = new ArrayList(60);

        Nametxt = TxtFile.text;

        var lines = Nametxt.Split("\n"[0]);
        foreach (string line in lines)
        {
            Namelist.Add(line);
        }

    }

    // Update is called once per frame
    void Update () {
        if (test)
        {
            GetName();
            test = false;
        }

    }

    private string GetFirstName()
    {
        var randomNumber = Random.Range(0, Namelist.Count);
        string answer = Namelist[randomNumber].ToString();
        Namelist.Remove(randomNumber);
        // Debug.Log("name list length: " + Namelist.Count);
        return answer;
    }

    public string GetName()
    {
        // LastName = LastNameField.GetComponent<UnityEngine.UI.InputField>().text;
        LastName = "";
        string name = GetFirstName() +" " + LastName;
        // Debug.Log(name);
        return name;
    }

}
