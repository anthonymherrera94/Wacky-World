using PlayerManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBashManager : MonoBehaviour
{
    [SerializeField]
    private List<TinyBall> balls;

    [SerializeField]
    private List<GameObject> LevelObjects = new List<GameObject>();

    
    private List<Vector3> positions = new List<Vector3>();
    private List<Vector3> fromPositions = new List<Vector3>();
    private float loadTime = 2f;
    void Start()
    {
        LevelObjects.ForEach(x => positions.Add(x.transform.position));
        if (PlayerManager.Instance.Hero != null)
            PlayerManager.Instance.Hero.GetComponent<HeroAbilities>().AddAbility(typeof(BallBasher));
        StartCoroutine("OnLoadLevel");


    }
    public void End()
    {
        PlayerManager.Instance.Hero.GetComponent<HeroAbilities>().RemoveAbility(typeof(BallBasher));
        StartCoroutine("OnUnloadLevel");
    }

    private IEnumerator OnLoadLevel()
    {
        float endTime = Time.time+loadTime;
        positions.ForEach(x => fromPositions.Add(x + Vector3.up * Random.Range(5, 10)));

        while (Time.time < endTime)
        {
            for (int i = 0; i < LevelObjects.Count; i++)
            {
                if (LevelObjects[i] != null)
                    LevelObjects[i].transform.position = Vector3.Lerp(fromPositions[i], positions[i], 1 - (endTime - Time.time) / loadTime);

            }
            yield return null;
        }


        for (int i = 0; i < LevelObjects.Count; i++)
            if (LevelObjects[i] != null)
                LevelObjects[i].transform.position = positions[i];
    }
    private IEnumerator OnUnloadLevel()
    {
        float endTime = Time.time + loadTime;

        while (Time.time < endTime)
        {
            for (int i = 0; i < LevelObjects.Count; i++)
            {
                if (LevelObjects[i] != null)
                    LevelObjects[i].transform.position = Vector3.Lerp(positions[i], fromPositions[i],  1 - (endTime - Time.time) / loadTime);

            }
            yield return null;
        }

        SceneManager.UnloadSceneAsync("BallBash");
    }
}
