
///Words to be deleted

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem.XR;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject objectPrefab;
    public Transform spawnPoint;
    public XRNode controllerNode = XRNode.RightHand;
    public float spawncooldown = 1.0f;

    private bool canSpawn = true;

    // Update is called once per frame
    void Update()
    {
        if (canSpawn && IsAButtonPressed())
        {
            StartCoroutine(SpawnObjectWithCooldown());
        }

    }

    bool IsAButtonPressed()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(controllerNode);
        bool buttonPressed = false;

        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out buttonPressed) && buttonPressed)
        {
            return true;
        }

        return false;
    }

    IEnumerator SpawnObjectWithCooldown()
    {
        canSpawn = false;
        SpawnObject();
        yield return new WaitForSeconds(spawncooldown);
        canSpawn = true;
    }

    void SpawnObject()
    {
        if(objectPrefab != null && spawnPoint !=null) 
            {
                GameObject spawnedObject = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);
            }

        else
        {
            Debug.Log("Either assign a GameObject or SpawnPoint In Inspector");
        }
    }
}
