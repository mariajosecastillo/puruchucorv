using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class RuntimeCardboardLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(LoadDevice("Cardboard"));
        StartCoroutine(LoadDevice("Oculus"));
    }

    IEnumerator LoadDevice(string newDevice)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = true;
    }
}
