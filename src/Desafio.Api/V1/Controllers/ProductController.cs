using AutoMapper;
using Desafio.Api.ControllersMain;
using Desafio.Api.Extensions;
using Desafio.Api.ViewModels;
using Desafio.Application.Contracts;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController: MainController
    {
        private readonly IApplicationProduct _applicationProduct;
        private readonly IMapper _mapper;

        public ProductController(IApplicationProduct applicationProduct,
                                 IMapper mapper, 
                                 INotification notification): base(notification)
        {
            _applicationProduct = applicationProduct;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IEnumerable<ProductViewModelResponse>> GetAll()
                     => _mapper.Map<IEnumerable<ProductViewModelResponse>>
                     (await _applicationProduct.GetAllProductWithSupplierCategory());


        [HttpGet("{id:guid}")]
        public async Task<ProductViewModelResponse> GetById(Guid id)
                    => _mapper.Map<ProductViewModelResponse>
                    (await _applicationProduct.GetProductWithSupplierCategory(id));



        [ClaimsAuthorize("Product", "Add")]
        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModelRequest productViewModel)
        {            
            if (!ModelState.IsValid) return CustomResponse(ModelState);

             await _applicationProduct.Add(_mapper.Map<Product>(productViewModel));

            return CustomResponse(productViewModel);
        }

        [ClaimsAuthorize("Product", "Delete")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _applicationProduct.Delete(id);

            return CustomResponse();
        }

        [ClaimsAuthorize("Product", "Update")]
        [HttpPut]
        public async Task<IActionResult> Update(ProductViewModelRequest productViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
                   
            await _applicationProduct.Update(_mapper.Map<Product>(productViewModel));

            return CustomResponse(productViewModel);
        }
    }
}
