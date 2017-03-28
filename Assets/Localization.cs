using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Localization : MonoBehaviour {

	// Use this for initialization
	
	
	public TextMesh[] _textMeshes;

	public Text[] _texts;

	public string[] _chnSimpStrings;
	public string[] _chnTradStrings;
	public string[] _engStrings;

	void Start () {

		if (_texts.Length > 0) {
			Localize(_texts);
			return;
		}
		if (_textMeshes.Length > 0){
			Localize(_textMeshes);
			return;
		}
	}

	void Localize(TextMesh[] textMeshes) {
		if (Application.systemLanguage == SystemLanguage.Chinese || Application.systemLanguage == SystemLanguage.ChineseSimplified) {
            ReplaceTextMesh(textMeshes, _chnSimpStrings);
        } else if (Application.systemLanguage == SystemLanguage.ChineseTraditional) {
            ReplaceTextMesh(textMeshes, _chnTradStrings);
        } else {
            ReplaceTextMesh(textMeshes, _engStrings);
        }
	}

	void Localize(Text[] texts) {
		if (Application.systemLanguage == SystemLanguage.Chinese || Application.systemLanguage == SystemLanguage.ChineseSimplified) {
            ReplaceText(texts, _chnSimpStrings);
        } else if (Application.systemLanguage == SystemLanguage.ChineseTraditional) {
            ReplaceText(texts, _chnTradStrings);
        } else {
            ReplaceText(texts, _engStrings);
        }
	}

	void ReplaceTextMesh(TextMesh[] str, string[] replacedString) {
		for (int i = 0; i < str.Length; i++) {
			str[i].text = replacedString[i];
		}
	}

	void ReplaceText(Text[] str, string[] replacedString) {
		for (int i = 0; i < str.Length; i++) {
			str[i].text = replacedString[i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
