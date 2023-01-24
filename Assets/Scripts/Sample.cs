using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// SafeAreaÇ∆CutoutsÇÃÉTÉìÉvÉã
public class Sample : MonoBehaviour
{
    [SerializeField] GameObject m_SpritePrefab;
    [SerializeField] GameObject m_Canvas;
    GameObject m_SafeAreaObject;
    GameObject[] m_CutoutObjects;
    ScreenOrientation m_ScreenOrientation;

    private void Start()
    {
        m_ScreenOrientation = Screen.orientation;
        SetUpDrawSafeArea();
        SetUpDrawCutOuts();
    }

    private void OnDestroy()
    {
        if(m_SafeAreaObject != null)
        {
            Destroy(m_SafeAreaObject);
            m_SafeAreaObject = null;
        }

        if(m_CutoutObjects != null)
        {
            for(var i = 0; i < m_CutoutObjects.Length; i++)
            {
                Destroy(m_CutoutObjects[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Screen.orientation != m_ScreenOrientation)
        {
            m_ScreenOrientation = Screen.orientation;            
            SetUpDrawSafeArea();
            SetUpDrawCutOuts();
        }
    }

    void SetUpDrawSafeArea()
    {
        if (m_SafeAreaObject != null)
        {
            Destroy(m_SafeAreaObject);
            m_SafeAreaObject = null;
        }
        var rect = Screen.safeArea;
        if (rect != null)
        {
            var parentTransform = m_Canvas.GetComponent<RectTransform>();

            m_SafeAreaObject = Instantiate(m_SpritePrefab, parentTransform);
            var localPoint = new Vector2();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentTransform, new Vector2(rect.x, rect.y), null, out localPoint);
            var rectTransform = m_SafeAreaObject.GetComponent<RectTransform>();
            // ç∂è„Çí∏ì_Ç…Ç∑ÇÈ
            rectTransform.pivot = new Vector2(0, 0);
            rectTransform.localPosition = localPoint;
            rectTransform.localScale = new Vector3(rect.width, rect.height, 1);
            m_SafeAreaObject.GetComponent<Image>().color = Color.blue;
        }
    }


    void SetUpDrawCutOuts()
    {
        if(m_CutoutObjects != null)
        {
            for(var i = 0; i < m_CutoutObjects.Length; i++)
            {
                Destroy(m_CutoutObjects[i]);
                m_CutoutObjects[i] = null;
            }
            m_CutoutObjects = null;
        }
        if (Screen.cutouts != null)
        {
            var parentTransform = m_Canvas.GetComponent<RectTransform>();
            m_CutoutObjects = new GameObject[Screen.cutouts.Length];
            for (var i = 0; i < m_CutoutObjects.Length; i++)
            {
                m_CutoutObjects[i] = Instantiate(m_SpritePrefab, parentTransform);
                var localPoint = new Vector2();
                RectTransformUtility.ScreenPointToLocalPointInRectangle(parentTransform, new Vector2(Screen.cutouts[i].x, Screen.cutouts[i].y), null, out localPoint);
                var rectTransform = m_CutoutObjects[i].GetComponent<RectTransform>();
                rectTransform.localPosition = localPoint;
                rectTransform.localScale = new Vector3(Screen.cutouts[i].width, Screen.cutouts[i].height, 1);
                m_CutoutObjects[i].GetComponent<Image>().color = Color.green;
            }
        }
    }
}
