using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword
{
    public class GetUserByUserNameAndPasswordQuery : IGetUserByUserNameAndPasswordQuery
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;

        public GetUserByUserNameAndPasswordQuery(IDataBaseService databaseService, IMapper mapper)
        {
                _mapper = mapper;   
            _databaseService = databaseService;
        }

        public async Task<GetUserByUserNameAndPasswordModel> Execute(string userName, string password)
        {
            var entity = await _databaseService.User.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);

            return _mapper.Map<GetUserByUserNameAndPasswordModel>(entity); 
        }
    }
}
