using UILayer.Models;

namespace UILayer.Factories
{
    public interface ILanguageFactory
    {
        Task<LanguageModel> CreateLanguageModel();
    }
}
