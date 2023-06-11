using Services.Viewmodel;

namespace WebFinal.Models
{
    public class ModelS
    {
        public ProductVMI productCreate { get; set; }

        public IEnumerable<ProductVM> productsList { get; set; }

    }
}
