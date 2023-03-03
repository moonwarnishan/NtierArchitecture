using UILayer.Models;

namespace UILayer.Factories
{
    public interface IPersonFactory
    {
        PersonModel PersonModelPrepareForCreate();

        PersonModel PreparePersonModelForEdit(int id);
        List<PersonModel> PreparePersonModelList();
        PersonModel PreparePersonModelForDetailsView(int Id);
    }
}
