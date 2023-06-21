using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class FieldOfViewGuards : MonoBehaviour
{
    public Transform guard;
    private Mesh mesh;
    [SerializeField] private LayerMask layerMask;
    Vector3 origin;
    float startingAngle;
    float fov;

    private void Awake()
    {
        MeshRenderer meshRender = GetComponent<MeshRenderer>();
        meshRender.sortingOrder = 20;
        mesh = new Mesh();
        fov = 90f;
        
    }

    void LateUpdate()
    {
        this.transform.position = new Vector3(0, 0, -0.1f);
        int rayCount = 90;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 2f;

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDistance, layerMask);

            if (raycastHit2D.collider == null)
            {
                Debug.Log("no hit");
                //no hit
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                Debug.Log("hit");
                //hit
                vertex = raycastHit2D.point;
            }


            vertices[vertexIndex] = vertex;
            
            if(i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        
        GetComponent<MeshFilter>().mesh = mesh;

        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = UtilsClass.GetAngleFromVectorFloat(aimDirection) - fov / 2 ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            guard.GetComponent<GuardMovement>().ResetPlayer();
        }
    }
}
