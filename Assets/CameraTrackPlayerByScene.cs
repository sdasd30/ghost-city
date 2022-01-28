using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrackPlayerByScene : MonoBehaviour
{
    private Camera cam;
    private Transform ploc;
    private bool needtomovex;
    private bool needtomovey;

    public class Scene
    {
        public Scene(float xmin, float xmax, float ymin, float ymax, SceneType t, bool a)
        {
            xMin = xmin;
            yMin = ymin;
            xMax = xmax;
            yMax = ymax;
            type = t;
            active = a;
        }

        public Scene()
        {
            xMin = yMin = xMax = yMax = float.NaN;
            type = SceneType.DEFAULT;
            active = false;
        }

        public float xMin;
        public float yMin;
        public float xMax;
        public float yMax;
        public SceneType type;
        public bool active;
    }
    public enum SceneType
    {
        OneScreen,
        ScrollHorizontal,
        ScrollVertical,
        ScrollOmni,
        DEFAULT
    }

    [SerializeField] private List<Scene> scenes;
    [SerializeField] private Scene curScene;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        ploc = FindObjectOfType<Player>().transform;
        //if (scenes.Count > 0) curScene = scenes[0];
        scenes = new List<Scene>();
        //Debug.Log(cam.orthographicSize);
        //Debug.Log(cam.orthographicSize * cam.aspect);
        Scene scene1 = new Scene(-7.094f, 15.094f, 0, float.PositiveInfinity, SceneType.ScrollOmni, true);
        scenes.Add(scene1);
        Scene scene2 = new Scene(15.094f + 2f * cam.orthographicSize * cam.aspect, 30.094f, 0, float.PositiveInfinity, SceneType.ScrollOmni, true);
        scenes.Add(scene2);

        curScene = scenes[0];
    }

    // Update is called once per frame
    void Update()
    {
        // if player has left this scene, change scenes to the scene the player is now in
        if (!curScene.active ||
            ploc.position.x > curScene.xMax + cam.orthographicSize * cam.aspect ||
            ploc.position.x < curScene.xMin - cam.orthographicSize * cam.aspect ||
            ploc.position.y > curScene.yMax + cam.orthographicSize ||
            ploc.position.y < curScene.yMin - cam.orthographicSize)
        {
            Scene temp = FindCurrentScene();
            if (temp.active)
            {
                curScene = temp;
            }
        }
        MoveCamera(curScene);
    }

    private Scene FindCurrentScene()
    {
        foreach (Scene s in scenes)
        {
            if (ploc.position.x <= s.xMax + cam.orthographicSize * cam.aspect &&
                ploc.position.x >= s.xMin - cam.orthographicSize * cam.aspect &&
                ploc.position.y <= s.yMax + cam.orthographicSize &&
                ploc.position.y >= s.yMin - cam.orthographicSize)
            {
                needtomovex = needtomovey = true;
                return s;
            }
        }
        return new Scene();
    }

    private void MoveCamera(Scene curScene)
    {
        switch (curScene.type)
        {
            case SceneType.OneScreen:
                if (needtomovex)
                {
                    SetCameraX(curScene.xMin);
                    needtomovex = false;
                }
                if (needtomovey)
                {
                    SetCameraY(curScene.yMin);
                    needtomovey = false;
                }
                break;

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
