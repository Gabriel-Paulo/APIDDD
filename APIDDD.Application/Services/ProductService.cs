using APIDDD.Application.DTOs;
using APIDDD.Application.Services.Interface;
using APIDDD.Application.Validations;
using APIDDD.Domain.Entities;
using APIDDD.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDDD.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail<ProductDTO>("Objeto deve ser informado!");
            var result = new ProductDTOValidator().Validate(productDTO);
            if (!result.IsValid)
                return ResultService.RequestError<ProductDTO>("Problemas na validação!", result);
            var product = _mapper.Map<Product>(productDTO);
            var data = await _productRepository.CreateAsync(product);
            return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(data));
        }

        public async Task<ResultService> RemoveAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return ResultService.Fail("Produto não encontrado!");

            await _productRepository.DeleteAsync(product);
            return ResultService.Ok($"Produto ID: {id} foi deletada.");
        }

        public async Task<ResultService<ICollection<ProductDTO>>> GetAllAsync()
        {
            var product = await _productRepository.GetProductsAsync();
            return ResultService.Ok<ICollection<ProductDTO>>(_mapper.Map<ICollection<ProductDTO>>(product));
        }

        public async Task<ResultService<ProductDTO>> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return ResultService.Fail<ProductDTO>("Produto não encontrado!");
            return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(product));
        }

        public async Task<ResultService> UpdateAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail("Objeto deve ser informado");
            var validation = new ProductDTOValidator().Validate(productDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problema com a validação dos campos", validation);
            var product = await _productRepository.GetByIdAsync(productDTO.Id);
            if (product == null)
                return ResultService.Fail("Produto não encontrada!");
            product = _mapper.Map<ProductDTO, Product>(productDTO, product);// edição
            await _productRepository.EditAsync(product);
            return ResultService.Ok("Produto editado");
        }
    }
}
