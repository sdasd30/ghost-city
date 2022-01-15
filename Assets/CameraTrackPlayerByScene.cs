using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrackPlayerByScene : MonoBehaviour
{
    private Camera cam;
    private Transform ploc;
    private bool needtomovex;
    private bool needtomovey;

    public struct Scene
    {
        public Scene(float xmin, float xmax, float ymin, float ymax, SceneType t)
        {
            xMin = xmin;
            yMin = ymin;
            xMax = xmax;
            yMax = ymax;
            type = t;
        }
        public float xMin;
        public float yMin;
        public float xMax;
        public float yMax;
        public SceneType type;
    }
    public enum SceneType
    {
        OneScreen,
        ScrollHorizontal,
        ScrollVertical,
        ScrollOmni
    }

    [SerializeField] private List<Scene> scenes;
    [SerializeField] private Scene curScene;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        ploc = FindObjectOfType<Player>().transform;
        //if (scenes.Count > 0) curScene = scenes[0];
        curScene = new Scene(-7.094f, 15.094f, 0, float.PositiveInfinity, SceneType.ScrollOmni);
    }

    // Update is called once per frame
    void Update()
    {
        switch (curScene.type)
        {
            case SceneType.ScrollHorizontal:
                if (ploc.position.x < curScene.xMin)
                {
                    if (needtomovex)
                    {
                        SetCameraX(curScene.xMin);
                        needtomovex = false;
                    }
                }
                else if (ploc.position.x > curScene.xMax)
                {
                    if (needtomovex)
                    {
                        SetCameraX(curScene.xMax);
                        needtomovex = false;
                    }
                }
                else
                {
                    SetCameraX(ploc.position.x);
                    needtomovex = true;
                }
                break;

            case SceneType.ScrollVertical:
                if (ploc.position.y < curScene.yMin)
                {
                    if (needtomovey)
                    {
                        SetCameraY(curScene.yMin);
                        needtomovey = false;
                    }
                }
                else if (ploc.position.y > curScene.yMax)
                {
                    if (needtomovey)
                    {
                        SetCameraY(curScene.yMax);
                        needtomovey = false;
                    }
                }
                else
                {
                    SetCameraY(ploc.position.y);
                    needtomovey = true;
                }
                break;

            case SceneType.ScrollOmni:
                if (ploc.position.x < curScene.xMin)
                {
                    if (needtomovex)
                    {
                        SetCameraX(curScene.xMin);
                        needtomovex = false;
                    }
                }
                else if (ploc.position.x > curScene.xMax)
                {
                    if (needtomovex)
                    {
                        SetCameraX(curScene.xMax);
                        needtomovex = false;
                    }
                }
                else
                {
                    SetCameraX(ploc.position.x);
                    needtomovex = true;
                }

                if (ploc.position.y < curScene.yMin)
                {
                    if (needtomovey)
                    {
                        SetCameraY(curScene.yMin);
                        needtomovey = false;
                    }
                }
                else if (ploc.position.y > curScene.yMax)
                {
                    if (needtomovey)
                    {
                        SetCameraY(curScene.yMax);
                        needtomovey = false;
                    }
                }
                else
                {
                    SetCameraY(ploc.position.y);
                    needtomovey = true;
                }
                break;
        }
    }
    private void SetCameraX(float newx)
    {
        cam.transform.position = new Vector3(newx, cam.transform.position.y, cam.transform.position.z);
    }

    private void SetCameraY(float newy)
    {
        cam.transform.position = new Vector3(cam.transform.position.x, newy, cam.transform.position.z);
    }
}
