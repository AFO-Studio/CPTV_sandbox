using UnityEngine;

public class PostEffect : MonoBehaviour
{
    private Camera thisCamera;

    public Shader outline;
    public Shader draw;

    private Camera temp;
    private Material postMat;
   // public RenderTexture TempRT;

	private void Start() 
    {
		thisCamera = GetComponent<Camera>();

        temp = new GameObject().AddComponent<Camera>();
        temp.enabled = false;

        postMat = new Material(outline);
	}
	
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // Set up a temp camera
        temp.CopyFrom(thisCamera);
        temp.clearFlags = CameraClearFlags.Color;
        temp.backgroundColor = Color.black;

        temp.cullingMask = 1 << LayerMask.NameToLayer("Outline");

        RenderTexture TempRT = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.R8);

        TempRT.Create();
        temp.targetTexture = TempRT;
        temp.RenderWithShader(draw, "");

        Graphics.Blit(TempRT, destination,postMat);
        TempRT.Release();
	}
}
