using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffect : MonoBehaviour {

    Camera thisCamera;
    public Shader Outline;
    public Shader Draw;
    Camera Temp;
    Material Post_Mat;
   // public RenderTexture TempRT;

	
	void Start () 
    {
		thisCamera = GetComponent<Camera>();
        Temp = new GameObject().AddComponent<Camera>();
        Temp.enabled = false;
        Post_Mat = new Material(Outline);
	}
	
	void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //set up a temp camera
        Temp.CopyFrom(thisCamera);
        Temp.clearFlags = CameraClearFlags.Color;
        Temp.backgroundColor = Color.black;

        Temp.cullingMask = 1 << LayerMask.NameToLayer("Outline");

        RenderTexture TempRT =
            new RenderTexture(
                source.width,
                source.height,
                0,
                RenderTextureFormat.R8
                );

        TempRT.Create();
        Temp.targetTexture = TempRT;
        Temp.RenderWithShader(Draw, "");
        Graphics.Blit(TempRT, destination,Post_Mat);
        TempRT.Release();


	}
}
