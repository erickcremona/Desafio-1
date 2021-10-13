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
    public class SupplierController : MainController
    {
        private readonly IApplicationSupplier _applicationSupplier;
        private readonly IMapper _mapper;
        public SupplierController(IApplicationSupplier applicationSupplier,
                                 IMapper mapper,
                                 INotification notification) : base(notification)
        {
            _applicationSupplier = applicationSupplier;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<SupplierViewModelResponse>> GetAll()
                    => _mapper.Map<IEnumerable<SupplierViewModelResponse>>
                    (await _applicationSupplier .GetAll());


        [HttpGet("{id:guid}")]
        public async Task<SupplierViewModelResponse> GetById(Guid id)
                    => _mapper.Map<SupplierViewModelResponse>
                    (await _applicationSupplier.GetSuppliersWithProductAddress(id));


        [ClaimsAuthorize("Supplier", "Add")]
        [HttpPost]
        public async Task<IActionResult> Add(SupplierViewModelRequest supplierViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _applicationSupplier.Add(_mapper.Map<Supplier>(supplierViewModel));

            return CustomResponse(supplierViewModel);
        }

        [ClaimsAuthorize("Supplier", "Update")]
        [HttpPut]
        public async Task<IActionResult> Update(SupplierViewModelRequest supplierViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _applicationSupplier.Update(_mapper.Map<Supplier>(supplierViewModel));

            return CustomResponse(supplierViewModel);
        }

        [ClaimsAuthorize("Supplier", "Delete")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _applicationSupplier.Delete(id);

            return CustomResponse();
        }
    }
}
