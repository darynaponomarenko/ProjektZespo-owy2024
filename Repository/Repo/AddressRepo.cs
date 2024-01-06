using Repository.DataAccess;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public  class AddressRepo : IAddress
    {
        private readonly DBContext _dbContext;

        public AddressRepo(DBContext context)
        {
            _dbContext = context;
        }

        public async Task AddAddress(Address address)
        {
            var newAddress = _dbContext.Addresses;
            if (newAddress == null)
                throw new ArgumentException(nameof(address));
            else
                _dbContext.Addresses.Add(address);
            await _dbContext.SaveChangesAsync();
            
        }
    }
}
