using AssingmentUsingDapper.Areas.User.Models.Medicine;

namespace AssingmentUsingDapper.Areas.User.MedicineServices
{
    public interface IMedicineServicesUser
    {
        public  List<MedicineUser> GeAllMedicine();

        public MedicineUser FindById(int id);
        public void Create(MedicineUser entity);
        public void Update(MedicineUser entity);
        public void Delete(MedicineUser entity);

    }
}
