using UnityEngine;
using System.Collections;
using System.Linq;

// place first and last elements in children array manually
// others will be placed automatically with equal distances between first and last elements
public class SameDistanceChildren : MonoBehaviour {

    public Transform[] Children;
    public float arcMin = -15f;
    public float arcMax = 15f;

    // Use this for initialization
    void Awake() {
        Vector3 firstElementPos = Children[0].transform.position;
        Vector3 lastElementPos = Children[Children.Length - 1].transform.position;

        // dividing by Children.Length - 1 because for example: between 10 points that are 9 segments
        float XDist = (lastElementPos.x - firstElementPos.x) / (float)(Children.Length - 1);
        float YDist = (lastElementPos.y - firstElementPos.y) / (float)(Children.Length - 1);
        float ZDist = (lastElementPos.z - firstElementPos.z) / (float)(Children.Length - 1);
        int[] angles = GenerateRotation();
        float[] heights = GenerateHeight();
       


        Vector3 Dist = new Vector3(XDist, YDist, ZDist);

        for (int i = 1; i < Children.Length; i++) {

            Children[i].transform.position = Children[i - 1].transform.position + Dist;
        }

        for (int i = 0; i < Children.Length; i++) {

            Vector3 rotation = new Vector3();
            //rotation.y = 0;
            rotation.z = angles[i];
            //rotation.x = 0;

            Dist.y = heights[i];
            Dist.x = 0;
            Children[i].transform.position = Children[i].transform.position + Dist;
            //Children[i].transform.Rotate(rotation);
        }
    }

    private int[] GenerateRotation() {

        int[] angles = new int[Children.Length];
        int rotationPerCard = 2;
        int maxRotation = rotationPerCard * Children.Length;
        int minRotation = maxRotation * -1;

        for (int i = 0; i < Children.Length; i++) {

            angles[i] = minRotation;
            minRotation += 4;

        }

        return angles;
    }

    private float[] GenerateHeight() {
        float[] heights = new float[Children.Length];
        float maxHeight = 180f;
        float singleStep = (180f / Children.Length) * 2;
        float startHeight = 0f;
        float currentHeight = 0f;
        bool reachedMax = false;

        for(int i = 0; i < heights.Length; i++) {
            heights[i] = startHeight;
            if(i != 0 && i != heights.Length - 1) {
                
                if((currentHeight + singleStep <= maxHeight) && !reachedMax) {
                    currentHeight += singleStep;
                } else {
                    reachedMax = true;
                }

                if(reachedMax) {
                    currentHeight -= singleStep;
                }

                heights[i] = currentHeight;
            }
        }

        return heights;
    }
	
	
}
