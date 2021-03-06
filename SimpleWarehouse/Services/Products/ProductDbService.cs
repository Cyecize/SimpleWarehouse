﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using SimpleWarehouse.Model;
using SimpleWarehouse.Model.Enum;
using static SimpleWarehouse.App.ApplicationState;

namespace SimpleWarehouse.Services.Products
{
    public class ProductDbService : IProductDbService
    {
        public bool CreateProduct(Product product)
        {
            try
            {
                Database.Products.Add(product);
                Database.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                Database.Products.AddOrUpdate(product);
                Database.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public Product FindById(int productId)
        {
            return Database.Products.FirstOrDefault(p => p.Id == productId);
        }

        public List<Product> Search(string param, SearchParameter parameterType)
        {
            return Search(param, parameterType.SearchType, false);
        }

        public List<Product> SearchVisible(string param, SearchParameter parameterType)
        {
            return Search(param, parameterType.SearchType, true);
        }

        public List<Product> FindAllByLimit(int limit)
        {
            return new List<Product>(Database.Products.Take(limit));
        }

        public List<Product> FindAll()
        {
            return new List<Product>(Database.Products);
        }

        public List<Product> FindAllVisible()
        {
            return new List<Product>(Database.Products.Where(p => p.IsVisible));
        }

        public List<SearchParameter> GetSearchParameters()
        {
            return Database.SearchParameters.ToList();
        }

        //private logic
        private List<Product> Search(string param, SearchType searchType, bool isVisible)
        {
            param = param.ToLower();
            switch (searchType)
            {
                case SearchType.CategoryName:
                    return Database.Products
                        .Where(p => p.Category.CategoryName.ToLower().Contains(param)).ToList()
                        .Where(p => ResolveProductVisible(p, isVisible)).ToList();
                case SearchType.ProductName:
                    return Database.Products
                        .Where(p => p.ProductName.ToLower().Contains(param)).ToList()
                        .Where(p => ResolveProductVisible(p, isVisible)).ToList();
                case SearchType.ProductId:
                    return Database.Products
                        .Where(p => (p.Id + "").Contains(param)).ToList()
                        .Where(p => ResolveProductVisible(p, isVisible)).ToList();
                default:
                    return new List<Product>();
            }
        }

        private bool ResolveProductVisible(Product product, bool isVisible)
        {
            if (!isVisible)
                return true;
            return product.IsVisible;
        }
    }
}