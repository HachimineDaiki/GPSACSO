using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ShapeKeyOperations : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private float blinkCount;
    [SerializeField]
    private float blinkSpeed = 5f;

    // Start is called before the first frame update
    void Start() {
        skinnedMeshRenderer = transform.Find("musclepose002").GetComponent<SkinnedMeshRenderer>();
        //　MouseOpen（今回はなにもしない）
        skinnedMeshRenderer.SetBlendShapeWeight(0, 0f);
        //　Blink
        skinnedMeshRenderer.SetBlendShapeWeight(1, 0f);
    }

    // Update is called once per frame
    void Update() {
        //　0～100の間のウエイト値を生成
        blinkCount = Mathf.Clamp01(Mathf.Sin(Time.time * blinkSpeed)) * 100f;
        skinnedMeshRenderer.SetBlendShapeWeight(1, blinkCount);
    }
}