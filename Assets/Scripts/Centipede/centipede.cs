using UnityEngine;

public class centipede : MonoBehaviour
{
    public int lenght;
    public LineRenderer lr;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;
    public float trailSpeed;

    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;
    public Transform[] body_parts;

    private void Start()
    {
        lr.positionCount = lenght;
        segmentPoses = new Vector3[lenght];
        segmentV = new Vector3[lenght];
    }
    private void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed + i / trailSpeed);
            body_parts[i - 1].transform.position = segmentPoses[i];
        }
        lr.SetPositions(segmentPoses);
    }
}