using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using System.Diagnostics;

public class SortManager : MonoBehaviour
{
    [SerializeField] private GameObject GameObject;
    [SerializeField] private float transitionTime = 0.5f;
    [SerializeField] public Button removeButton; 
    [SerializeField] public Button createButton;
    [SerializeField] public Button sortButton; 
    [SerializeField] public TMP_Dropdown dropDown;
    [SerializeField] public TMP_InputField inputCount; 

    public List<ObjData> sortObjsList = new List<ObjData>();
    public SortObjsDataList SortObjsData;
    private int Count;
    private int xmin = -10;

    //Активация и Деактивация кнопок
    void IsActiveButton(bool isActive)
    {
        removeButton.interactable = isActive; 
        createButton.interactable = isActive;
        sortButton.interactable = isActive;
    }

    //Создание объектов и добавление их в лист, а также их сохранение в ScriptableObject
    public void Create()
    {
        //Проверка на целочислительное
        if (!int.TryParse(inputCount.text, out Count))
        {
            TMP_Text placeholder = inputCount.placeholder as TMP_Text;
            placeholder.text = "Please, enter int count";
            inputCount.text = "";
        }
        else
        {
            //Удаление объектов со списка, если список является не пустым
            Remove();
            for(int i=0; i<Count;i++)
            {
                sortObjsList.Add(CreateObj(i));
            }
            SortObjsData.ObjsData = sortObjsList;
        }

    }

    //Создание объекта
    //имя, начение, размер, цвет, позиция
    public ObjData CreateObj(int index)
    {
        GameObject sortObj = Instantiate(GameObject);
        float scalemin = 0.2f;
        float scalemax = 2.0f;
        float value = UnityEngine.Random.Range(1,20);
        float scale = value*(scalemax-scalemin)/20f + scalemin;
        Color color = new Color(UnityEngine.Random.Range(0, 256) / 255f, 
                    UnityEngine.Random.Range(0, 256) / 255f, 
                    UnityEngine.Random.Range(0, 256) / 255f, 1);

        sortObj.name = $"Obj {index}";
        sortObj.transform.position = new Vector3(xmin+index*2, 0, 0);
        sortObj.transform.localScale = new Vector3(scale, scale, scale);
        sortObj.GetComponent<Renderer>().material.SetColor("_Color", color);

        return new ObjData(sortObj.name, scale, value, color, sortObj);
    }

    //Удаление объектов
    public void Remove()
    {
        for (int i = sortObjsList.Count - 1; i >= 0; i--)
        {
            Destroy(sortObjsList[i].GameObject);
            sortObjsList.Remove(sortObjsList[i]);
        }
    }

    //Сортировка объектов
    //Сортирует по значению. В случае если одинковые, то по названию
    public void Sort()
    {
        int algorithmIndex = dropDown.value;

        Algorithms algorithms = new Algorithms();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        switch (algorithmIndex)
        {
            case 0:
                algorithms.BubbleSort(sortObjsList);
                break;
            case 1:
                algorithms.InsertionSort(sortObjsList);
                break;
            case 2:
                algorithms.SelectionSort(sortObjsList);
                break;
            case 3:
                algorithms.QuickSort(sortObjsList);
                break;
            default:
                UnityEngine.Debug.LogError("Неизвестный индекс алгоритма сортировки");
                return;
        }
        stopwatch.Stop();
        UnityEngine.Debug.Log($"Алгоритм {dropDown.options[algorithmIndex].text} отработал за {stopwatch.ElapsedMilliseconds} миллисекунд");

        StartCoroutine(MoveToSort());

    }

    //Передвижение объектов после сортировки 
    private IEnumerator MoveToSort()
    {
        IsActiveButton(false); 
        //Передвижение объектов поочередно вперед и вверх на целевую позицию
        for(int i=0; i<sortObjsList.Count;i++)
        {
            var gameObject = sortObjsList[i].GameObject;
            if (gameObject != null)
            {
                Vector3 startPosition = gameObject.transform.position;
                yield return StartCoroutine(MoveObject(gameObject, startPosition, new Vector3(xmin+i*2, 5, 2)));
            }
        }
        yield return new WaitForSeconds(0.1f);

        //Возврат объектов на текущее значение по x и z
        for(int i=0; i<sortObjsList.Count;i++)
        {
            var gameObject = sortObjsList[i].GameObject;
            if (gameObject != null)
            {
                Vector3 startPosition = gameObject.transform.position;
                StartCoroutine(MoveObject(gameObject, startPosition, new Vector3(startPosition.x, 0, 0)));
            }
        }
        yield return new WaitForSeconds(transitionTime);
        IsActiveButton(true);
    }

    //Плавное передвижение объекта
    private IEnumerator MoveObject(GameObject gameObject, Vector3 startPosition, Vector3 endPosition)
    {
        float elapsedTime = 0;
        while (elapsedTime < transitionTime)
        {
            gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, 
                                elapsedTime/transitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        gameObject.transform.position = endPosition;
    }

    //Многовенно перемести объекты на нужные позиции
    public void Finish()
    {
        StopAllCoroutines();
        for(int i=0; i<sortObjsList.Count;i++)
        {
            var gameObject = sortObjsList[i].GameObject;
            if (gameObject != null)
            {
                gameObject.transform.position = new Vector3(xmin+i*2, 0, 0);
            }
        }

        IsActiveButton(true); 
    }
}

