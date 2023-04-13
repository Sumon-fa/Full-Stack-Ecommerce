using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Db;
using backend.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;


namespace backend.Services;

public class ProductService : CrudService<Product, ProductDTO>
{
    private readonly ImageService _imageService;
    public ProductService(AppDbContext dbContext, ImageService imageService) : base(dbContext, imageService)
    {
        _imageService = imageService;
    }

}
