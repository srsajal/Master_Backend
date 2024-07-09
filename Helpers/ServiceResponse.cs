using System.ComponentModel.DataAnnotations;
using masterDDO.Enums;

namespace masterDDO.Helpers {
    public class ServiceResponse<T> 
    {
        public T? result { get; set; }          
        public APIResponseStatus apiResponseStatus { get; set; }
        public string Message { get; set; }
        public ICollection<ValidationResult> validationResults { get; set; }
    }

    
}