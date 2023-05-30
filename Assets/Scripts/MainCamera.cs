using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
    [SerializeField] private GameObject sphare;
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (Input.touchCount <= 0) {
            return;
        }

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began) {
            generateAnimals();
        }
    }

    private void generateAnimals() {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        worldPoint.z = transform.position.z;
        Ray ray = new Ray(worldPoint, Vector3.forward * 50f); // Rayを生成;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            GameObject obj = (GameObject)Resources.Load("Prefabs/ZeebraPrefab");
            Vector3 floorPoint = hit.point;
            floorPoint.y = floorPoint.y + 4f;

            GameObject instance = Instantiate(obj, floorPoint, Quaternion.identity);
            instance.transform.Rotate(new Vector3(-90, 0, 0));
        }

    }

    void OnDrawGizmos() {
        Gizmos.color = new Color32(255, 0, 0, 255);
        Gizmos.DrawRay(new Vector3(0.32f, -3.07f, 0.00f), Vector3.forward * 50f);
    }
}
