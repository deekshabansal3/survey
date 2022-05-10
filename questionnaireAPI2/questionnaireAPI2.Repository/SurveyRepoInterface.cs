using questionnaireAPI2.Entities;

namespace questionnaireAPI2.Repository.repository
{
    public interface SurveyRepoInterface
    {
       QuestionnaireItem getItems();
       void postItems(QuestionnaireRequest request);
    }
}
