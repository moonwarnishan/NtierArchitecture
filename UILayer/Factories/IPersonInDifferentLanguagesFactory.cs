using UILayer.Models;

namespace UILayer.Factories
{
    public interface IPersonInDifferentLanguagesFactory
    {
        List<PersonInfoInDifferentLanguagesModel> GetPersonsOnSelectedLanguage(int id);
        PersonInfoInDifferentLanguagesModel PrepModelForPersonInDiffLangCreate();
        PersonInfoInDifferentLanguagesModel PrepModelForPersonInDiffLangUpdate(int id);
    }
}
