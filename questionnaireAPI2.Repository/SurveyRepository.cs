using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using questionnaireAPI2.Entities;

namespace questionnaireAPI2.Repository.repository
{
    public class SurveyRepository : SurveyRepoInterface
    {
        public static List<QuestionnaireRequest> reqArray = new List<QuestionnaireRequest>();

        QuestionnaireItem model = new QuestionnaireItem();

        public QuestionnaireItem getItems()
     {
        StreamReader reader = new StreamReader("questionnaireAPI2.Repository/Data/questionnaire.json");
        string jsonString = reader.ReadToEnd();
        model = JsonConvert.DeserializeObject<QuestionnaireItem>(jsonString);
        return model;
     }

        public void postItems(QuestionnaireRequest request)
     {
            reqArray.Add(request);
            Console.WriteLine(reqArray);
      }
   }
 }
    