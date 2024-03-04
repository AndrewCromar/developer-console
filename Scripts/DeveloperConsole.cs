using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperConsole : MonoBehaviour {
    [HideInInspector] public static DeveloperConsole Instance;

    [SerializeField] private InputField input;
    [SerializeField] private RectTransform output_parent;

    [Header ("Output Types")]
    [SerializeField] private GameObject output_output_prefab;

    private void Awake(){ Instance = this; }

    public void LogNeutral(string text){
        NewOuput().GetComponent<Text>().text = "<color=white>ONYX > </color><color=white>" + text + "</color>";
    }

    public void LogWarning(string text){
        NewOuput().GetComponent<Text>().text = "<color=white>ONYX > </color><color=yellow>" + text + "</color>";
    }

    public void LogError(string text){
        NewOuput().GetComponent<Text>().text = "<color=white>ONYX > </color><color=red>" + text + "</color>";
    }

    public void RunCommand(){
        string _input = input.text;
        List<string> args = new List<string>(_input.Split(' '));
        string command = args[0];
        args.RemoveAt(0);

        NewOuput().GetComponent<Text>().text = "<color=orage>> " + _input + ";" + command + ";" + args + "</color>";
        
        NewOuput().GetComponent<Text>().text = "<color=white>ONYX > CMD > </color><color=lightblue>" + command + "</color>";
        
        if(command == "help") HelpCommand();
        
        input.text = "";
    }

    private void HelpCommand(){
        NewOuput().GetComponent<Text>().text = "<color=white>Commands:</color>";
        NewOuput().GetComponent<Text>().text = "<color=white>help : Displays the help dialog.</color>";
    }

    private GameObject NewOuput(){ return Instantiate(output_output_prefab, output_parent); }

    private void Start(){
        DeveloperConsole.Instance.LogNeutral("ONYX Developer Console V1.");
        DeveloperConsole.Instance.LogNeutral("Use \"help\" for a list of built in commands.");
    }
}