using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    GameObject answerBox;  //The InputField that the user enters the answer into
    GameObject codeQuestion;  //The Text object that contains the question for the user to answer

    string ops = "+-*";  //A string containing the operation characters.  Used for randomization

    private int correctAnswer;  //The correct answer for a given question

    // Start is called before the first frame update.  Only runs once each time the scene loads.
    void Start()
    {
        //Finds the corresponding game objects
        answerBox = GameObject.Find("AnswerField").gameObject;
        codeQuestion = GameObject.Find("CodeQuestion").gameObject;

        newQuestion();  //Generates the first question
        answerBox.GetComponent<InputField>().ActivateInputField();  //So the user doesn't need to click inside the input field to start
    }

    // Update is called once per frame
    void Update()
    {
        //If the user presses enter
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(answerBox.GetComponent<InputField>().text.Equals(correctAnswer.ToString()))
            {
                Debug.Log("Correct!");  //Prints output to the Debug Log.  Will change in the final version
                newQuestion();

                answerBox.GetComponent<InputField>().ActivateInputField();  //So the user doesn't have to click in the input field
                answerBox.GetComponent<InputField>().text = "";  //clears the previous answer from the input field
            }
            else
            {
                Debug.Log("Wrong!");

                answerBox.GetComponent<InputField>().ActivateInputField();
                answerBox.GetComponent<InputField>().text = "";
            }

            //Closes the application if the user presses the escape key
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    //Generates a new question
    void newQuestion()
    {
        string newCode = "";  //The string containing the code question
        char randomOp = ops[Random.Range(0, 3)];  //chooses a random index in the ops string
        int num1 = Random.Range(1, 10);  //random numbers from 1 to 9
        int num2 = Random.Range(1, 10);

        //Finds the correct answer
        switch(randomOp)
        {
            case '+':
                correctAnswer = num1 + num2;
                break;
            case '-':
                correctAnswer = num1 - num2;
                break;
            case '*':
                correctAnswer = num1 * num2;
                break;
            default:
                break;
        }

        //New question
        newCode += "int foo;";
        newCode += "\nfoo = ";
        newCode += num1 + " " + randomOp + " " + num2 + ";";
        newCode += "\ncout << foo << endl;";

        //Sets the text in the game to display the new question
        codeQuestion.GetComponent<Text>().text = newCode;
    }
}
