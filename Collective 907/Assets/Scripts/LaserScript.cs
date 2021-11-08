using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private LineRenderer line;
    public float lineWidth;
    private float lastEnabled;
    private float laserDuration;
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] {Vector3.zero, Vector3.zero};
        line = GetComponent<LineRenderer>();
        line.SetPositions(initLaserPositions);
        line.SetWidth(lineWidth, lineWidth);
        laserDuration = 0.5f;
    }
    void Update() {
        if(Time.unscaledTime >= lastEnabled + laserDuration) {
            line.enabled = false;
        }
    }

    public void SetLaserPositions(Vector3 start, RaycastHit objectHit)
    {
        Vector3 endPosition = objectHit.point;

        Vector3[] laserPositions = new Vector3[2] {start, endPosition};
        line.SetPositions(laserPositions);
        lastEnabled = Time.unscaledTime;
        // If the laser is not visible, make it visible
        if (!line.enabled)
        {
            line.enabled = true;
        }
        Debug.Log("VISIBLE: " + line.isVisible);
    }
}
