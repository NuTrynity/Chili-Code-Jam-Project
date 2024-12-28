using UnityEngine;

public class centipede : MonoBehaviour
{
    public int lenght; // Lenght of centipede must be the amount of body parts there is + 1
    public LineRenderer lr;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;

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
            Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);
            body_parts[i - 1].transform.position = segmentPoses[i];
        }
        lr.SetPositions(segmentPoses);
    }
}