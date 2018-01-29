using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Path : MonoBehaviour
{
    public List<GameObject> nodes;
    List<PathSegment> segments;

    void Start()
    {
        segments = GetSegments();
    }
    public List<PathSegment> GetSegments()
    {
        List<PathSegment> segments = new List<PathSegment>();
        int i;
        for (i = 0; i < nodes.Count - 1; i++)
        {
            Vector3 src = nodes[i].transform.position;
            Vector3 dst = nodes[i + 1].transform.position;
            PathSegment segment = new PathSegment(src, dst);
            segments.Add(segment);
        }
        return segments;
    }
    //public float GetParam(Vector3 position, float lastParam)
    //{
    //    float param = 0f;
    //    PathSegment currentSegment = null;
    //    float tempParam = 0f;
    //    foreach (PathSegment ps in segments)
    //    {
    //        tempParam += Vector3.Distance(ps.a, ps.b);
    //        if (lastParam <= tempParam)
    //        {
    //            currentSegment = ps;
    //            break;
    //        }
    //    }
    //    if (currentSegment == null)
    //        return 0f;
    //}
}
