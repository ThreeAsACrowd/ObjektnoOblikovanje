
namespace DataRepository.Models
{
    public class OutgoingInvoice : Invoice
    {
        public virtual string CustomerInfo { get; set; }


        public override string getInfo()
        {
            return CustomerInfo;
        }
    }
}
