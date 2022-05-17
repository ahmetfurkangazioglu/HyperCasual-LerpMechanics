using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LerpMechanis : MonoBehaviour
{

    public static LerpMechanis instance;
    public List<GameObject> collect = new List<GameObject>();
    private float movementDelay = 0.25f;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }


    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MoveLerpObjects();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            MoveOrigin();
        }
    }

   public void StackCollect(GameObject other,int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = collect[index].transform.localPosition;
        newPos.z += 1;
        other.transform.localPosition = newPos;
        collect.Add(other);
        StartCoroutine(MakeObjectsBigger());
    }

    private IEnumerator MakeObjectsBigger()
    {
        for (int i = collect.Count-1; i > 0; i--)
        {
            int index = i;
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.5f;
            collect[index].transform.DOScale(scale, 0.1f).OnComplete(() =>
             collect[index].transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            yield return new WaitForSeconds(0.05f);
        }
    }


    private void MoveLerpObjects()
    {
        for (int i = 1; i < collect.Count; i++)
        {
            int index = i;
            Vector3 pos = collect[index].transform.localPosition;
            pos.x = collect[index - 1].transform.localPosition.x;
            collect[index].transform.DOLocalMove(pos, movementDelay);
        }
    }
    private void MoveOrigin()
    {
        for (int i = 1; i < collect.Count; i++)
        {
            int index = i;
            Vector3 pos = collect[index].transform.localPosition;
            pos.x = collect[0].transform.localPosition.x;
            collect[index].transform.DOLocalMove(pos, 0.70f);
        }

    }
}
