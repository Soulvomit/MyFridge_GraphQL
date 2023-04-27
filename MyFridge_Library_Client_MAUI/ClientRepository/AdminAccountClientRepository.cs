﻿using MyFridge_Library_Client_MAUI.ClientRepository.Abstract;
using MyFridge_Library_Client_MAUI.ClientRepository.Interface;
using MyFridge_Library_Client_MAUI.ClientModel;

namespace MyFridge_Library_Client_MAUI.ClientRepository
{
    public class AdminAccountClientRepository : ClientRepository<AdminAccountDto>, IAdminAccountClientRepository
    {
        public AdminAccountClientRepository(string baseAddress) : base(baseAddress) { }
    }
}
