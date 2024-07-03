using SerimCase.Entities.Concrete;
using SerimCase.ViewModels;

namespace SerimCase.Business.Abstract.Service
{
    public interface ICustomerService
    {
       Task<List<CustomerViewModel>> CustomerList(bool? isActive);
       Task<int> DeleteCustomer(int id);
       Task<int> UpdateCustomer(CustomerUpdateViewModel model);
       Task<int> AddCustomer(CustomerCreateViewModel model);
    }
}
