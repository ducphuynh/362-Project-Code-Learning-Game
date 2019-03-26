using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDropQuestion : MonoBehaviour
{
    GameObject codeQuestion;
    GameObject choice1, choice2, choice3, choice4;
    GameObject answer1, answer2, answer3, answer4;
    Vector3 correctPosition1;
    Vector3 correctPosition2;
    Vector3 correctPosition3;
    Vector3 correctPosition4;
    int questionNumber;
    int prevQuestionNumber = 0;

    void Start()
    {
        codeQuestion = GameObject.Find("Question").gameObject;
        choice1 = GameObject.Find("Choice1").gameObject;
        choice2 = GameObject.Find("Choice2").gameObject;
        choice3 = GameObject.Find("Choice3").gameObject;
        choice4 = GameObject.Find("Choice4").gameObject;

        answer1 = GameObject.Find("Answer1").gameObject;
        answer2 = GameObject.Find("Answer2").gameObject;
        answer3 = GameObject.Find("Answer3").gameObject;
        answer4 = GameObject.Find("Answer4").gameObject;

        newQuestion();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch(questionNumber)
            {
                case 1:
                    if (choice1.GetComponent<RectTransform>().localPosition == correctPosition1 &&
                        choice3.GetComponent<RectTransform>().localPosition == correctPosition2)
                    {
                        Debug.Log("Correct!");
                        resetPositions();
                        newQuestion();
                    }
                    else
                    {
                        Debug.Log("Incorrect.");
                        resetPositions();
                        newQuestion();
                    }
                    break;
                case 2:
                    if (choice2.GetComponent<RectTransform>().localPosition == correctPosition1 &&
                        choice4.GetComponent<RectTransform>().localPosition == correctPosition2 &&
                        choice1.GetComponent<RectTransform>().localPosition == correctPosition3)
                    {
                        Debug.Log("Correct!");
                        resetPositions();
                        newQuestion();
                    }
                    else
                    {
                        Debug.Log("Incorrect.");
                        resetPositions();
                        newQuestion();
                    }
                    break;
                case 3:
                    if (choice1.GetComponent<RectTransform>().localPosition == correctPosition3 &&
                        choice2.GetComponent<RectTransform>().localPosition == correctPosition4 &&
                        choice3.GetComponent<RectTransform>().localPosition == correctPosition1 &&
                        choice4.GetComponent<RectTransform>().localPosition == correctPosition2)
                    {
                        Debug.Log("Correct!");
                        resetPositions();
                        newQuestion();
                    }
                    else
                    {
                        Debug.Log("Incorrect.");
                        resetPositions();
                        newQuestion();
                    }
                    break;
                default:
                    break;
            }
    
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    void newQuestion()
    {
        string newCode = "";
        if (prevQuestionNumber == 0)
        {
            questionNumber = Random.Range(1, 4);
            prevQuestionNumber = questionNumber;
        }
        else
        {
            while (questionNumber == prevQuestionNumber)
            {
                questionNumber = Random.Range(1, 4);
            }
            prevQuestionNumber = questionNumber;
        }

        switch (questionNumber)
        {
            case 1:
                newCode += "#include <              >";
                newCode += "\nint main()";
                newCode += "\n{";
                newCode += "\nstring phrase = \"Hello World\";";
                newCode += "\n             cout << foo << endl;";
                newCode += "\nreturn 0;";
                newCode += "\n}";
                choice1.GetComponent<Text>().text = "iostream";
                choice2.GetComponent<Text>().text = "fstream";
                choice3.GetComponent<Text>().text = "std::";
                choice4.GetComponent<Text>().text = "ios::";
                answer1.GetComponent<RectTransform>().localPosition = new Vector3(-145, (float)223.05, 0);
                answer2.GetComponent<RectTransform>().localPosition = new Vector3(-218, 104, 0);
                correctPosition1 = new Vector3(-145, (float)223.05, 0);
                correctPosition2 = new Vector3(-218, 104, 0);
                break;
            case 2:
                newCode += "           factorial(int n);";
                newCode += "\n{";
                newCode += "\n\tif (n > 1)";
                newCode += "\n\t\treturn n * factorial(            );";
                newCode += "\n\telse";
                newCode += "\n\t\treturn        ;";
                newCode += "\n}";
                choice1.GetComponent<Text>().text = "1";
                choice2.GetComponent<Text>().text = "int";
                choice3.GetComponent<Text>().text = "n + 1";
                choice4.GetComponent<Text>().text = "n - 1";
                answer1.GetComponent<RectTransform>().localPosition = new Vector3(-231, (float)223.05, 0);
                answer2.GetComponent<RectTransform>().localPosition = new Vector3(6, 134, 0);
                answer3.GetComponent<RectTransform>().localPosition = new Vector3(-138, 85, 0);
                correctPosition1 = new Vector3(-231, (float)223.05, 0);
                correctPosition2 = new Vector3(6, 134, 0);
                correctPosition3 = new Vector3(-138, 85, 0);
                break;
            case 3:
                newCode += "while (current !=               )";
                newCode += "\n{";
                newCode += "\n\tnext = current      next;";
                newCode += "\n\tcurrent->next = prev;";
                newCode += "\n\tprev =           ;";
                newCode += "\n\tcurrent = next;";
                newCode += "\n};";
                newCode += "\nhead =          ;";
                choice1.GetComponent<Text>().text = "current";
                choice2.GetComponent<Text>().text = "prev";
                choice3.GetComponent<Text>().text = "NULL";
                choice4.GetComponent<Text>().text = "->";
                answer1.GetComponent<RectTransform>().localPosition = new Vector3(-80, (float)223.05, 0);
                answer2.GetComponent<RectTransform>().localPosition = new Vector3(-70, 164, 0);
                answer3.GetComponent<RectTransform>().localPosition = new Vector3(-152, 104, 0);
                answer4.GetComponent<RectTransform>().localPosition = new Vector3(-186, 21, 0);
                correctPosition1 = new Vector3(-80, (float)223.05, 0);
                correctPosition2 = new Vector3(-70, 164, 0);
                correctPosition3 = new Vector3(-152, 104, 0);
                correctPosition4 = new Vector3(-186, 21, 0);
                break;
            default:
                break;
        }

        codeQuestion.GetComponent<Text>().text = newCode;
    }

    void resetPositions()
    {
        choice1.GetComponent<RectTransform>().localPosition = new Vector3(184, 186, 0);
        choice2.GetComponent<RectTransform>().localPosition = new Vector3(184, 134, 0);
        choice3.GetComponent<RectTransform>().localPosition = new Vector3(184, 85, 0);
        choice4.GetComponent<RectTransform>().localPosition = new Vector3(184, 34, 0);

        answer1.GetComponent<RectTransform>().localPosition = new Vector3(184, -59, 0);
        answer2.GetComponent<RectTransform>().localPosition = new Vector3(184, -106, 0);
        answer3.GetComponent<RectTransform>().localPosition = new Vector3(184, -154, 0);
        answer4.GetComponent<RectTransform>().localPosition = new Vector3(184, -201, 0);
    }
}