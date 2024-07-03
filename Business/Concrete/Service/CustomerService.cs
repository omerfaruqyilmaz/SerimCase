using AutoMapper;
using SerimCase.Business.Abstract.Command;
using SerimCase.Business.Abstract.Query;
using SerimCase.Business.Abstract.Service;
using SerimCase.Entities.Concrete;
using SerimCase.ViewModels;
using System.Net.NetworkInformation;

namespace SerimCase.Business.Concrete.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IDynamicCommandRepository _dynamicCommandRepository;
        private readonly IDynamicQuery _dynamicQuery;
        private readonly IMapper _mapper;
        public CustomerService(IDynamicCommandRepository dynamicCommandRepository,IDynamicQuery dynamicQuery,IMapper mapper)
        {
            _dynamicCommandRepository = dynamicCommandRepository;
            _dynamicQuery = dynamicQuery;
            _mapper = mapper;   
        }

        public async Task<int> AddCustomer(CustomerCreateViewModel model)
        {


            Customer customer = _mapper.Map<Customer>(model);

            int result = await _dynamicCommandRepository.AddAsync(customer);

            return result;
        }

        public async Task<List<CustomerViewModel>> CustomerList(bool? isActive)
        {


            List<Customer> customers = await _dynamicQuery.GetAllAsync<Customer>($"IsStatus = '{isActive}' ");

            List<CustomerViewModel> customerViewModels = _mapper.Map<List<CustomerViewModel>>(customers);

            return customerViewModels;

        }

        public async Task<int> DeleteCustomer(int id)
        {
            Customer customer = await _dynamicQuery.GetAsync<Customer>(id);

            if (customer == null)
            {
                return 0;
            }

            customer.IsStatus = false;
            
            int result = await _dynamicCommandRepository.UpdateAsync<Customer>(customer);

            return result;
             
        }

        public async Task<int> UpdateCustomer(CustomerUpdateViewModel model)
        {
            Customer customer = await _dynamicQuery.GetAsync<Customer>(model.Id);

            if (customer == null)
            {
                return 0;
            }

            _mapper.Map(model, customer);


            int result = await _dynamicCommandRepository.UpdateAsync(customer);

            return result;

        }
    }
}
