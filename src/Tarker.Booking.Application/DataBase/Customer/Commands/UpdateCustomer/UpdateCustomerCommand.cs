using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IUpdateCustomerCommand
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;

        public UpdateCustomerCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService; ;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerModel> Execute(UpdateCustomerModel model)
        {
            var entity = _mapper.Map<CustomerEntity>(model);
             _databaseService.Customer.Update(entity);
            await _databaseService.SaveAsync();

            return model;
        }
    }
}
