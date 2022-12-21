﻿using CleanArch.Application.ViewModels;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(int? id);
        void Add(ProductViewModel product);
        void Update(ProductViewModel product);
        bool Remove(int? id);
    }
}
