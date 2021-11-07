using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] {Vector3.zero, Vector3.zero};
        line = GetComponent<LineRenderer>();
        line.SetPositions(initLaserPositions);
        line.SetWidth(0.1f, 0.1f);
    }

    public void SetLaserPositions(Vector3 start, RaycastHit objectHit)
    {
        Vector3 endPosition = objectHit.point;
        Vector3[] laserPositions = new Vector3[2] {start, endPosition};
        line.SetPositions(laserPositions);
        // If the laser is not visible, make it visible
        if (!line.enabled)
        {
            line.enabled = true;
        }
    }
}
