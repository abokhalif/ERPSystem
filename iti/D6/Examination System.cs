using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6
{
    class Answers:ICloneable
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answers() { }
        public Answers(int id,string text)
        {
            AnswerId = id;
            AnswerText = text;
        }
        public override string ToString()
        {
            return $"Answer Id = {AnswerId} ,Answer Text = {AnswerText}";
        }
        public object Clone()
        {
            return new Answers();   
        }
    }
    abstract class Question
    {
        public abstract string Header { get; set; }
        public  string Body { get; set; }
        public double Marks { get; set; }
        public Answers[] AnswerList { get; set; }
        public Answers RightAnswer { get; set; } 
        
        public Answers this[int id]
        {
            get
            {
                for (int i=0;i<AnswerList.Length;i++) 
                {
                    if (AnswerList[i].AnswerId == id)
                    {
                        return AnswerList[i];
                    }
                }
                return new Answers();
            }
        }
        public Answers this[string text]
        {
            get
            {
                for (int i = 0; i < AnswerList?.Length; i++)
                {
                    if (AnswerList[i].AnswerText == text)
                    {
                        return AnswerList[i];
                    }
                }
                return new Answers();
            }
        }
        public Question(string body,double marks)
        {
            this.Body = body;
            this.Marks = marks;                
        }
        public static Question[] CreateBaseQuestion (int size)
        {
            Question[] questions = new Question[size];
            for (int i = 0; i < questions.Length; i++)
            {
                int questionType;
                do
                {
                    Console.WriteLine($"Please Choose the type of the question Number{i+1} [1 for T/F Question, 2 for Choose one Question, 3 for MCQ]");
                
                }while(int.TryParse(Console.ReadLine(), out questionType)|| questionType<1|| questionType>3);
                if(questionType==1) { }
                else if(questionType==2) { }
                else if(questionType==3) { }
            
            }
            return questions;

        }
    }
    internal class Assignment
    {
    }
}
