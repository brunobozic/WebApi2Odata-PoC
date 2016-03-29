﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi2OdataPoC.Repository.EF.UnitOfWork.DataModel.UnitOfWork;


namespace WebApi2Odata_PoC.Services
{
	public class UserServices : IUserServices
	{
		private readonly UnitOfWork _unitOfWork;

		/// <summary>
		/// Public constructor.
		/// </summary>
		public UserServices(UnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		/// <summary>
		/// Public method to authenticate user by user name and password.
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public int Authenticate(string userName, string password)
		{
			var user = _unitOfWork.UserRepository.Get(u => u.UserName == userName && u.Password == password);
			if (user != null && user.UserId > 0)
			{
				return user.UserId;
			}
			return 0;
		}
	}
}
