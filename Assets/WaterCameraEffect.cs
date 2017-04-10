using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCameraEffect : MonoBehaviour {

	// Use this for initialization
	public Material mat;

	/// <summary>
	/// OnRenderImage is called after all rendering is complete to render image.
	/// </summary>
	/// <param name="src">The source RenderTexture.</param>
	/// <param name="dest">The destination RenderTexture.</param>
#if !UNITY_EDITOR	
	void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		Graphics.Blit(src, dest, mat);
	}

#endif

}
