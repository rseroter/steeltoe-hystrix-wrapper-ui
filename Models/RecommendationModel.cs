namespace core_hystrix_wrapper_ui.Models
{
 public class Recommendations {

        private string productId;
        private string productImage;
        private string productDescription;

        public string ProductId {
            get { return productId; }
            set { productId = value; }
        }

        public string ProductImage {
            get { return productImage; }
            set { productImage = value; }
        }

        public string ProductDescription {
            get { return productDescription; }
            set { productDescription = value; }
        }
    }   
}