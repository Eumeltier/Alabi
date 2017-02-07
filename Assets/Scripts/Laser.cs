using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    public Color corLaser = Color.green;
    public int DistanciaDoLaser = 50;
    public float LarguraInicial = 0.02f, LarguraFinal = 0.1f;
    private GameObject luzColisao;
    private Vector3 posicLuz;


    private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        luzColisao = new GameObject();
        luzColisao.AddComponent<Light>();
        Light tmpLight = luzColisao.GetComponent<Light>();
        tmpLight.intensity = 8;
        tmpLight.bounceIntensity = 8;
        tmpLight.range = LarguraFinal * 2;
        tmpLight.color = corLaser;
        //posicLuz = new Vector3(0, 0, 0;

        LineRenderer lineRenderertmp = gameObject.AddComponent<LineRenderer>();
        lineRenderer = lineRenderertmp;
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(corLaser, corLaser);
        lineRenderer.SetWidth(LarguraInicial, LarguraFinal);
        lineRenderer.SetVertexCount(2);

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 PontoFinalDoLaser = transform.position + transform.forward * DistanciaDoLaser;
        RaycastHit PontoDeColisao;
        if (Physics.Raycast(transform.position, transform.forward, out PontoDeColisao, DistanciaDoLaser))
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, PontoDeColisao.point);
            luzColisao.transform.position = (PontoDeColisao.point - posicLuz);
        }
        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, PontoFinalDoLaser);
            luzColisao.transform.position = PontoFinalDoLaser;
        }
	}
}
