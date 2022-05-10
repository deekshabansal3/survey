using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using questionnaireAPI2.Controllers;
using questionnaireAPI2.Entities;
using questionnaireAPI2.Repository.services;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace questionnaireAPI2.questionnaireAPI2.Tests
{
    [TestClass]
    public class SurveyControllerTests
    { 
        private readonly Mock<SurveyInterface> mockedService = new Mock<SurveyInterface>();
        private readonly SurveyController surveyController;

        public SurveyControllerTests()
        {
            surveyController = new SurveyController(mockedService.Object);
        }
        [TestMethod]
        public void getAllQuesAns()
        {
            var textList = new ArrayList();
            textList.Add("Ik ben blij met mijn werk");
            textList.Add("I am happy with my work");
          // mockedService.Setup(t => t.getTexts()).Returns(textList);
           //var data = surveyController.Get();
           //Assert.IsTrue(data == textList);
        }
        [TestMethod]
        public void PostQuesAns()
        {
            var queAnsItems = new List<QuestionAnsItem>() {
                new QuestionAnsItem()
                {
                question = "Hows work?",
                answer = "Agree"},
            };
            QuestionnaireRequest request = new QuestionnaireRequest()
            {
                userId = 1,
                departments = "Market",
                questionAnsItem = queAnsItems
            };
        }
    }
}
