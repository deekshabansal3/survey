using System.Collections.Generic;

namespace questionnaireAPI2.Entities
{
    public class QuestionnaireItemRespnse
    {
        public List<Results> departmentResults{ get; set; }
    }
    public class Results
    {
        public string departments { get; set; }
        public string minimum { get; set; }
        public string maximum { get; set; }
        public string average { get; set; }
    }
}

