using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        public Task<UserDTO?> GetById(int id);
        public Task<List<UserDTO>> GetAll();
        public Task Add(UserDTO quiz);
        public Task<bool> Update(UserDTO quiz);
        public Task<bool> Delete(int id);
    }
}
