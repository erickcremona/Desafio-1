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
    public class CategoryController : MainController
    {
        private readonly IApplicationCategory _applicationCategory;
        private readonly IMapper _mapper;

        public CategoryController(INotification notification,
                                  IApplicationCategory repositoryCategory,
                                  IMapper mapper) : base(notification)
        {
            _applicationCategory = repositoryCategory;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<CategoryViewModelResponse>> GetAll() 
            => _mapper.Map<IEnumerable<CategoryViewModelResponse>>(await _applicationCategory.GetAllAsync());

               
        [HttpGet("{id:guid}")]
        public async Task<CategoryViewModelResponse> GetById(Guid id)
        {
            var category = await _applicationCategory.GetCategoryWithProduct(id);
            
            var categoryViewModel = _mapper.Map<CategoryViewModelResponse>(category);

            categoryViewModel.ProductsByCategory = category.GetProductsByCategory(category.Products);

            return categoryViewModel;
        }
            

        [ClaimsAuthorize("Category", "Add")]
        [HttpPost]
        public ActionResult<CategoryViewModelRequest> Add(CategoryViewModelRequest categoryViewModel)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);

            _applicationCategory.Add(_mapper.Map<Category>(categoryViewModel));

            return CustomResponse(categoryViewModel);
        }

        [ClaimsAuthorize("Category", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoryViewModelRequest>> Update(Guid id, CategoryViewModelRequest categoryViewModel)
        {
            var category = await _applicationCategory.GetById(id);

            if (category == null) return NotFound();

            category.SetCategory(_mapper.Map<Category>(categoryViewModel));

            _applicationCategory.Update(category);

            return CustomResponse(_mapper.Map<CategoryViewModelRequest>(category));
        }

        [ClaimsAuthorize("Category", "Delete")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CategoryViewModelRequest>> Delete(Guid id)
        {
            var category = await _applicationCategory.GetCategoryWithProduct(id);

            if (category == null) return NotFound();

            await _applicationCategory.Delete(category);

            return CustomResponse(_mapper.Map<CategoryViewModelRequest>(category));
        }
    }
}
