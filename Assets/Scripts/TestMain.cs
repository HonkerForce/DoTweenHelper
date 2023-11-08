using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using UnityEngine;
using DG;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class TestMain : MonoBehaviour
{
    public Transform tweenTarget;
    
    public Vector3 to;
    public float runTime;
    public bool snap;
    public float delay;

    void Awake()
    {
        DOTween.Init();
        if (tweenTarget == null)
        {
            tweenTarget = GetComponent<Transform>();
        }
    }
                            
    void Start()
    {
        // tweenTarget?.DORotate(new Vector3(90f, 0f, 0f), 1f, RotateMode.Fast).From(new Vector3(1f, 1f, 1f));
        // tweenTarget?.DOJump(new Vector3(15f, 0f, 0f), 10f, 2, 2f);
        // DOTween.To(() => transform.localPosition, value => transform.localPosition = value, to, runTime);

        tweenTarget.DOScale(to, runTime).SetDelay(delay).SetOptions(snap).From();
    }

    void Update()
    {
        // tweenTarget?.DOLocalRotate(new Vector3(90f, 0f, 0f), 1f, RotateMode.Fast).From(true);
    }

    private TweenerCore<Vector3, Vector3, VectorOptions> tweener;
    public void OnClick_Test()
    {
        // if (DOTween.IsTweening(tweenTarget, true))
        // {
        //     DOTween.Rewind(tweenTarget);
        //     return;
        // }
        //
        // if (tweenTarget.position == to)
        // {
        //     tweener.Restart(true);
        // }
        // else
        // {
        //     tweener = tweenTarget?.DOMove(to, runTime, snap).SetLoops(1, LoopType.Yoyo).SetEase(Ease.Linear).SetId("nihao").SetAutoKill(false);
        // }
        
        // print("找到id=nihao的Tween：" + DOTween.TweensById("nihao")?.Count + "个," + String.Join(',', DOTween.TweensById("nihao")?.Select(x => x.stringId)));
        
        
    }
}
