using UnityEngine;

namespace SuperSystems.UnityTools
{

public class AutoRotate : MonoBehaviour
{
    public Vector3 speed = new Vector3(10, 10, 10);
    public Space space = Space.World;

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime, space);
    }
}

}