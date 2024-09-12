using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.Runtime.ExceptionServices;

public class Armor
{
    public string Name;
    public int Defence;
    public int Heaviness;
}

//public class Armors
//{
    
//}

public class LitJson_Demo : MonoBehaviour
{

    public Armor[] NewArmors;
    // Start is called before the first frame update
    void Start()
    {

        //FuncForArmor();
        FuncForArmor2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //litjson第一种创建json文件方法
    private void FuncForArmor()
    {
        Armor IronArmor = new Armor();
        IronArmor.Name = "Iron Armor";
        IronArmor.Heaviness = 10;
        IronArmor.Defence = 20;

        Armor LeatherArmor = new Armor();
        LeatherArmor.Name = "Leather Armor";
        LeatherArmor.Defence = 3;
        LeatherArmor.Heaviness = 5;

        NewArmors = new Armor[] { IronArmor, LeatherArmor};

        //创建json
        string StoreJson = JsonMapper.ToJson(NewArmors);

        Armor[] ReleaseJson = JsonMapper.ToObject<Armor[]>(StoreJson);

        ShowJson(StoreJson, ReleaseJson[0].Name);
    }

    private void ShowJson(string First, string Second)
    {
        Debug.Log(First);

        Debug.Log(Second);
    }

    //litjson第二种创建json文件方法

    private void FuncForArmor2()
    {
        //{[{},{}...]}
        JsonData JsonDTOfArmor = new JsonData();//最外层{}
        JsonData ArmorArray = new JsonData();//[]

        //创建第一个armor对象
        JsonData IronOne = new JsonData();
        IronOne["Name"] = "Iron Armor";
        IronOne["Heaviness"] = 10;
        IronOne["Defence"] = 20;

        //创建第二个armor对象
        JsonData LeatherOne = new JsonData();
        LeatherOne["Name"] = "Leather Armor";
        LeatherOne["Heaviness"] = 5;
        LeatherOne["Defence"] = 4;

        ArmorArray.Add(IronOne);
        ArmorArray.Add(LeatherOne);

        Debug.Log(ArmorArray.ToJson());

        ReleaseJson(ArmorArray);
    }

    //litjson第二种解析json文件方法
    private void ReleaseJson(JsonData JSDT)
    {
        foreach(JsonData Item in JSDT)
        {
            Debug.Log(Item["Name"].ToString());
            Debug.Log((int)Item["Heaviness"]);
            Debug.Log((int)Item["Defence"]);
        }
    }
}
