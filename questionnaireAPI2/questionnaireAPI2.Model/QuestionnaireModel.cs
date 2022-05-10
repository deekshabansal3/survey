using System.Collections.Generic;
using Newtonsoft.Json;

namespace questionnaireAPI2.Entities
{
    public class QuestionnaireItem
    {
        public Texts texts { get; set; }
        public List<QuestionnaireItem> questionnaireItems { get; set; }
    }

    public class Root
    {
        public List<QuestionnaireItem> questionnaireItems { get; set; }
    }

    public class Texts
    {
        [JsonProperty("nl-NL")]
        public string NlNL { get; set; }

        [JsonProperty("en-US")]
        public string EnUS { get; set; }
    }


}
