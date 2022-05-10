using System.Collections;
using System.Collections.Generic;
using questionnaireAPI2.Entities;
using questionnaireAPI2.Helper;
using questionnaireAPI2.Repository.repository;

namespace questionnaireAPI2.Repository.services
{
    public class SurveyService : SurveyInterface
    {
        private readonly SurveyRepoInterface repository;

        public SurveyService(SurveyRepoInterface repo)
        {
            repository = repo;
        }

        public ArrayList getTexts()
        {
           var model = repository.getItems();

            var queAnsList = new ArrayList();

            foreach (QuestionnaireItem que in model.questionnaireItems)
            {
                foreach (QuestionnaireItem queSub in que.questionnaireItems)
                {
                    var queData = new List<Texts>();
                    var queAns = new List<Texts>();
                    queData.Add(queSub.texts);
                    var ansData = new List<Texts>();
                    foreach (QuestionnaireItem ans in queSub.questionnaireItems)
                    {
                        ansData.Add(ans.texts);
                    }
                    queAns.AddRange(queData);
                    queAns.AddRange(ansData);
                    queAnsList.Add(queAns);
                }
            }
            return queAnsList;
        }

        public void postItems(QuestionnaireRequest request)
        {
             repository.postItems(request);
        }
        public QuestionnaireItemRespnse departmentResults()
        {
            if(SurveyRepository.reqArray.Count != 0)
            {
                QuestionnaireItemRespnse depResults = new QuestionnaireItemRespnse();
                List<Results> resultList = new List<Results>();
                depResults.departmentResults = new List<Results>();
                var resultdict = new List<KeyValuePair<string, int>>();
                int strAgree = 0;
                int strDisagree = 0;
                int neither = 0;
                int agree = 0;
                int disagree = 0;
                int minValue = 0;
                int maxValue = 0;
                string maxKey = "";
                string minKey = "";
                foreach (QuestionnaireRequest data in SurveyRepository.reqArray)
                {
                    switch (data.departments)
                    {
                        case Constants.MARKET:
                            Results res = new Results();
                            res = resultList.Find(x => x.departments == "Market");
                            Results resMarket = new Results();
                            if (!resultList.Contains(res))
                            {
                                resMarket.departments = data.departments;
                                resultList.Add(resMarket);
                            }
                           
                            foreach (QuestionAnsItem answer in data.questionAnsItem)
                            {
                                if (Constants.STR_AGREE.Equals(answer.answer))
                                {
                                    strAgree++;
                                    resultdict.Add(new KeyValuePair<string, int>(Constants.STR_AGREE,strAgree));
                                }
                                if (Constants.STR_DISAGREE.Equals(answer.answer))
                                {
                                    strDisagree++;
                                    resultdict.Add(new KeyValuePair<string, int>(Constants.STR_DISAGREE,strDisagree));
                                }
                                if (Constants.AGREE.Equals(answer.answer))
                                {
                                    agree++;
                                    resultdict.Add(new KeyValuePair<string, int>(Constants.AGREE,agree));
                                }
                                if (Constants.DISAGREE.Equals(answer.answer))
                                {
                                    disagree++;
                                    resultdict.Add(new KeyValuePair<string, int>(Constants.DISAGREE, disagree));
                                }
                                if (Constants.NEITHER.Equals(answer.answer))
                                {
                                    neither++;
                                    resultdict.Add(new KeyValuePair<string, int>(Constants.NEITHER, neither));
                                }

                            }
                            
                            foreach (KeyValuePair<string,int> item1 in resultdict)
                            {
                                if (maxValue < item1.Value)
                                {
                                    maxKey = item1.Key;
                                    maxValue = item1.Value;
                                }
                            }

                            minValue = maxValue;
                            foreach (KeyValuePair<string, int> item in resultdict)
                            {
                                if (item.Value != 0)
                                {
                                    if (minValue > item.Value)
                                    {

                                        minKey = item.Key;
                                        minValue = item.Value;
                                    }
                                }
                            }

                            resMarket.maximum = maxKey;
                            resMarket.minimum = minKey;
                            break;
                        case Constants.SALES:
                            Results resSales = new Results();
                            resSales.departments = data.departments;
                            resultList.Add(resSales);
                            break;

                        case Constants.RECEPTION:
                            Results resRec = new Results();
                            resRec.departments = data.departments;
                            resultList.Add(resRec);
                            break;

                        case Constants.DEVELOPMENT:
                            Results resDev = new Results();
                            resDev.departments = data.departments;
                            resultList.Add(resDev);
                            break;
                    }
                }
                depResults.departmentResults.AddRange(resultList);

                return depResults;
            }

            return null;
               
        }
    }
}
