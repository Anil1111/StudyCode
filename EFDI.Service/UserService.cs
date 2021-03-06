﻿using EFDI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDI.Core.Data;

namespace EFDI.Service
{
    public class UserService:IUserService
    {
        private IRepository<User> _userRepository;

        private IRepository<UserProfile> _userProfileRepository;

        public UserService(IRepository<User> userRepository,IRepository<UserProfile> userProfileRepository)
        {
            _userRepository = userRepository;
            _userProfileRepository = userProfileRepository;
        }

        public IQueryable<User> GetUsers()
        {
            return _userRepository.Table;
        }

        public User GetUser(long id)
        {
            return _userRepository.GetById(id);
        }

        public void InsertUser(User user)
        {
           _userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            _userProfileRepository.Delete(user.UserProfile);
            _userRepository.Delete(user);
        }
    }
}
