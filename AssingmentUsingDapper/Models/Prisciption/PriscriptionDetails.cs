namespace AssingmentUsingDapper.Models.Prisciption
{
    public class PriscriptionDetails
    {
        public int PriscriptionId { get; set; }
        public int MedicineId { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public double TotalPrice { get; set; }

    }
}
