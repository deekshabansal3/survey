using System.Collections;
using questionnaireAPI2.Entities;

namespace questionnaireAPI2.Repository.services
{
    public interface SurveyInterface
    {
        ArrayList getTexts();

        void postItems(QuestionnaireRequest request);

        QuestionnaireItemRespnse departmentResults();
    }
}
