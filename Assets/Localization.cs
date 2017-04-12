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

	public Font _chnSimpFont;
	public Font _chnTradFont;
	public Font _engFont;

	

	void Awake () {

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
            ReplaceTextMesh(textMeshes, _chnSimpStrings, _chnSimpFont);
			
        } else if (Application.systemLanguage == SystemLanguage.ChineseTraditional) {
            ReplaceTextMesh(textMeshes, _chnTradStrings, _chnTradFont);
        } else {
            ReplaceTextMesh(textMeshes, _engStrings, _engFont);
        }
	}

	void Localize(Text[] texts) {
		if (Application.systemLanguage == SystemLanguage.Chinese || Application.systemLanguage == SystemLanguage.ChineseSimplified) {
            ReplaceText(texts, _chnSimpStrings, _chnSimpFont);
        } else if (Application.systemLanguage == SystemLanguage.ChineseTraditional) {
            ReplaceText(texts, _chnTradStrings, _chnTradFont);
        } else {
            ReplaceText(texts, _engStrings, _engFont);
        }
	}

	void ReplaceTextMesh(TextMesh[] str, string[] replacedString, Font font) {
		for (int i = 0; i < str.Length; i++) {
			if (font) {
				str[i].font = font;
				str[i].GetComponent<MeshRenderer>().material = font.material;
			}
			str[i].text = replacedString[i];
		}
	}

	void ReplaceText(Text[] str, string[] replacedString, Font font) {
		for (int i = 0; i < str.Length; i++) {
			if (font) {
				str[i].font = font;
				// str[i].GetComponent<MeshRenderer>().material = font.material;
			}
			str[i].text = replacedString[i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
