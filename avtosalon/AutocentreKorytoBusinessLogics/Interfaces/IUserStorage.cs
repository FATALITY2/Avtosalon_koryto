﻿using AutocentreKorytoClientBusinessLogics.BindingModels;
using AutocentreKorytoClientBusinessLogics.ViewModels;
using System.Collections.Generic;

namespace AutocentreKorytoClientBusinessLogics.Interfaces
{
    public interface IUserStorage
    {
        List<UserViewModel> GetFullList();

        List<UserViewModel> GetFilteredList(UserBindingModel model);

        UserViewModel GetElement(UserBindingModel model);

        void Insert(UserBindingModel model);

        void Update(UserBindingModel model);

        void Delete(UserBindingModel model);
    }
}
