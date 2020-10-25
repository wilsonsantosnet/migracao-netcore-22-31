using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Dto;
using Seed.Application.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Services;
using Seed.Dto;
using System.Threading.Tasks;
using Common.Domain.Model;
using System.Collections.Generic;
using AutoMapper;

namespace Seed.Application
{
    public class SampleItemApplicationServiceBase : ApplicationServiceBase<SampleItem, SampleItemDto, SampleItemFilter>, ISampleItemApplicationService
    {
        protected readonly ValidatorAnnotations<SampleItemDto> _validatorAnnotations;
        protected readonly ISampleItemService _service;
        protected readonly CurrentUser _user;

        public SampleItemApplicationServiceBase(ISampleItemService service, IUnitOfWork uow, ICache cache, CurrentUser user, IMapper mapper) :
            base(service, uow, cache, mapper, user)
        {
            base.SetTagNameCache("SampleItem");
            this._validatorAnnotations = new ValidatorAnnotations<SampleItemDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<SampleItem> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as SampleItemDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<SampleItem>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<SampleItem>();
			foreach (var dto in dtos)
			{
				var _dto = dto as SampleItemDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<SampleItem> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as SampleItemDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
