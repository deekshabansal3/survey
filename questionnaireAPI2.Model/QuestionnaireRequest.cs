using System;
using System.Collections.Generic;

namespace questionnaireAPI2.Entities
{
    public class QuestionnaireRequest
    {
        public int userId { get; set; }
        public string departments { get; set; }
        public List<QuestionAnsItem> questionAnsItem { get; set; }
    }
    public class QuestionAnsItem
    {
        public string question { get; set; }
        public string answer { get; set; }
    }
}
