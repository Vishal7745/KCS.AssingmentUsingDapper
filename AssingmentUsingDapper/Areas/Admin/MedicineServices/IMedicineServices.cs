using AssingmentUsingDapper.Areas.Admin.Models.Medicine;
//using AssingmentUsingDapper.Helper;

namespace AssingmentUsingDapper.Areas.Admin.MedicineServices
{
    public interface IMedicineServices
    {
        public  List<Medicine> GeAllMedicine();
        public Medicine FindById(int id);
        public string Create(Medicine entity);
        public string Update(Medicine entity);
        public string Delete(int id);

    }
}
